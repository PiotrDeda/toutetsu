using JetBrains.Annotations;
using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.MathUtils;
using Tomlyn;

namespace Toutetsu.Items;

public class SimpleEquippableItemTemplate : IItemTemplate
{
	public SimpleEquippableItemTemplate(string spriteName, ItemType type, StatsSet means, StatsSet deviations)
	{
		Sprite = App.SpriteManager.CreateSpriteFromTemplate(spriteName);
		Type = type;
		Means = means;
		Deviations = deviations;
	}

	ISprite Sprite { get; }
	ItemType Type { get; }
	StatsSet Means { get; }
	StatsSet Deviations { get; }

	public ItemData Create() => new SimpleEquippableItem(Sprite, Type,
		RandomUtils.NextStandardInt(Means.MaxHP, Deviations.MaxHP),
		RandomUtils.NextStandardInt(Means.WhiteAttack, Deviations.WhiteAttack),
		RandomUtils.NextStandardInt(Means.BlackAttack, Deviations.BlackAttack),
		RandomUtils.NextStandardInt(Means.WhiteDefense, Deviations.WhiteDefense),
		RandomUtils.NextStandardInt(Means.BlackDefense, Deviations.BlackDefense),
		RandomUtils.NextStandardInt(Means.CritChance, Deviations.CritChance),
		RandomUtils.NextStandardInt(Means.Agility, Deviations.Agility)
	);

	public static Dictionary<string, IItemTemplate> FromToml(string toml, ItemType type)
	{
		TomlModel model;
		try
		{
			model = Toml.ToModel<TomlModel>(toml);
		}
		catch (Exception e)
		{
			Logger.ThrowError($"Couldn't load items: {e.Message}");
			return new();
		}

		Dictionary<string, IItemTemplate> itemTemplates = new();
		foreach (TomlItemModel itemModel in model.Items)
		{
			if (itemModel.Id is null)
			{
				Logger.LogWarning("Found item with missing id");
				continue;
			}

			itemTemplates.Add(itemModel.Id, itemModel.ToItemTemplate(type));
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
		[UsedImplicitly] public List<int> MaxHP { get; set; } = new() { 0, 0 };
		[UsedImplicitly] public List<int> WhiteAttack { get; set; } = new() { 0, 0 };
		[UsedImplicitly] public List<int> BlackAttack { get; set; } = new() { 0, 0 };
		[UsedImplicitly] public List<int> WhiteDefense { get; set; } = new() { 0, 0 };
		[UsedImplicitly] public List<int> BlackDefense { get; set; } = new() { 0, 0 };
		[UsedImplicitly] public List<int> Crit { get; set; } = new() { 0, 0 };
		[UsedImplicitly] public List<int> Agility { get; set; } = new() { 0, 0 };

		public SimpleEquippableItemTemplate ToItemTemplate(ItemType type) =>
			new(Id ?? throw new InvalidOperationException(), type,
				new(MaxHP[0], WhiteAttack[0], BlackAttack[0], WhiteDefense[0], BlackDefense[0], Crit[0], Agility[0]),
				new(MaxHP[1], WhiteAttack[1], BlackAttack[1], WhiteDefense[1], BlackDefense[1], Crit[1], Agility[1])
			);
	}
}
