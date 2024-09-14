using Rokuro.Core;
using Rokuro.Inputs;
using Rokuro.Objects;
using Toutetsu.Enemies;
using Toutetsu.Items;
using Toutetsu.Scenes;
using Toutetsu.State;

namespace Toutetsu;

public static class Toutetsu
{
	static void Main()
	{
		App.Setup(new("Toutetsu", new(46, 48, 48), 1280, 720));
		Init();
		App.Run();
	}

	static void Init()
	{
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
		((SceneFight)SceneManager.GetScene("Fight")).Init(player, fightManager, itemRegister);
		SceneManager.LoadScenes(new() { new SceneGameMap(randomItemGenerator, randomEnemyGenerator, player, fightManager) });
		SceneManager.SetNextScene("Main Menu");

		// Input
		Input.SetKeyEvent(Keycode.S, KeyEvents.MoveDown);
		Input.SetKeyEvent(Keycode.W, KeyEvents.MoveUp);
		Input.SetKeyEvent(Keycode.A, KeyEvents.MoveLeft);
		Input.SetKeyEvent(Keycode.D, KeyEvents.MoveRight);
		Input.SetKeyEvent(Keycode.R, KeyEvents.CenterCamera);
	}
}
