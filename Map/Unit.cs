using Toutetsu.Enemies;
using Toutetsu.State;

namespace Toutetsu.Map;

public class Unit(EnemyData enemyData, FightManager fightManager) : MapObject(enemyData.MapSprite)
{
	protected EnemyData EnemyData { get; } = enemyData;
	protected FightManager FightManager { get; } = fightManager;

	public override bool OnInteract(Player player)
	{
		FightManager.StartFight(EnemyData, false);
		return false;
	}
}
