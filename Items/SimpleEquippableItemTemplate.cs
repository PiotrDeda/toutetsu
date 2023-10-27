using JetBrains.Annotations;
using Rokuro.Core;
using Rokuro.Graphics;
using Tomlyn;

namespace Toutetsu.Items;

public class SimpleEquippableItemTemplate : IItemTemplate
{
	public SimpleEquippableItemTemplate(ISprite sprite, ItemType type, StatsSet means, StatsSet deviations,
		RNG rng)
	{
		Sprite = sprite;
		Type = type;
		Means = means;
		Deviations = deviations;
		RNG = rng;
	}

	RNG RNG { get; }
	ISprite Sprite { get; }
	ItemType Type { get; }
	StatsSet Means { get; }
	StatsSet Deviations { get; }

	public ItemData Create() => new SimpleEquippableItem(Sprite, Type, new(
		RNG.NextStandardInt(Means.MaxHP, Deviations.MaxHP),
		RNG.NextStandardInt(Means.WhiteAttack, Deviations.WhiteAttack),
		RNG.NextStandardInt(Means.BlackAttack, Deviations.BlackAttack),
		RNG.NextStandardInt(Means.WhiteDefense, Deviations.WhiteDefense),
		RNG.NextStandardInt(Means.BlackDefense, Deviations.BlackDefense),
		RNG.NextStandardInt(Means.CritChance, Deviations.CritChance),
		RNG.NextStandardInt(Means.Agility, Deviations.Agility)
	));

	public static Dictionary<string, IItemTemplate> FromToml(string toml, ItemType type, SpriteManager spriteManager,
		RNG rng)
	{
		TomlModel model;
		try
		{
			model = Toml.ToModel<TomlModel>(toml);
		}
		catch (Exception e)
		{
			Logger.ThrowError($"Couldn't load equippable items: {e.Message}");
			return new();
		}

		Dictionary<string, IItemTemplate> itemTemplates = new();
		foreach (TomlItemModel itemModel in model.Items)
		{
			if (itemModel.Id is null)
			{
				Logger.LogWarning("Found equippable item with missing id");
				continue;
			}

			itemTemplates.Add(itemModel.Id, itemModel.ToItemTemplate(type, spriteManager, rng));
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
		[UsedImplicitly] public List<int> CritChance { get; set; } = new() { 0, 0 };
		[UsedImplicitly] public List<int> Agility { get; set; } = new() { 0, 0 };

		public SimpleEquippableItemTemplate ToItemTemplate(ItemType type, SpriteManager spriteManager,
			RNG rng) => new(
			spriteManager.CreateSprite<StaticSprite>(Id ?? throw new InvalidOperationException()), type,
			new(MaxHP[0], WhiteAttack[0], BlackAttack[0], WhiteDefense[0], BlackDefense[0], CritChance[0], Agility[0]),
			new(MaxHP[1], WhiteAttack[1], BlackAttack[1], WhiteDefense[1], BlackDefense[1], CritChance[1], Agility[1]),
			rng
		);
	}
}
