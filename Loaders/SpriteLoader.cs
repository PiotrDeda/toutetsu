using Rokuro.Graphics;

namespace Toutetsu.Loaders;

public class SpriteLoader
{
	public static Dictionary<string, Sprite> GetSprites()
	{
		Dictionary<string, Sprite> sprites = new();

		// UI
		sprites["title"] = new Sprite("ui/title");
		sprites["play_button"] = new Sprite("ui/play_button");
		sprites["quit_button"] = new Sprite("ui/quit_button");
		sprites["equipment_bg"] = new Sprite("ui/equipment_bg");
		sprites["win_screen"] = new Sprite("ui/win_screen");
		sprites["lose_screen"] = new Sprite("ui/lose_screen");
		sprites["player_fight"] = new AnimatedSprite("tiles/player", 2, 30, 4);
		sprites["fight_bg"] = new Sprite("ui/fight_bg");
		//sprites["attack_animation_player"] = new PlayableSprite("ui/attack_animation", 3, 100);
		//sprites["attack_animation_enemy"] = new PlayableSprite("ui/attack_animation", 3, 100);

		// Tiles
		sprites["player"] = new AnimatedSprite("tiles/player", 2, 30, 4);
		sprites["wall"] = new Sprite("tiles/wall");
		sprites["wall_torch"] = new AnimatedSprite("tiles/wall_torch", 3, 100);
		sprites["floor"] = new Sprite("tiles/floor");
		sprites["floor_exit"] = new Sprite("tiles/floor_exit");

		// Enemies
		sprites["green_slime"] = new Sprite("enemies/green_slime");
		sprites["blue_slime"] = new Sprite("enemies/blue_slime");
		sprites["purple_slime"] = new Sprite("enemies/purple_slime");
		sprites["fire_slime"] = new Sprite("enemies/fire_slime");

		sprites["blue_beholder"] = new Sprite("enemies/blue_beholder");
		sprites["orange_beholder"] = new Sprite("enemies/orange_beholder");
		sprites["pink_beholder"] = new Sprite("enemies/pink_beholder");
		sprites["lava_beholder"] = new Sprite("enemies/lava_beholder");

		sprites["toutetsu_map"] = new Sprite("enemies/toutetsu_map");
		sprites["toutetsu_fight"] = new Sprite("enemies/toutetsu_fight");

		// Items
		sprites["blank_item"] = new Sprite("items/blank_item");

		sprites["wooden_wand"] = new Sprite("items/wooden_wand");
		sprites["iron_wand"] = new Sprite("items/iron_wand");
		sprites["golden_wand"] = new Sprite("items/golden_wand");
		sprites["enchanted_wand"] = new Sprite("items/enchanted_wand");

		sprites["wooden_sword"] = new Sprite("items/wooden_sword");
		sprites["iron_sword"] = new Sprite("items/iron_sword");
		sprites["golden_sword"] = new Sprite("items/golden_sword");
		sprites["enchanted_sword"] = new Sprite("items/enchanted_sword");

		sprites["wooden_axe"] = new Sprite("items/wooden_axe");
		sprites["iron_axe"] = new Sprite("items/iron_axe");
		sprites["golden_axe"] = new Sprite("items/golden_axe");
		sprites["enchanted_axe"] = new Sprite("items/enchanted_axe");

		sprites["wooden_staff"] = new Sprite("items/wooden_staff");
		sprites["iron_staff"] = new Sprite("items/iron_staff");
		sprites["golden_staff"] = new Sprite("items/golden_staff");
		sprites["enchanted_staff"] = new Sprite("items/enchanted_staff");

		sprites["iron_helmet"] = new Sprite("items/iron_helmet");
		sprites["golden_helmet"] = new Sprite("items/golden_helmet");
		sprites["enchanted_helmet"] = new Sprite("items/enchanted_helmet");

		sprites["iron_armor"] = new Sprite("items/iron_armor");
		sprites["golden_armor"] = new Sprite("items/golden_armor");
		sprites["enchanted_armor"] = new Sprite("items/enchanted_armor");

		sprites["iron_boots"] = new Sprite("items/iron_boots");
		sprites["golden_boots"] = new Sprite("items/golden_boots");
		sprites["enchanted_boots"] = new Sprite("items/enchanted_boots");

		sprites["crit_pendant"] = new Sprite("items/crit_pendant");
		sprites["health_pendant"] = new Sprite("items/health_pendant");
		sprites["greater_health_pendant"] = new Sprite("items/greater_health_pendant");
		sprites["agility_pendant"] = new Sprite("items/agility_pendant");

		sprites["white_shield"] = new Sprite("items/white_shield");
		sprites["black_shield"] = new Sprite("items/black_shield");

		sprites["white_book_i"] = new Sprite("items/white_book_i");
		sprites["white_book_ii"] = new Sprite("items/white_book_ii");
		sprites["white_book_iii"] = new Sprite("items/white_book_iii");
		sprites["black_book_i"] = new Sprite("items/black_book_i");
		sprites["black_book_ii"] = new Sprite("items/black_book_ii");
		sprites["black_book_iii"] = new Sprite("items/black_book_iii");

		sprites["spell_weapon"] = new Sprite("items/spell_weapon");

		sprites["spell_zap"] = new Sprite("items/spell_zap");
		sprites["spell_burn"] = new Sprite("items/spell_burn");
		sprites["spell_arrow"] = new Sprite("items/spell_arrow");

		sprites["spell_holy_strike"] = new Sprite("items/spell_holy_strike");
		sprites["spell_keystone"] = new Sprite("items/spell_keystone");
		sprites["spell_dark_orb"] = new Sprite("items/spell_dark_orb");

		sprites["spell_star_shower"] = new Sprite("items/spell_star_shower");
		sprites["spell_water_gun"] = new Sprite("items/spell_water_gun");
		sprites["spell_poison"] = new Sprite("items/spell_poison");

		sprites["spell_sunray"] = new Sprite("items/spell_sunray");
		sprites["spell_elemental_seal"] = new Sprite("items/spell_elemental_seal");
		sprites["spell_darkness"] = new Sprite("items/spell_darkness");
		
		return sprites;
	}
}
