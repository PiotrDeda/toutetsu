using Toutetsu.Enemies;
using Toutetsu.State;

namespace Toutetsu.Map;

public class Unit : MapObject
{
	public Unit(EnemyData enemyData, FightManager fightManager) : base(enemyData.MapSprite)
	{
		EnemyData = enemyData;
		FightManager = fightManager;
	}

	protected EnemyData EnemyData { get; }
	protected FightManager FightManager { get; }

	public override bool OnInteract(Player player)
	{
		FightManager.StartFight(EnemyData, false);
		return false;
	}
}
