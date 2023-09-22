using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.MathUtils;

namespace Toutetsu.Items;

public class SimpleEquippableItemFactory : IItemFactory
{
	public SimpleEquippableItemFactory(string spriteName, ItemType type, StatsSet means, StatsSet deviations)
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
}
