using Rokuro.Graphics;
using Toutetsu.Enemies;
using Toutetsu.Items;
using Toutetsu.Loaders;

namespace Toutetsu.State;

public class FightManager
{
	public FightManager(SceneManager sceneManager)
	{
		SceneManager = sceneManager;
	}

	SceneManager SceneManager { get; }

	public void StartFight(EnemyData enemyData, bool bossFight)
	{
		SceneManager.SetNextScene((int)SceneID.Fight);
		// TODO: SceneFight.SetupFight(enemyData, Inventory);
		// TODO: SceneFight.BossFight = bossFight;
	}

	public void DoPlayerAttack(StatsSet spellStats)
	{
		// TODO: SceneFight.LockSpells();
		// TODO: SceneFight.EnemyStats.maxHP = GameState.PlayerStats.DealDamage(spellStats, SceneFight.EnemyStats);
		// TODO: SceneFight.AttackAnimationEnemy.sprite.play(SceneFight.ChangeTurnCallback, SceneFight);
	}

	public void DoEnemyAttack()
	{
		// TODO: PlayerStats.TakeDamage(SceneFight.EnemyStats);
		// TODO: SceneFight.AttackAnimationPlayer.sprite.play(SceneFight.ChangeTurnCallback, SceneFight);
	}
}
