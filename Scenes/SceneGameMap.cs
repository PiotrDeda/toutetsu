using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Inputs;
using Rokuro.MathUtils;
using Rokuro.Objects;
using Toutetsu.Components;
using Toutetsu.Enemies;
using Toutetsu.Items;
using Toutetsu.Map;
using Toutetsu.State;

namespace Toutetsu.Scenes;

public class SceneGameMap : Scene, ILevelHandler
{
	public SceneGameMap(SpriteManager spriteManager, Input input, Drawer drawer, WindowData windowData,
		RNG rng, RandomItemGenerator randomItemGenerator, RandomEnemyGenerator randomEnemyGenerator,
		Player player, FightManager fightManager)
	{
		// Variable init
		Name = "SceneGameMap";
		Camera = new(drawer, windowData);
		UICamera = new(drawer, windowData);
		RandomEnemyGenerator = randomEnemyGenerator;
		RandomMapGenerator = new(spriteManager, rng, randomItemGenerator, randomEnemyGenerator, fightManager, this);
		FightManager = fightManager;
		Player = player;
		LevelText = new(UICamera, "Level 1", new(255, 255, 255), spriteManager.DefaultFont);
		Map = new(Camera, Player, 40);

		// Camera boundaries
		Camera.BoundaryMin = new(-GameMap.TileSize, -GameMap.TileSize);
		Camera.BoundaryMax = new(GameMap.TileSize * (Map.MapSize + 1), GameMap.TileSize * (Map.MapSize + 1));

		// Map
		NextLevel();
		RegisterGameObject(Map);

		// Inventory
		SimpleObject inventoryBackground = new(spriteManager.CreateSpriteFromTemplate("equipment_bg"), UICamera);
		inventoryBackground.Position = new(912, 0);
		RegisterGameObject(inventoryBackground);

		InventoryView inventoryView = new(Player.Inventory, UICamera, input);
		inventoryView.Position = new(912, 0);
		RegisterGameObject(inventoryView);

		Player.Inventory.AddItem(randomItemGenerator.Generate(RandomItemGenerator.Type.StartingWeapon),
			Inventory.EquipmentStartIndex);
		Player.Inventory.AddItem(randomItemGenerator.Generate(RandomItemGenerator.Type.StartingSpell),
			Inventory.SpellStartIndex);

		// Stats
		TextObject statsTextLeft = new(UICamera, "StatsLeft", new(255, 255, 255), spriteManager.DefaultFont);
		statsTextLeft.Position = new(970, 240);
		RegisterGameObject(statsTextLeft);

		TextObject statsTextRight = new(UICamera, "StatsRight", new(255, 255, 255), spriteManager.DefaultFont);
		statsTextRight.Position = new(1082, 264);
		RegisterGameObject(statsTextRight);

		Player.Stats.AddViewSprites(statsTextLeft, statsTextRight);

		// Level text
		LevelText.Position = new(800, 10);
		RegisterGameObject(LevelText);
	}

	Camera Camera { get; }
	UICamera UICamera { get; }
	RandomEnemyGenerator RandomEnemyGenerator { get; }
	RandomMapGenerator RandomMapGenerator { get; }
	FightManager FightManager { get; }
	Player Player { get; }
	GameMap Map { get; }
	TextObject LevelText { get; }
	int CurrentLevel { get; set; }

	public void NextLevel()
	{
		CurrentLevel++;
		Player.Stats.FullHeal();
		RandomMapGenerator.Generate(Map, new(), CurrentLevel);
		CenterOnPlayer();
		if (CurrentLevel == 4)
			Map.InteractLayer[Map.ExitPosition.X, Map.ExitPosition.Y].MapObject =
				new BossUnit(RandomEnemyGenerator.Generate(RandomEnemyGenerator.Type.Boss), FightManager);
		LevelText.Text = $"Level {CurrentLevel}";
	}

	public override void HandleEvent(IInputEvent e)
	{
		if (e is KeyEvent keyEvent)
			if (keyEvent == KeyEvents.MoveDown)
				Map.MovePlayer(new(0, 1));
			else if (keyEvent == KeyEvents.MoveUp)
				Map.MovePlayer(new(0, -1));
			else if (keyEvent == KeyEvents.MoveLeft)
				Map.MovePlayer(new(-1, 0));
			else if (keyEvent == KeyEvents.MoveRight)
				Map.MovePlayer(new(1, 0));
			else if (keyEvent == KeyEvents.CenterCamera)
				CenterOnPlayer();

		if (e is MouseWheelEvent mouseWheelEvent)
			if (mouseWheelEvent.Scroll.Y > 0)
				Camera.ZoomIn();
			else if (mouseWheelEvent.Scroll.Y < 0)
				Camera.ZoomOut();

		if (e is MouseMotionEvent mouseMotionEvent)
			if (mouseMotionEvent.RightButton)
				Camera.Position -= mouseMotionEvent.RelativeMotion / Camera.Scale;
	}

	void CenterOnPlayer()
	{
		Tile player = Map.InteractLayer[Player.Position.X, Player.Position.Y];
		Vector2D playerOffset = new(player.MapObject!.Sprite.Width() / 2, player.MapObject!.Sprite.Height() / 2);
		Vector2D inventoryOffset = new((int)((1280 - 912) / 2.0 / Camera.Scale), 0);
		Camera.CenterOn(player.Position + playerOffset + inventoryOffset);
	}
}
