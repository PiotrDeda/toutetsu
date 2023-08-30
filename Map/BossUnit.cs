using Toutetsu.Enemies;
using Toutetsu.State;

namespace Toutetsu.Map;

public class BossUnit : Unit
{
	public BossUnit(EnemyData enemyData) : base(enemyData) {}

	public override bool OnInteract()
	{
		GameState.StartFight(EnemyData, true);
		return false;
	}
}
