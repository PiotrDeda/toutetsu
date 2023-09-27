using Rokuro.Graphics;

namespace Toutetsu.Loaders;

public class SpriteTemplateLoader
{
	public static Dictionary<string, StaticSpriteTemplate> GetSpriteTemplates()
	{
		Dictionary<string, StaticSpriteTemplate> templates = new();

		// UI
		templates["title"] = new("ui/title");
		templates["play_button"] = new("ui/play_button");
		templates["quit_button"] = new("ui/quit_button");
		templates["equipment_bg"] = new("ui/equipment_bg");
		templates["win_screen"] = new("ui/win_screen");
		templates["lose_screen"] = new("ui/lose_screen");
		templates["player_fight"] = new AnimatedSpriteTemplate("tiles/player", 2, 30, 4);
		templates["fight_bg"] = new("ui/fight_bg");
		// TODO: sprites["attack_animation_player"] = new PlayableSprite("ui/attack_animation", 3, 100);
		// TODO: sprites["attack_animation_enemy"] = new PlayableSprite("ui/attack_animation", 3, 100);

		// Tiles
		templates["player"] = new AnimatedSpriteTemplate("tiles/player", 2, 30, 4);
		templates["wall"] = new("tiles/wall");
		templates["wall_torch"] = new AnimatedSpriteTemplate("tiles/wall_torch", 3, 5);
		templates["floor"] = new("tiles/floor");
		templates["floor_exit"] = new("tiles/floor_exit");

		// Enemies
		templates["green_slime"] = new("enemies/green_slime");
		templates["blue_slime"] = new("enemies/blue_slime");
		templates["purple_slime"] = new("enemies/purple_slime");
		templates["fire_slime"] = new("enemies/fire_slime");

		templates["blue_beholder"] = new("enemies/blue_beholder");
		templates["orange_beholder"] = new("enemies/orange_beholder");
		templates["pink_beholder"] = new("enemies/pink_beholder");
		templates["lava_beholder"] = new("enemies/lava_beholder");

		templates["toutetsu_map"] = new("enemies/toutetsu_map");
		templates["toutetsu_fight"] = new("enemies/toutetsu_fight");

		// Items
		templates["blank_item"] = new("items/blank_item");

		templates["wooden_wand"] = new("items/wooden_wand");
		templates["iron_wand"] = new("items/iron_wand");
		templates["golden_wand"] = new("items/golden_wand");
		templates["enchanted_wand"] = new("items/enchanted_wand");

		templates["wooden_sword"] = new("items/wooden_sword");
		templates["iron_sword"] = new("items/iron_sword");
		templates["golden_sword"] = new("items/golden_sword");
		templates["enchanted_sword"] = new("items/enchanted_sword");

		templates["wooden_axe"] = new("items/wooden_axe");
		templates["iron_axe"] = new("items/iron_axe");
		templates["golden_axe"] = new("items/golden_axe");
		templates["enchanted_axe"] = new("items/enchanted_axe");

		templates["wooden_staff"] = new("items/wooden_staff");
		templates["iron_staff"] = new("items/iron_staff");
		templates["golden_staff"] = new("items/golden_staff");
		templates["enchanted_staff"] = new("items/enchanted_staff");

		templates["iron_helmet"] = new("items/iron_helmet");
		templates["golden_helmet"] = new("items/golden_helmet");
		templates["enchanted_helmet"] = new("items/enchanted_helmet");

		templates["iron_armor"] = new("items/iron_armor");
		templates["golden_armor"] = new("items/golden_armor");
		templates["enchanted_armor"] = new("items/enchanted_armor");

		templates["iron_boots"] = new("items/iron_boots");
		templates["golden_boots"] = new("items/golden_boots");
		templates["enchanted_boots"] = new("items/enchanted_boots");

		templates["crit_pendant"] = new("items/crit_pendant");
		templates["health_pendant"] = new("items/health_pendant");
		templates["greater_health_pendant"] = new("items/greater_health_pendant");
		templates["agility_pendant"] = new("items/agility_pendant");

		templates["white_shield"] = new("items/white_shield");
		templates["black_shield"] = new("items/black_shield");

		templates["white_book_i"] = new("items/white_book_i");
		templates["white_book_ii"] = new("items/white_book_ii");
		templates["white_book_iii"] = new("items/white_book_iii");
		templates["black_book_i"] = new("items/black_book_i");
		templates["black_book_ii"] = new("items/black_book_ii");
		templates["black_book_iii"] = new("items/black_book_iii");

		templates["spell_weapon"] = new("items/spell_weapon");

		templates["spell_zap"] = new("items/spell_zap");
		templates["spell_burn"] = new("items/spell_burn");
		templates["spell_arrow"] = new("items/spell_arrow");

		templates["spell_holy_strike"] = new("items/spell_holy_strike");
		templates["spell_keystone"] = new("items/spell_keystone");
		templates["spell_dark_orb"] = new("items/spell_dark_orb");

		templates["spell_star_shower"] = new("items/spell_star_shower");
		templates["spell_water_gun"] = new("items/spell_water_gun");
		templates["spell_poison"] = new("items/spell_poison");

		templates["spell_sunray"] = new("items/spell_sunray");
		templates["spell_elemental_seal"] = new("items/spell_elemental_seal");
		templates["spell_darkness"] = new("items/spell_darkness");

		return templates;
	}
}
