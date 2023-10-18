using Rokuro.Core;
using static Toutetsu.Enemies.RandomEnemyGenerator.Type;

namespace Toutetsu.Enemies;

public class RandomEnemyGenerator
{
	public enum Type
	{
		Tier1,
		Tier2,
		Tier3,
		Tier4,
		Boss
	}

	public RandomEnemyGenerator(EnemyRegister enemyRegister, RNG rng)
	{
		EnemyRegister = enemyRegister;
		RNG = rng;
	}

	EnemyRegister EnemyRegister { get; }
	RNG RNG { get; }

	Dictionary<Type, List<string>> Enemies { get; } = new() {
		{
			Tier1, new() {
				"green_slime", "blue_beholder"
			}
		}, {
			Tier2, new() {
				"blue_slime", "orange_beholder"
			}
		}, {
			Tier3, new() {
				"purple_slime", "pink_beholder"
			}
		}, {
			Tier4, new() {
				"fire_slime", "lava_beholder"
			}
		}, {
			Boss, new() {
				"toutetsu"
			}
		}
	};

	public EnemyData Generate(Type type) => EnemyRegister.GetEnemy(Enemies[type][RNG.Rand.Next(Enemies[type].Count)]);

	public Type GetTypeFromLevel(int currentLevel)
	{
		int tierPercentage = RNG.Rand.Next(100);
		switch (currentLevel)
		{
			case 1:
				if (tierPercentage < 80)
					return Tier1;
				if (tierPercentage < 99)
					return Tier2;
				return Tier3;
			case 2:
				if (tierPercentage < 10)
					return Tier1;
				if (tierPercentage < 90)
					return Tier2;
				if (tierPercentage < 99)
					return Tier3;
				return Tier4;
			case 3:
				if (tierPercentage < 1)
					return Tier1;
				if (tierPercentage < 10)
					return Tier2;
				if (tierPercentage < 90)
					return Tier3;
				return Tier4;
			case 4:
				if (tierPercentage < 1)
					return Tier2;
				if (tierPercentage < 20)
					return Tier3;
				return Tier4;
			default:
				return Tier4;
		}
	}
}
