using Rokuro.Graphics;

namespace Toutetsu.Loaders;

public class SpriteTemplateLoader
{
	public static Dictionary<string, StaticSpriteTemplate> GetSpriteTemplates()
	{
		Dictionary<string, StaticSpriteTemplate> templates = new();

		// UI
		templates["title"] = new StaticSpriteTemplate("ui/title");
		templates["play_button"] = new StaticSpriteTemplate("ui/play_button");
		templates["quit_button"] = new StaticSpriteTemplate("ui/quit_button");
		templates["equipment_bg"] = new StaticSpriteTemplate("ui/equipment_bg");
		templates["win_screen"] = new StaticSpriteTemplate("ui/win_screen");
		templates["lose_screen"] = new StaticSpriteTemplate("ui/lose_screen");
		templates["player_fight"] = new AnimatedSpriteTemplate("tiles/player", 2, 30, 4);
		templates["fight_bg"] = new StaticSpriteTemplate("ui/fight_bg");
		// TODO: sprites["attack_animation_player"] = new PlayableSprite("ui/attack_animation", 3, 100);
		// TODO: sprites["attack_animation_enemy"] = new PlayableSprite("ui/attack_animation", 3, 100);

		// Tiles
		templates["player"] = new AnimatedSpriteTemplate("tiles/player", 2, 30, 4);
		templates["wall"] = new StaticSpriteTemplate("tiles/wall");
		templates["wall_torch"] = new AnimatedSpriteTemplate("tiles/wall_torch", 3, 5);
		templates["floor"] = new StaticSpriteTemplate("tiles/floor");
		templates["floor_exit"] = new StaticSpriteTemplate("tiles/floor_exit");

		// Enemies
		templates["green_slime"] = new StaticSpriteTemplate("enemies/green_slime");
		templates["blue_slime"] = new StaticSpriteTemplate("enemies/blue_slime");
		templates["purple_slime"] = new StaticSpriteTemplate("enemies/purple_slime");
		templates["fire_slime"] = new StaticSpriteTemplate("enemies/fire_slime");

		templates["blue_beholder"] = new StaticSpriteTemplate("enemies/blue_beholder");
		templates["orange_beholder"] = new StaticSpriteTemplate("enemies/orange_beholder");
		templates["pink_beholder"] = new StaticSpriteTemplate("enemies/pink_beholder");
		templates["lava_beholder"] = new StaticSpriteTemplate("enemies/lava_beholder");

		templates["toutetsu_map"] = new StaticSpriteTemplate("enemies/toutetsu_map");
		templates["toutetsu_fight"] = new StaticSpriteTemplate("enemies/toutetsu_fight");

		// Items
		templates["blank_item"] = new StaticSpriteTemplate("items/blank_item");

		templates["wooden_wand"] = new StaticSpriteTemplate("items/wooden_wand");
		templates["iron_wand"] = new StaticSpriteTemplate("items/iron_wand");
		templates["golden_wand"] = new StaticSpriteTemplate("items/golden_wand");
		templates["enchanted_wand"] = new StaticSpriteTemplate("items/enchanted_wand");

		templates["wooden_sword"] = new StaticSpriteTemplate("items/wooden_sword");
		templates["iron_sword"] = new StaticSpriteTemplate("items/iron_sword");
		templates["golden_sword"] = new StaticSpriteTemplate("items/golden_sword");
		templates["enchanted_sword"] = new StaticSpriteTemplate("items/enchanted_sword");

		templates["wooden_axe"] = new StaticSpriteTemplate("items/wooden_axe");
		templates["iron_axe"] = new StaticSpriteTemplate("items/iron_axe");
		templates["golden_axe"] = new StaticSpriteTemplate("items/golden_axe");
		templates["enchanted_axe"] = new StaticSpriteTemplate("items/enchanted_axe");

		templates["wooden_staff"] = new StaticSpriteTemplate("items/wooden_staff");
		templates["iron_staff"] = new StaticSpriteTemplate("items/iron_staff");
		templates["golden_staff"] = new StaticSpriteTemplate("items/golden_staff");
		templates["enchanted_staff"] = new StaticSpriteTemplate("items/enchanted_staff");

		templates["iron_helmet"] = new StaticSpriteTemplate("items/iron_helmet");
		templates["golden_helmet"] = new StaticSpriteTemplate("items/golden_helmet");
		templates["enchanted_helmet"] = new StaticSpriteTemplate("items/enchanted_helmet");

		templates["iron_armor"] = new StaticSpriteTemplate("items/iron_armor");
		templates["golden_armor"] = new StaticSpriteTemplate("items/golden_armor");
		templates["enchanted_armor"] = new StaticSpriteTemplate("items/enchanted_armor");

		templates["iron_boots"] = new StaticSpriteTemplate("items/iron_boots");
		templates["golden_boots"] = new StaticSpriteTemplate("items/golden_boots");
		templates["enchanted_boots"] = new StaticSpriteTemplate("items/enchanted_boots");

		templates["crit_pendant"] = new StaticSpriteTemplate("items/crit_pendant");
		templates["health_pendant"] = new StaticSpriteTemplate("items/health_pendant");
		templates["greater_health_pendant"] = new StaticSpriteTemplate("items/greater_health_pendant");
		templates["agility_pendant"] = new StaticSpriteTemplate("items/agility_pendant");

		templates["white_shield"] = new StaticSpriteTemplate("items/white_shield");
		templates["black_shield"] = new StaticSpriteTemplate("items/black_shield");

		templates["white_book_i"] = new StaticSpriteTemplate("items/white_book_i");
		templates["white_book_ii"] = new StaticSpriteTemplate("items/white_book_ii");
		templates["white_book_iii"] = new StaticSpriteTemplate("items/white_book_iii");
		templates["black_book_i"] = new StaticSpriteTemplate("items/black_book_i");
		templates["black_book_ii"] = new StaticSpriteTemplate("items/black_book_ii");
		templates["black_book_iii"] = new StaticSpriteTemplate("items/black_book_iii");

		templates["spell_weapon"] = new StaticSpriteTemplate("items/spell_weapon");

		templates["spell_zap"] = new StaticSpriteTemplate("items/spell_zap");
		templates["spell_burn"] = new StaticSpriteTemplate("items/spell_burn");
		templates["spell_arrow"] = new StaticSpriteTemplate("items/spell_arrow");

		templates["spell_holy_strike"] = new StaticSpriteTemplate("items/spell_holy_strike");
		templates["spell_keystone"] = new StaticSpriteTemplate("items/spell_keystone");
		templates["spell_dark_orb"] = new StaticSpriteTemplate("items/spell_dark_orb");

		templates["spell_star_shower"] = new StaticSpriteTemplate("items/spell_star_shower");
		templates["spell_water_gun"] = new StaticSpriteTemplate("items/spell_water_gun");
		templates["spell_poison"] = new StaticSpriteTemplate("items/spell_poison");

		templates["spell_sunray"] = new StaticSpriteTemplate("items/spell_sunray");
		templates["spell_elemental_seal"] = new StaticSpriteTemplate("items/spell_elemental_seal");
		templates["spell_darkness"] = new StaticSpriteTemplate("items/spell_darkness");

		return templates;
	}
}
