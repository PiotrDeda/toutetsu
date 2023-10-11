using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Inputs;
using Toutetsu.Items;
using Toutetsu.Loaders;
using Toutetsu.Scenes;
using Toutetsu.State;

namespace Toutetsu;

public class Toutetsu : App
{
	public Toutetsu(AppProperties properties) : base(properties) {}

	static void Main()
	{
		new Toutetsu(new("Toutetsu", new(46, 48, 48), 1280, 720)).Run();
	}

	public override void Init()
	{
		// Sprites
		SpriteManager.LoadSpriteTemplates(SpriteTemplateLoader.GetSpriteTemplates(SpriteManager));

		// Items
		ItemRegister itemRegister = new(SpriteManager, RNG);
		itemRegister.LoadItemData();
		RandomItemGenerator randomItemGenerator = new(itemRegister, RNG);

		// Scenes
		Player player = new(SpriteManager);
		FightManager fightManager = new(SceneManager);

		List<Scene> scenes = new();

		scenes.Add(new SceneMainMenu(SpriteManager, SceneManager, Drawer, WindowData, this));
		scenes.Add(new SceneGameMap(SpriteManager, Input, Drawer, WindowData, randomItemGenerator, player,
			fightManager));
		scenes.Add(new SceneFight(player, fightManager));
		scenes.Add(new SceneWin(SpriteManager, Drawer, WindowData, this));
		scenes.Add(new SceneLose(SpriteManager, Drawer, WindowData, this));

		SceneManager.LoadScenes(scenes);

		// Input
		Input.SetKeyEvent(Keycode.SDLK_s, KeyEvents.MoveDown);
		Input.SetKeyEvent(Keycode.SDLK_w, KeyEvents.MoveUp);
		Input.SetKeyEvent(Keycode.SDLK_a, KeyEvents.MoveLeft);
		Input.SetKeyEvent(Keycode.SDLK_d, KeyEvents.MoveRight);
		Input.SetKeyEvent(Keycode.SDLK_r, KeyEvents.CenterCamera);
	}
}
