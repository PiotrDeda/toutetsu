using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Inputs;
using Toutetsu.Enemies;
using Toutetsu.Items;
using Toutetsu.Loaders;
using Toutetsu.Scenes;
using Toutetsu.State;

namespace Toutetsu;

public class Toutetsu : Project
{
	static void Main()
	{
		App.SetupAndRun(new Toutetsu(), new("Toutetsu", new(46, 48, 48), 1280, 720));
	}

	public override void Init()
	{
		// Sprites
		SpriteManager.LoadSpriteTemplates(SpriteTemplateLoader.GetSpriteTemplates());

		// Items
		ItemRegister itemRegister = new();
		itemRegister.LoadItemData();
		RandomItemGenerator randomItemGenerator = new(itemRegister);

		// Enemies
		EnemyRegister enemyRegister = new();
		enemyRegister.LoadEnemyData();
		RandomEnemyGenerator randomEnemyGenerator = new(enemyRegister);

		// Misc
		Player player = new();
		FightManager fightManager = new(player);

		// Scenes
		List<Scene> scenes = new();

		scenes.Add(new SceneMainMenu());
		scenes.Add(new SceneGameMap(randomItemGenerator, randomEnemyGenerator, player, fightManager));
		scenes.Add(new SceneFight(player, fightManager, itemRegister));
		scenes.Add(new SceneWin());
		scenes.Add(new SceneLose());

		SceneManager.LoadScenes(scenes);

		// Input
		Input.SetKeyEvent(Keycode.SDLK_s, KeyEvents.MoveDown);
		Input.SetKeyEvent(Keycode.SDLK_w, KeyEvents.MoveUp);
		Input.SetKeyEvent(Keycode.SDLK_a, KeyEvents.MoveLeft);
		Input.SetKeyEvent(Keycode.SDLK_d, KeyEvents.MoveRight);
		Input.SetKeyEvent(Keycode.SDLK_r, KeyEvents.CenterCamera);
	}
}
