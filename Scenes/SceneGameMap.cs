using Rokuro;
using Rokuro.Graphics;
using Rokuro.Input;
using Rokuro.Math;
using Rokuro.Objects;
using Toutetsu.Components;
using Toutetsu.Map;
using Toutetsu.State;

namespace Toutetsu.Scenes;

public class SceneGameMap : Scene
{
	public SceneGameMap()
	{
		// Variable init
		Name = "SceneGameMap";
		LevelText = new TextObject("Level 1", Camera);
		Map = new GameMap(Camera, 40);

		// Camera boundaries
		Camera.BoundaryMin = new Vector2D(-GameMap.TileSize, -GameMap.TileSize);
		Camera.BoundaryMax = new Vector2D(GameMap.TileSize * (Map.MapSize + 1),
			GameMap.TileSize * (Map.MapSize + 1));

		// Map
		NextLevel();
		RegisterGameObject(Map);

		// Inventory
		var inventoryBackground = new SimpleObject(App.GetSprite("equipment_bg"), UICamera);
		inventoryBackground.Position = new Vector2D(912, 0);
		RegisterGameObject(inventoryBackground);

		var inventoryView = new InventoryView(GameState.Inventory, UICamera);
		inventoryView.Position = new Vector2D(912, 0);
		RegisterGameObject(inventoryView);

		// TODO: Generate starting items

		// Stats
		var statsTextLeft = new TextObject("StatsLeft", UICamera);
		statsTextLeft.Position = new Vector2D(970, 240);
		RegisterGameObject(statsTextLeft);

		var statsTextRight = new TextObject("StatsRight", UICamera);
		statsTextRight.Position = new Vector2D(1082, 264);
		RegisterGameObject(statsTextRight);

		GameState.PlayerStats.AddViewSprites(statsTextLeft, statsTextRight);

		// Level text
		LevelText.Position = new Vector2D(800, 10);
		RegisterGameObject(LevelText);

		// Key controls
		App.InputManager.SetKeyEvent(Keycode.SDLK_s, KeyEvents.MoveDown);
		App.InputManager.SetKeyEvent(Keycode.SDLK_w, KeyEvents.MoveUp);
		App.InputManager.SetKeyEvent(Keycode.SDLK_a, KeyEvents.MoveLeft);
		App.InputManager.SetKeyEvent(Keycode.SDLK_d, KeyEvents.MoveRight);
		App.InputManager.SetKeyEvent(Keycode.SDLK_r, KeyEvents.CenterCamera);
	}

	Camera Camera { get; } = new();
	UICamera UICamera { get; } = new();
	GameMap Map { get; }
	TextObject LevelText { get; }

	public void NextLevel()
	{
		GameState.CurrentLevel++;
		GameState.HealPlayer();
		// TODO: Generate random map
		// TODO: Camera.CenterOn(Map.Player.Position);
		if (GameState.CurrentLevel == 4)
			; // TODO: Map.AddInteract(ToutetsuUnit().Generate(), Map.ExitPosition);
		LevelText.Text = $"Level {GameState.CurrentLevel}";
	}
}
