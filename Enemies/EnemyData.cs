using JetBrains.Annotations;
using Rokuro.Core;
using Rokuro.Graphics;
using Tomlyn;
using Toutetsu.Items;

namespace Toutetsu.Enemies;

public record EnemyData(string Id, string DisplayName, ISprite MapSprite, ISprite FightSprite, StatsSet Stats)
{
	public static Dictionary<string, EnemyData> FromToml(string toml, SpriteManager spriteManager)
	{
		TomlModel model;
		try
		{
			model = Toml.ToModel<TomlModel>(toml);
		}
		catch (Exception e)
		{
			Logger.ThrowError($"Couldn't load enemies: {e.Message}");
			return new();
		}

		Dictionary<string, EnemyData> enemies = new();
		foreach (TomlEnemyModel enemyModel in model.Enemies)
		{
			if (enemyModel.Id is null)
			{
				Logger.LogWarning("Found enemy item with missing id");
				continue;
			}

			enemies.Add(enemyModel.Id, enemyModel.ToEnemyData(spriteManager));
		}

		return enemies;
	}

	class TomlModel
	{
		[UsedImplicitly] public List<TomlEnemyModel> Enemies { get; set; } = new();
	}

	class TomlEnemyModel
	{
		[UsedImplicitly] public string? Id { get; set; }
		[UsedImplicitly] public string DisplayName { get; set; } = "";
		[UsedImplicitly] public string? MapSprite { get; set; }
		[UsedImplicitly] public string? FightSprite { get; set; }
		[UsedImplicitly] public int MaxHP { get; set; }
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
			new(MaxHP, WhiteAttack, BlackAttack, WhiteDefense, BlackDefense, CritChance, Agility)
		);
	}
}
