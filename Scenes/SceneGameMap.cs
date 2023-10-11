using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Inputs;
using Rokuro.Objects;
using Toutetsu.Components;
using Toutetsu.Items;
using Toutetsu.Map;
using Toutetsu.State;

namespace Toutetsu.Scenes;

public class SceneGameMap : Scene, ILevelHandler
{
	public SceneGameMap(SpriteManager spriteManager, Input input, Drawer drawer, WindowData windowData,
		RandomItemGenerator randomItemGenerator, Player player, FightManager fightManager)
	{
		// Variable init
		Name = "SceneGameMap";
		Camera = new(drawer, windowData);
		UICamera = new(drawer, windowData);
		Player = player;
		FightManager = fightManager;
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

		Player.Inventory.AddItem(randomItemGenerator.Generate(RandomItemGenerator.Type.StartingWeapon));
		Player.Inventory.AddItem(randomItemGenerator.Generate(RandomItemGenerator.Type.StartingSpell));

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

		// Debug
		// TODO: Remove when map generation is done
		Floor floor = new(spriteManager);
		Map.FloorLayer[3, 1].MapObject = floor;
		Map.FloorLayer[4, 1].MapObject = floor;
		Map.FloorLayer[5, 1].MapObject = floor;
		Map.FloorLayer[4, 2].MapObject = floor;
		Map.WallLayer[1, 1].MapObject = new WallTorch(spriteManager);
		Map.WallLayer[2, 1].MapObject = new Wall(spriteManager);
		Map.InteractLayer[4, 2].MapObject =
			new PickupItem(randomItemGenerator.Generate(RandomItemGenerator.Type.Tier1));
		Map.InteractLayer[5, 1].MapObject = new LevelExit(spriteManager, this);
		Map.InteractLayer[3, 1].MapObject = new PlayerPuppet(spriteManager);
		Map.MovePlayer(new(3, 1));
		Camera.CenterOn(Player.Position);
	}

	Camera Camera { get; }
	UICamera UICamera { get; }
	Player Player { get; }
	GameMap Map { get; }
	FightManager FightManager { get; }
	TextObject LevelText { get; }
	int CurrentLevel { get; set; }

	public void NextLevel()
	{
		CurrentLevel++;
		Player.Stats.FullHeal();
		// TODO: Generate random map
		Camera.CenterOn(Player.Position);
		if (CurrentLevel == 4)
			; // TODO: Map.InteractLayer[Map.ExitPosition.X, Map.ExitPosition.Y] = ToutetsuUnit().Generate();
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
				Camera.CenterOn(Player.Position);

		if (e is MouseWheelEvent mouseWheelEvent)
			if (mouseWheelEvent.Scroll.Y > 0)
				Camera.ZoomIn();
			else if (mouseWheelEvent.Scroll.Y < 0)
				Camera.ZoomOut();

		if (e is MouseMotionEvent mouseMotionEvent)
			if (mouseMotionEvent.RightButton)
				Camera.Position -= mouseMotionEvent.RelativeMotion / Camera.Scale;
	}
}
