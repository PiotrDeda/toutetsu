using Rokuro.Graphics;
using Toutetsu.Enemies;
using Toutetsu.Items;
using Toutetsu.Loaders;

namespace Toutetsu.State;

public class FightManager
{
	public FightManager(SceneManager sceneManager, Player player)
	{
		SceneManager = sceneManager;
		Player = player;
	}

	public EnemyData Enemy { get; private set; } = null!;
	public bool IsPlayerTurn { get; private set; } = true;

	SceneManager SceneManager { get; }
	Player Player { get; }
	bool IsBossFight { get; set; }
	int EnemyHP { get; set; }
	int PlayerTurnCount { get; set; }
	int EnemyTurnCount { get; set; }

	public void StartFight(EnemyData enemyData, bool isBossFight)
	{
		Enemy = enemyData;
		IsBossFight = isBossFight;
		EnemyHP = Enemy.Stats.MaxHP;
		PlayerTurnCount = Player.Stats.CurrentStats.Agility;
		DoPlayerTurn();
		SceneManager.SetNextScene((int)SceneID.Fight);
	}

	public void DoPlayerAttack(StatsSet spellStats)
	{
		EnemyHP -= Player.Stats.DealDamage(spellStats, Enemy.Stats);
		// TODO: SceneFight.AttackAnimationEnemy.sprite.play(SceneFight.ChangeTurnCallback, SceneFight);
		ChangeTurn();
	}

	void DoEnemyAttack()
	{
		Player.Stats.TakeDamage(Enemy.Stats);
		// TODO: SceneFight.AttackAnimationPlayer.sprite.play(SceneFight.ChangeTurnCallback, SceneFight);
		ChangeTurn();
	}

	void ChangeTurn()
	{
		if (Player.Stats.CurrentHP <= 0)
		{
			SceneManager.SetNextScene((int)SceneID.Lose);
			return;
		}

		if (EnemyHP <= 0)
		{
			// TODO: Generate random item
			SceneManager.SetNextScene((int)SceneID.GameMap);
			if (IsBossFight)
				SceneManager.SetNextScene((int)SceneID.Win);
			return;
		}

		if (IsPlayerTurn)
			if (--PlayerTurnCount <= 0)
				DoEnemyTurn();
			else
				DoPlayerTurn();
		else if (--EnemyTurnCount <= 0)
			DoPlayerTurn();
		else
			DoEnemyTurn();
	}

	void DoPlayerTurn()
	{
		IsPlayerTurn = true;
		EnemyTurnCount = Enemy.Stats.Agility;
	}

	void DoEnemyTurn()
	{
		IsPlayerTurn = false;
		PlayerTurnCount = Player.Stats.CurrentStats.Agility;
		DoEnemyAttack();
	}
}
