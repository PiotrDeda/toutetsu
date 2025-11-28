using Toutetsu.Enemies;
using Toutetsu.State;

namespace Toutetsu.Map;

public class BossUnit(EnemyData enemyData, FightManager fightManager) : Unit(enemyData, fightManager)
{
	public override bool OnInteract(Player player)
	{
		FightManager.StartFight(EnemyData, true);
		return false;
	}
}
