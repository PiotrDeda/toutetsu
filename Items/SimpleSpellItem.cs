using Rokuro.Graphics;

namespace Toutetsu.Items;

public class SimpleSpellItem : ItemData
{
	public SimpleSpellItem(ISprite sprite, StatsSet spellStats)
	{
		Sprite = sprite;
		Type = ItemType.Spell;
		SpellStats = spellStats;
	}

	StatsSet SpellStats { get; }

	public override StatsSet GetSpellStats() => SpellStats;
}
