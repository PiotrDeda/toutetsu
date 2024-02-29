using JetBrains.Annotations;
using Rokuro.Core;
using Rokuro.Graphics;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Toutetsu.Items;

public class SimpleEquippableItemTemplate : IItemTemplate
{
	public SimpleEquippableItemTemplate(ISprite sprite, ItemType type, StatsSet means, StatsSet deviations)
	{
		Sprite = sprite;
		Type = type;
		Means = means;
		Deviations = deviations;
	}

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

	public static Dictionary<string, IItemTemplate> FromYaml(string yaml)
	{
		YamlItemRegistryModel yamlItemRegistry;
		try
		{
			yamlItemRegistry = new DeserializerBuilder()
				.WithNamingConvention(UnderscoredNamingConvention.Instance)
				.Build()
				.Deserialize<YamlItemRegistryModel>(yaml);
		}
		catch (Exception e)
		{
			Logger.ThrowError($"Couldn't load equippable items: {e.Message}");
			return new();
		}

		Dictionary<string, IItemTemplate> itemTemplates = new();

		void LoadItems(List<YamlItemModel> yamlItems, ItemType type)
		{
			foreach (YamlItemModel itemModel in yamlItems)
			{
				if (itemModel.Id == null)
				{
					Logger.LogWarning("Found equippable item with missing id");
					continue;
				}

				itemTemplates.Add(itemModel.Id, itemModel.ToItemTemplate(type));
			}
		}

		LoadItems(yamlItemRegistry.Helmets, ItemType.Helmet);
		LoadItems(yamlItemRegistry.Armors, ItemType.Armor);
		LoadItems(yamlItemRegistry.Boots, ItemType.Boots);
		LoadItems(yamlItemRegistry.Trinkets, ItemType.Trinket);
		LoadItems(yamlItemRegistry.Shields, ItemType.Shield);
		LoadItems(yamlItemRegistry.Books, ItemType.Book);
		LoadItems(yamlItemRegistry.Weapons, ItemType.Weapon);

		return itemTemplates;
	}

	class YamlItemRegistryModel
	{
		[UsedImplicitly] public List<YamlItemModel> Helmets { get; set; } = new();
		[UsedImplicitly] public List<YamlItemModel> Armors { get; set; } = new();
		[UsedImplicitly] public List<YamlItemModel> Boots { get; set; } = new();
		[UsedImplicitly] public List<YamlItemModel> Trinkets { get; set; } = new();
		[UsedImplicitly] public List<YamlItemModel> Shields { get; set; } = new();
		[UsedImplicitly] public List<YamlItemModel> Books { get; set; } = new();
		[UsedImplicitly] public List<YamlItemModel> Weapons { get; set; } = new();
	}

	class YamlItemModel
	{
		[UsedImplicitly] public string? Id { get; set; }
		[UsedImplicitly] public List<int> MaxHp { get; set; } = new() { 0, 0 };
		[UsedImplicitly] public List<int> WhiteAttack { get; set; } = new() { 0, 0 };
		[UsedImplicitly] public List<int> BlackAttack { get; set; } = new() { 0, 0 };
		[UsedImplicitly] public List<int> WhiteDefense { get; set; } = new() { 0, 0 };
		[UsedImplicitly] public List<int> BlackDefense { get; set; } = new() { 0, 0 };
		[UsedImplicitly] public List<int> CritChance { get; set; } = new() { 0, 0 };
		[UsedImplicitly] public List<int> Agility { get; set; } = new() { 0, 0 };

		public SimpleEquippableItemTemplate ToItemTemplate(ItemType type) => new(
			SpriteManager.CreateSprite<StaticSprite>(Id ?? throw new InvalidOperationException()), type,
			new(MaxHp[0], WhiteAttack[0], BlackAttack[0], WhiteDefense[0], BlackDefense[0], CritChance[0], Agility[0]),
			new(MaxHp[1], WhiteAttack[1], BlackAttack[1], WhiteDefense[1], BlackDefense[1], CritChance[1], Agility[1])
		);
	}
}
