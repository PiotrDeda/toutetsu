using Rokuro;
using Toutetsu.Enemies;
using Toutetsu.Items;
using Toutetsu.Loaders;
using Toutetsu.Scenes;

namespace Toutetsu.State;

class GameStateInstance
{
	public int CurrentLevel { get; set; } = 0;
	public PlayerStats PlayerStats { get; } = new();
	public Inventory Inventory { get; } = new();
	public SceneGameMap SceneGameMap { private get; set; } = null!;
	public SceneFight SceneFight { private get; set; } = null!;

	public void NextLevel()
	{
		//SceneGameMap.NextLevel();
	}

	public void StartFight(EnemyData enemyData, bool bossFight)
	{
		App.SceneManager.SetNextScene((int)SceneID.Fight);
		//SceneFight.SetupFight(enemyData, Inventory);
		//SceneFight.BossFight = bossFight;
	}

	public void DoPlayerAttack(StatsSet spellStats)
	{
		//SceneFight.LockSpells();
		//SceneFight.EnemyStats.maxHP = GameState.PlayerStats.DealDamage(spellStats, SceneFight.EnemyStats);
		//SceneFight.AttackAnimationEnemy.sprite.play(SceneFight.ChangeTurnCallback, SceneFight);
	}

	public void DoEnemyAttack()
	{
		//PlayerStats.TakeDamage(SceneFight.EnemyStats);
		//SceneFight.AttackAnimationPlayer.sprite.play(SceneFight.ChangeTurnCallback, SceneFight);
	}

	public void HealPlayer() => PlayerStats.CurrentHP = PlayerStats.CurrentStats.MaxHP;
}
