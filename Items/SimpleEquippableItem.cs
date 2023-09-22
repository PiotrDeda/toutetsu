using Rokuro.Graphics;

namespace Toutetsu.Items;

public class SimpleEquippableItem : ItemData
{
	public SimpleEquippableItem(ISprite sprite, ItemType type, int maxHP, int whiteAttack, int blackAttack,
		int whiteDefense, int blackDefense, int critChance, int agility)
	{
		Sprite = sprite;
		Type = type;
		MaxHP = maxHP;
		WhiteAttack = whiteAttack;
		BlackAttack = blackAttack;
		WhiteDefense = whiteDefense;
		BlackDefense = blackDefense;
		CritChance = critChance;
		Agility = agility;
	}

	int MaxHP { get; }
	int WhiteAttack { get; }
	int BlackAttack { get; }
	int WhiteDefense { get; }
	int BlackDefense { get; }
	int CritChance { get; }
	int Agility { get; }

	public override StatsSet ApplyStatModifiers(StatsSet stats) =>
		new(
			stats.MaxHP + MaxHP,
			stats.WhiteAttack + WhiteAttack,
			stats.BlackAttack + BlackAttack,
			stats.WhiteDefense + WhiteDefense,
			stats.BlackDefense + BlackDefense,
			stats.CritChance + CritChance,
			stats.Agility + Agility
		);
}
