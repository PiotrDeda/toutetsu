using Rokuro.Core;
using static Toutetsu.Items.RandomItemGenerator.Type;

namespace Toutetsu.Items;

public class RandomItemGenerator
{
	public enum Type
	{
		Tier1,
		Tier2,
		Tier3,
		Tier4,
		StartingWeapon,
		StartingSpell
	}

	public RandomItemGenerator(ItemRegister itemRegister, RNG rng)
	{
		ItemRegister = itemRegister;
		RNG = rng;
	}

	ItemRegister ItemRegister { get; }
	RNG RNG { get; }

	Dictionary<Type, List<string>> Items { get; } = new() {
		{
			Tier1, new() {
				"wooden_wand", "wooden_sword", "wooden_axe", "wooden_staff", "crit_pendant", "white_shield",
				"black_shield", "spell_zap", "spell_burn", "spell_arrow"
			}
		}, {
			Tier2, new() {
				"iron_wand", "iron_sword", "iron_axe", "iron_staff", "iron_helmet", "iron_armor", "iron_boots",
				"health_pendant", "white_shield", "black_shield", "white_book_i", "black_book_i", "spell_holy_strike",
				"spell_keystone", "spell_dark_orb"
			}
		}, {
			Tier3, new() {
				"golden_wand", "golden_sword", "golden_axe", "golden_staff", "golden_helmet", "golden_armor",
				"golden_boots", "greater_health_pendant", "white_book_ii", "black_book_ii", "spell_star_shower",
				"spell_water_gun", "spell_poison"
			}
		}, {
			Tier4, new() {
				"enchanted_wand", "enchanted_sword", "enchanted_axe", "enchanted_staff", "enchanted_helmet",
				"enchanted_armor", "enchanted_boots", "agility_pendant", "white_book_iii", "black_book_iii",
				"spell_sunray", "spell_elemental_seal", "spell_darkness"
			}
		}, {
			StartingWeapon, new() {
				"wooden_wand", "wooden_sword", "wooden_axe", "wooden_staff"
			}
		}, {
			StartingSpell, new() {
				"spell_zap", "spell_burn", "spell_arrow"
			}
		}
	};

	public ItemData Generate(Type type) => ItemRegister.CreateItem(Items[type][RNG.Rand.Next(Items[type].Count)]);

	public Type GetTypeFromLevel(int currentLevel)
	{
		int tierPercentage = RNG.Rand.Next(100);
		switch (currentLevel)
		{
			case 1:
				if (tierPercentage < 80)
					return Tier1;
				if (tierPercentage < 99)
					return Tier2;
				return Tier3;
			case 2:
				if (tierPercentage < 10)
					return Tier1;
				if (tierPercentage < 90)
					return Tier2;
				if (tierPercentage < 99)
					return Tier3;
				return Tier4;
			case 3:
				if (tierPercentage < 1)
					return Tier1;
				if (tierPercentage < 10)
					return Tier2;
				if (tierPercentage < 90)
					return Tier3;
				return Tier4;
			case 4:
				if (tierPercentage < 1)
					return Tier2;
				if (tierPercentage < 20)
					return Tier3;
				return Tier4;
			default:
				return Tier4;
		}
	}
}
