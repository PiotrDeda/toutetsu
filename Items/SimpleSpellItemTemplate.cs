using JetBrains.Annotations;
using Rokuro.Core;
using Rokuro.Graphics;
using Tomlyn;

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

	public static Dictionary<string, IItemTemplate> FromToml(string toml, SpriteManager spriteManager)
	{
		TomlModel model;
		try
		{
			model = Toml.ToModel<TomlModel>(toml);
		}
		catch (Exception e)
		{
			Logger.ThrowError($"Couldn't load spells: {e.Message}");
			return new();
		}

		Dictionary<string, IItemTemplate> itemTemplates = new();
		foreach (TomlItemModel itemModel in model.Items)
		{
			if (itemModel.Id is null)
			{
				Logger.LogWarning("Found spell with missing id");
				continue;
			}

			itemTemplates.Add(itemModel.Id, itemModel.ToItemTemplate(spriteManager));
		}

		return itemTemplates;
	}

	class TomlModel
	{
		[UsedImplicitly] public List<TomlItemModel> Items { get; set; } = new();
	}

	class TomlItemModel
	{
		[UsedImplicitly] public string? Id { get; set; }
		[UsedImplicitly] public int WhiteAttack { get; set; }
		[UsedImplicitly] public int BlackAttack { get; set; }
		[UsedImplicitly] public int CritChance { get; set; }

		public SimpleSpellItemTemplate ToItemTemplate(SpriteManager spriteManager) =>
			new(spriteManager.CreateSpriteFromTemplate(Id ?? throw new InvalidOperationException()),
				StatsSet.SpellStats(WhiteAttack, BlackAttack, CritChance));
	}
}
