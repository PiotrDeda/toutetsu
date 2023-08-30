using Toutetsu.Enemies;
using Toutetsu.State;

namespace Toutetsu.Map;

public class Unit : MapObject
{
	public Unit(EnemyData enemyData) : base(enemyData.MapSprite)
	{
		EnemyData = enemyData;
	}

	protected EnemyData EnemyData { get; }

	public override bool OnInteract()
	{
		GameState.StartFight(EnemyData, false);
		return false;
	}
}
