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
	public SceneGameMap(RandomItemGenerator randomItemGenerator, RandomEnemyGenerator randomEnemyGenerator,
		Player player, FightManager fightManager)
	{
		// Variable init
		Name = "Game Map";
		Camera = new() {
			Name = "Camera"
		};
		UICamera = new() {
			Name = "UI Camera"
		};
		RandomEnemyGenerator = randomEnemyGenerator;
		RandomMapGenerator = new(randomItemGenerator, randomEnemyGenerator, fightManager, this);
		FightManager = fightManager;
		Player = player;
		LevelText = new() {
			Position = new(800, 10),
			Camera = UICamera,
			Text = "Level 1",
			Color = new(255, 255, 255)
		};
		Map = new(Camera, Player, 40);

		// Camera boundaries
		Camera.BoundaryMin = new(-GameMap.TileSize, -GameMap.TileSize);
		Camera.BoundaryMax = new(GameMap.TileSize * (Map.MapSize + 1), GameMap.TileSize * (Map.MapSize + 1));

		// Map
		NextLevel();
		RegisterGameObject(Map);

		// Inventory
		GameObject inventoryBackground = new() {
			Position = new(912, 0),
			Camera = UICamera,
			Sprite = SpriteManager.CreateSprite<StaticSprite>("ui/equipment_bg")
		};
		RegisterGameObject(inventoryBackground);

		InventoryView inventoryView = new(Player.Inventory, UICamera);
		inventoryView.Position = new(912, 0);
		RegisterGameObject(inventoryView);

		Player.Inventory.AddItem(randomItemGenerator.Generate(RandomItemGenerator.Type.StartingWeapon),
			Inventory.EquipmentStartIndex);
		Player.Inventory.AddItem(randomItemGenerator.Generate(RandomItemGenerator.Type.StartingSpell),
			Inventory.SpellStartIndex);

		// Stats
		TextObject statsTextLeft = new() {
			Position = new(970, 240),
			Camera = UICamera,
			Text = "StatsLeft",
			Color = new(255, 255, 255)
		};
		RegisterGameObject(statsTextLeft);

		TextObject statsTextRight = new() {
			Position = new(1082, 264),
			Camera = UICamera,
			Text = "StatsRight",
			Color = new(255, 255, 255)
		};
		RegisterGameObject(statsTextRight);

		Player.Stats.AddViewSprites(statsTextLeft, statsTextRight);

		// Level text
		RegisterGameObject(LevelText);

		// Input events
		Input.KeyDownEvent += HandleKeyDown;
		Input.MouseMotionEvent += HandleMouseMotion;
		Input.MouseWheelEvent += HandleMouseWheel;
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

	void HandleKeyDown(object? sender, KeyDownEventArgs e)
	{
		if (e.KeyEvent == KeyEvents.MoveDown)
			Map.MovePlayer(new(0, 1));
		else if (e.KeyEvent == KeyEvents.MoveUp)
			Map.MovePlayer(new(0, -1));
		else if (e.KeyEvent == KeyEvents.MoveLeft)
			Map.MovePlayer(new(-1, 0));
		else if (e.KeyEvent == KeyEvents.MoveRight)
			Map.MovePlayer(new(1, 0));
		else if (e.KeyEvent == KeyEvents.CenterCamera)
			CenterOnPlayer();
	}

	void HandleMouseMotion(object? sender, MouseMotionEventArgs e)
	{
		if (e.LeftButton)
			Camera.Position -= e.RelativeMotion / Camera.Scale;
	}

	void HandleMouseWheel(object? sender, MouseWheelEventArgs e)
	{
		if (e.Scroll.Y > 0)
			Camera.ZoomIn();
		else if (e.Scroll.Y < 0)
			Camera.ZoomOut();
	}

	void CenterOnPlayer()
	{
		Tile player = Map.InteractLayer[Player.Position.X, Player.Position.Y];
		Vector2D playerOffset = new(player.MapObject!.Sprite.Width / 2, player.MapObject!.Sprite.Height / 2);
		Vector2D inventoryOffset = new((int)((1280 - 912) / 2.0 / Camera.Scale), 0);
		Camera.CenterOn(player.Position + playerOffset + inventoryOffset);
	}
}
