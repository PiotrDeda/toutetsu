using Rokuro.Core;
using static Toutetsu.Items.RandomItemGenerator.Type;

namespace Toutetsu.Items;

public static class RandomItemGenerator
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

	static Dictionary<Type, List<string>> Items { get; } = new() {
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

	public static ItemData Generate(Type type) =>
		ItemRegister.CreateItem(Items[type][App.Rand.Next(Items[type].Count)]);
}
