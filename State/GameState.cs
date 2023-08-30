using Toutetsu.Enemies;
using Toutetsu.Items;
using Toutetsu.Scenes;

namespace Toutetsu.State;

public static class GameState
{
	static GameStateInstance Instance { get; } = new();

	public static PlayerStats PlayerStats => Instance.PlayerStats;
	public static Inventory Inventory => Instance.Inventory;
	public static int CurrentLevel
	{
		get => Instance.CurrentLevel;
		set => Instance.CurrentLevel = value;
	}

	public static void SetSceneGameMap(SceneGameMap scene) => Instance.SceneGameMap = scene;

	public static void SetSceneFight(SceneFight scene) => Instance.SceneFight = scene;

	public static void NextLevel() => Instance.NextLevel();

	public static void StartFight(EnemyData enemyData, bool bossFight) => Instance.StartFight(enemyData, bossFight);

	public static void DoPlayerAttack(StatsSet spellStats) => Instance.DoPlayerAttack(spellStats);

	public static void DoEnemyAttack() => Instance.DoEnemyAttack();

	public static void HealPlayer() => Instance.HealPlayer();
}
