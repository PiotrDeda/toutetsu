using JetBrains.Annotations;
using Rokuro.Core;
using Rokuro.Graphics;
using Toutetsu.Items;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Toutetsu.Enemies;

public record EnemyData(string Id, string DisplayName, ISprite MapSprite, ISprite FightSprite, StatsSet Stats)
{
	public static Dictionary<string, EnemyData> FromYaml(string yaml, SpriteManager spriteManager)
	{
		List<YamlEnemyModel> yamlEnemies;
		try
		{
			yamlEnemies = new DeserializerBuilder()
				.WithNamingConvention(UnderscoredNamingConvention.Instance)
				.Build()
				.Deserialize<List<YamlEnemyModel>>(yaml);
		}
		catch (Exception e)
		{
			Logger.ThrowError($"Couldn't load enemies: {e.Message}");
			return new();
		}

		Dictionary<string, EnemyData> enemies = new();
		foreach (YamlEnemyModel enemyModel in yamlEnemies)
		{
			if (enemyModel.Id == null)
			{
				Logger.LogWarning("Found enemy item with missing id");
				continue;
			}

			enemies.Add(enemyModel.Id, enemyModel.ToEnemyData(spriteManager));
		}

		return enemies;
	}

	class YamlEnemyModel
	{
		[UsedImplicitly] public string? Id { get; set; }
		[UsedImplicitly] public string DisplayName { get; set; } = "";
		[UsedImplicitly] public string? MapSprite { get; set; }
		[UsedImplicitly] public string? FightSprite { get; set; }
		[UsedImplicitly] public int MaxHp { get; set; }
		[UsedImplicitly] public int WhiteAttack { get; set; }
		[UsedImplicitly] public int BlackAttack { get; set; }
		[UsedImplicitly] public int WhiteDefense { get; set; }
		[UsedImplicitly] public int BlackDefense { get; set; }
		[UsedImplicitly] public int CritChance { get; set; }
		[UsedImplicitly] public int Agility { get; set; }

		public EnemyData ToEnemyData(SpriteManager spriteManager) => new(
			Id!, DisplayName,
			spriteManager.CreateSprite<StaticSprite>(MapSprite ?? Id ?? throw new InvalidOperationException()),
			spriteManager.CreateSprite<StaticSprite>(FightSprite ?? Id ?? throw new InvalidOperationException()),
			new(MaxHp, WhiteAttack, BlackAttack, WhiteDefense, BlackDefense, CritChance, Agility)
		);
	}
}
