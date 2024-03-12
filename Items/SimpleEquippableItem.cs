using Rokuro.Graphics;

namespace Toutetsu.Items;

public class SimpleEquippableItem : ItemData
{
	public SimpleEquippableItem(Sprite sprite, ItemType type, StatsSet stats)
	{
		Sprite = sprite;
		Type = type;
		Stats = stats;
	}

	StatsSet Stats { get; }

	public override StatsSet ApplyStatModifiers(StatsSet stats) => new(
		stats.MaxHP + Stats.MaxHP,
		stats.WhiteAttack + Stats.WhiteAttack,
		stats.BlackAttack + Stats.BlackAttack,
		stats.WhiteDefense + Stats.WhiteDefense,
		stats.BlackDefense + Stats.BlackDefense,
		stats.CritChance + Stats.CritChance,
		stats.Agility + Stats.Agility
	);
}
