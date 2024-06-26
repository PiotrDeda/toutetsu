using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Enemies;
using Toutetsu.Items;

namespace Toutetsu.State;

public class FightManager
{
	public FightManager(Player player)
	{
		Player = player;
	}

	public EnemyData Enemy { get; private set; } = null!;
	public PlayableSprite PlayerAttackAnimation { get; set; } = null!;
	public PlayableSprite EnemyAttackAnimation { get; set; } = null!;
	public bool IsPlayerTurn { get; private set; } = true;
	public bool IsSpellCastingEnabled { get; set; } = true;

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
		SceneManager.SetNextScene("Fight");
		DoPlayerTurn();
	}

	public void DoPlayerAttack(StatsSet spellStats)
	{
		EnemyHP -= Player.Stats.DealDamage(spellStats, Enemy.Stats);
		IsSpellCastingEnabled = false;
		EnemyAttackAnimation.Play(ChangeTurn);
	}

	void DoEnemyAttack()
	{
		Player.Stats.TakeDamage(Enemy.Stats);
		PlayerAttackAnimation.Play(ChangeTurn);
	}

	void ChangeTurn()
	{
		if (Player.Stats.CurrentHP <= 0)
		{
			SceneManager.SetNextScene("Lose");
			return;
		}

		if (EnemyHP <= 0)
		{
			// TODO: Generate random item
			SceneManager.SetNextScene("Game Map");
			if (IsBossFight)
				SceneManager.SetNextScene("Win");
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
		IsSpellCastingEnabled = true;
		EnemyTurnCount = Enemy.Stats.Agility;
	}

	void DoEnemyTurn()
	{
		IsPlayerTurn = false;
		PlayerTurnCount = Player.Stats.CurrentStats.Agility;
		DoEnemyAttack();
	}
}
