using JetBrains.Annotations;
using Rokuro.Core;
using Rokuro.Graphics;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Toutetsu.Items;

public class SimpleSpellItemTemplate : IItemTemplate
{
	public SimpleSpellItemTemplate(ISprite sprite, StatsSet spellStats)
	{
		Sprite = sprite;
		SpellStats = spellStats;
	}

	ISprite Sprite { get; }
	StatsSet SpellStats { get; }

	public ItemData Create() => new SimpleSpellItem(Sprite, SpellStats);

	public static Dictionary<string, IItemTemplate> FromYaml(string yaml, SpriteManager spriteManager)
	{
		List<YamlSpellModel> yamlSpells;
		try
		{
			yamlSpells = new DeserializerBuilder()
				.WithNamingConvention(UnderscoredNamingConvention.Instance)
				.Build()
				.Deserialize<List<YamlSpellModel>>(yaml);
		}
		catch (Exception e)
		{
			Logger.ThrowError($"Couldn't load spells: {e.Message}");
			return new();
		}

		Dictionary<string, IItemTemplate> itemTemplates = new();
		foreach (YamlSpellModel spellModel in yamlSpells)
		{
			if (spellModel.Id == null)
			{
				Logger.LogWarning("Found spell with missing id");
				continue;
			}

			itemTemplates.Add(spellModel.Id, spellModel.ToItemTemplate(spriteManager));
		}

		return itemTemplates;
	}

	class YamlSpellModel
	{
		[UsedImplicitly] public string? Id { get; set; }
		[UsedImplicitly] public int WhiteAttack { get; set; }
		[UsedImplicitly] public int BlackAttack { get; set; }
		[UsedImplicitly] public int CritChance { get; set; }

		public SimpleSpellItemTemplate ToItemTemplate(SpriteManager spriteManager) =>
			new(spriteManager.CreateSprite<StaticSprite>(Id ?? throw new InvalidOperationException()),
				StatsSet.SpellStats(WhiteAttack, BlackAttack, CritChance));
	}
}
