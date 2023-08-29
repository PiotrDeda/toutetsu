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
		GameMap = new GameMap(Camera, 40);

		// Camera boundaries
		Camera.BoundaryMin = new Vector(-GameMap.TileSize, -GameMap.TileSize);
		Camera.BoundaryMax = new Vector(GameMap.TileSize * (GameMap.MapSize + 1),
			GameMap.TileSize * (GameMap.MapSize + 1));

		// Map
		NextLevel();
		RegisterGameObject(GameMap);

		// Inventory
		var inventoryBackground = new SimpleObject(App.GetSprite("equipment_bg"), UICamera);
		inventoryBackground.Position = new Vector(912, 0);
		RegisterGameObject(inventoryBackground);
		
		var inventoryView = new InventoryView(GameState.Inventory, UICamera);
		inventoryView.Position = new Vector(912, 0);
		RegisterGameObject(inventoryView);
        
		// TODO: Generate starting items

		// Stats
		var statsTextLeft = new TextObject("StatsLeft", UICamera);
		statsTextLeft.Position = new Vector(970, 240);
		RegisterGameObject(statsTextLeft);

		var statsTextRight = new TextObject("StatsRight", UICamera);
		statsTextRight.Position = new Vector(1082, 264);
		RegisterGameObject(statsTextRight);

		GameState.PlayerStats.AddViewSprites(statsTextLeft, statsTextRight);

		// Level text
		LevelText.Position = new Vector(800, 10);
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
	GameMap GameMap { get; }
	TextObject LevelText { get; }

	void NextLevel()
	{
		// TODO
	}
}
