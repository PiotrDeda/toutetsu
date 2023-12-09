using Rokuro.Graphics;

namespace Toutetsu.Loaders;

public class SpriteTemplateLoader
{
	public static Dictionary<string, SpriteTemplate> GetSpriteTemplates(SpriteManager spriteManager)
	{
		Dictionary<string, SpriteTemplate> templates = new();
		var texture = spriteManager.LoadTexture;

		// UI
		templates["title"] = new(texture("ui/title"));
		templates["play_button"] = new(texture("ui/play_button"));
		templates["quit_button"] = new(texture("ui/quit_button"));
		templates["dev_button"] = new(texture("ui/dev_button"));
		templates["equipment_bg"] = new(texture("ui/equipment_bg"));
		templates["win_screen"] = new(texture("ui/win_screen"));
		templates["lose_screen"] = new(texture("ui/lose_screen"));
		templates["player_fight"] = new(texture("tiles/player"), 4, 2, 30);
		templates["fight_bg"] = new(texture("ui/fight_bg"));
		templates["attack_animation_player"] = new(texture("ui/attack_animation"), 1, 3, 5);
		templates["attack_animation_enemy"] = new(texture("ui/attack_animation"), 1, 3, 5);

		// Tiles
		templates["player"] = new(texture("tiles/player"), 4, 2, 30);
		templates["wall"] = new(texture("tiles/wall"));
		templates["wall_torch"] = new(texture("tiles/wall_torch"), 1, 3, 5);
		templates["floor"] = new(texture("tiles/floor"));
		templates["floor_exit"] = new(texture("tiles/floor_exit"));

		// Enemies
		templates["green_slime"] = new(texture("enemies/green_slime"));
		templates["blue_slime"] = new(texture("enemies/blue_slime"));
		templates["purple_slime"] = new(texture("enemies/purple_slime"));
		templates["fire_slime"] = new(texture("enemies/fire_slime"));

		templates["blue_beholder"] = new(texture("enemies/blue_beholder"));
		templates["orange_beholder"] = new(texture("enemies/orange_beholder"));
		templates["pink_beholder"] = new(texture("enemies/pink_beholder"));
		templates["lava_beholder"] = new(texture("enemies/lava_beholder"));

		templates["toutetsu_map"] = new(texture("enemies/toutetsu_map"));
		templates["toutetsu_fight"] = new(texture("enemies/toutetsu_fight"));

		// Items
		templates["blank_item"] = new(texture("items/blank_item"));

		templates["wooden_wand"] = new(texture("items/wooden_wand"));
		templates["iron_wand"] = new(texture("items/iron_wand"));
		templates["golden_wand"] = new(texture("items/golden_wand"));
		templates["enchanted_wand"] = new(texture("items/enchanted_wand"));

		templates["wooden_sword"] = new(texture("items/wooden_sword"));
		templates["iron_sword"] = new(texture("items/iron_sword"));
		templates["golden_sword"] = new(texture("items/golden_sword"));
		templates["enchanted_sword"] = new(texture("items/enchanted_sword"));

		templates["wooden_axe"] = new(texture("items/wooden_axe"));
		templates["iron_axe"] = new(texture("items/iron_axe"));
		templates["golden_axe"] = new(texture("items/golden_axe"));
		templates["enchanted_axe"] = new(texture("items/enchanted_axe"));

		templates["wooden_staff"] = new(texture("items/wooden_staff"));
		templates["iron_staff"] = new(texture("items/iron_staff"));
		templates["golden_staff"] = new(texture("items/golden_staff"));
		templates["enchanted_staff"] = new(texture("items/enchanted_staff"));

		templates["iron_helmet"] = new(texture("items/iron_helmet"));
		templates["golden_helmet"] = new(texture("items/golden_helmet"));
		templates["enchanted_helmet"] = new(texture("items/enchanted_helmet"));

		templates["iron_armor"] = new(texture("items/iron_armor"));
		templates["golden_armor"] = new(texture("items/golden_armor"));
		templates["enchanted_armor"] = new(texture("items/enchanted_armor"));

		templates["iron_boots"] = new(texture("items/iron_boots"));
		templates["golden_boots"] = new(texture("items/golden_boots"));
		templates["enchanted_boots"] = new(texture("items/enchanted_boots"));

		templates["crit_pendant"] = new(texture("items/crit_pendant"));
		templates["health_pendant"] = new(texture("items/health_pendant"));
		templates["greater_health_pendant"] = new(texture("items/greater_health_pendant"));
		templates["agility_pendant"] = new(texture("items/agility_pendant"));

		templates["white_shield"] = new(texture("items/white_shield"));
		templates["black_shield"] = new(texture("items/black_shield"));

		templates["white_book_i"] = new(texture("items/white_book_i"));
		templates["white_book_ii"] = new(texture("items/white_book_ii"));
		templates["white_book_iii"] = new(texture("items/white_book_iii"));
		templates["black_book_i"] = new(texture("items/black_book_i"));
		templates["black_book_ii"] = new(texture("items/black_book_ii"));
		templates["black_book_iii"] = new(texture("items/black_book_iii"));

		templates["spell_weapon"] = new(texture("items/spell_weapon"));

		templates["spell_zap"] = new(texture("items/spell_zap"));
		templates["spell_burn"] = new(texture("items/spell_burn"));
		templates["spell_arrow"] = new(texture("items/spell_arrow"));

		templates["spell_holy_strike"] = new(texture("items/spell_holy_strike"));
		templates["spell_keystone"] = new(texture("items/spell_keystone"));
		templates["spell_dark_orb"] = new(texture("items/spell_dark_orb"));

		templates["spell_star_shower"] = new(texture("items/spell_star_shower"));
		templates["spell_water_gun"] = new(texture("items/spell_water_gun"));
		templates["spell_poison"] = new(texture("items/spell_poison"));

		templates["spell_sunray"] = new(texture("items/spell_sunray"));
		templates["spell_elemental_seal"] = new(texture("items/spell_elemental_seal"));
		templates["spell_darkness"] = new(texture("items/spell_darkness"));

		return templates;
	}
}
