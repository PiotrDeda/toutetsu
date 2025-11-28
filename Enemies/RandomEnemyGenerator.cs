using Rokuro.Core;
using static Toutetsu.Enemies.RandomEnemyGenerator.Type;

namespace Toutetsu.Enemies;

public class RandomEnemyGenerator(EnemyRegister enemyRegister)
{
	public enum Type
	{
		Tier1,
		Tier2,
		Tier3,
		Tier4,
		Boss
	}

	EnemyRegister EnemyRegister { get; } = enemyRegister;

	Dictionary<Type, List<string>> Enemies { get; } = new() {
		{
			Tier1, ["green_slime", "blue_beholder"]
		}, {
			Tier2, ["blue_slime", "orange_beholder"]
		}, {
			Tier3, ["purple_slime", "pink_beholder"]
		}, {
			Tier4, ["fire_slime", "lava_beholder"]
		}, {
			Boss, ["toutetsu"]
		}
	};

	public EnemyData Generate(Type type) => EnemyRegister.GetEnemy(Enemies[type][RNG.Rand.Next(Enemies[type].Count)]);

	public Type GetTypeFromLevel(int currentLevel)
	{
		int tierPercentage = RNG.Rand.Next(100);
		return currentLevel switch {
			1 => tierPercentage switch {
				< 80 => Tier1,
				< 99 => Tier2,
				_ => Tier3
			},
			2 => tierPercentage switch {
				< 10 => Tier1,
				< 90 => Tier2,
				< 99 => Tier3,
				_ => Tier4
			},
			3 => tierPercentage switch {
				< 1 => Tier1,
				< 10 => Tier2,
				< 90 => Tier3,
				_ => Tier4
			},
			4 => tierPercentage switch {
				< 1 => Tier2,
				< 20 => Tier3,
				_ => Tier4
			},
			_ => Tier4
		};
	}
}
