using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Input;
using Rokuro.Objects;
using Toutetsu.Components;
using Toutetsu.Items;
using Toutetsu.Map;
using Toutetsu.State;

namespace Toutetsu.Scenes;

public class SceneGameMap : Scene
{
	public SceneGameMap()
	{
		// Variable init
		Name = "SceneGameMap";
		LevelText = new("Level 1", UICamera);
		Map = new(Camera, 40);

		// Camera boundaries
		Camera.BoundaryMin = new(-GameMap.TileSize, -GameMap.TileSize);
		Camera.BoundaryMax = new(GameMap.TileSize * (Map.MapSize + 1), GameMap.TileSize * (Map.MapSize + 1));

		// Map
		NextLevel();
		RegisterGameObject(Map);

		// Inventory
		SimpleObject inventoryBackground = new(App.SpriteManager.CreateSpriteFromTemplate("equipment_bg"), UICamera);
		inventoryBackground.Position = new(912, 0);
		RegisterGameObject(inventoryBackground);

		InventoryView inventoryView = new(GameState.Inventory, UICamera);
		inventoryView.Position = new(912, 0);
		RegisterGameObject(inventoryView);

		// TODO: Generate starting items

		// Stats
		TextObject statsTextLeft = new("StatsLeft", UICamera);
		statsTextLeft.Position = new(970, 240);
		RegisterGameObject(statsTextLeft);

		TextObject statsTextRight = new("StatsRight", UICamera);
		statsTextRight.Position = new(1082, 264);
		RegisterGameObject(statsTextRight);

		GameState.PlayerStats.AddViewSprites(statsTextLeft, statsTextRight);

		// Level text
		LevelText.Position = new(800, 10);
		RegisterGameObject(LevelText);

		// Key controls
		App.InputManager.SetKeyEvent(Keycode.SDLK_s, KeyEvents.MoveDown);
		App.InputManager.SetKeyEvent(Keycode.SDLK_w, KeyEvents.MoveUp);
		App.InputManager.SetKeyEvent(Keycode.SDLK_a, KeyEvents.MoveLeft);
		App.InputManager.SetKeyEvent(Keycode.SDLK_d, KeyEvents.MoveRight);
		App.InputManager.SetKeyEvent(Keycode.SDLK_r, KeyEvents.CenterCamera);

		// Debug
		// TODO: Remove when map generation is done
		Floor floor = new();
		Map.FloorLayer[3, 1].MapObject = floor;
		Map.FloorLayer[4, 1].MapObject = floor;
		Map.WallLayer[1, 1].MapObject = new WallTorch();
		Map.WallLayer[2, 1].MapObject = new Wall();
		Map.InteractLayer[3, 1].MapObject = new PlayerPuppet();
		Map.PlayerPosition = new(3, 1);
		ItemRegister.LoadItemData(); // TODO: Move somewhere else
		GameState.Inventory.AddItem(RandomItemGenerator.Generate(RandomItemGenerator.Type.StartingWeapon));
		GameState.Inventory.AddItem(RandomItemGenerator.Generate(RandomItemGenerator.Type.StartingSpell));
	}

	Camera Camera { get; } = new();
	UICamera UICamera { get; } = new();
	GameMap Map { get; }
	TextObject LevelText { get; }

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
				Camera.CenterOn(Map.PlayerPosition);

		if (e is MouseWheelEvent mouseWheelEvent)
			if (mouseWheelEvent.Scroll.Y > 0)
				Camera.ZoomIn();
			else if (mouseWheelEvent.Scroll.Y < 0)
				Camera.ZoomOut();

		if (e is MouseMotionEvent mouseMotionEvent)
			if (mouseMotionEvent.RightButton)
				Camera.Position -= mouseMotionEvent.RelativeMotion / Camera.Scale;
	}

	public void NextLevel()
	{
		GameState.CurrentLevel++;
		GameState.HealPlayer();
		// TODO: Generate random map
		Camera.CenterOn(Map.PlayerPosition);
		if (GameState.CurrentLevel == 4)
			; // TODO: Map.AddInteract(ToutetsuUnit().Generate(), Map.ExitPosition);
		LevelText.Text = $"Level {GameState.CurrentLevel}";
	}
}
