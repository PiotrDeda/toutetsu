using Toutetsu.Enemies;
using Toutetsu.State;

namespace Toutetsu.Map;

public class BossUnit : Unit
{
	public BossUnit(EnemyData enemyData, FightManager fightManager) : base(enemyData, fightManager) {}

	public override bool OnInteract(Player player)
	{
		FightManager.StartFight(EnemyData, true);
		return false;
	}
}
