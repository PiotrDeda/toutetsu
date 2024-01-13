using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Inputs;
using Rokuro.Objects;
using Toutetsu.Components;
using Toutetsu.Items;
using Toutetsu.State;

namespace Toutetsu.Scenes;

public class SceneFight : Scene
{
	static readonly int EnemySpriteX = 732;
	static readonly int EnemySpriteY = 544;

	public SceneFight(SpriteManager spriteManager, Input input, Drawer drawer,
		WindowData windowData, Player player, FightManager fightManager, ItemRegister itemRegister)
	{
		// Variable init
		Name = "Fight";
		Camera = new("Camera", drawer, windowData);
		Player = player;
		FightManager = fightManager;

		// Background
		GameObject background = new(new(0, 0), spriteManager.CreateSprite<StaticSprite>("fight_bg"), Camera);
		RegisterGameObject(background);

		// Inventory
		GameObject inventoryBackground = new(new(912, 0),
			spriteManager.CreateSprite<StaticSprite>("equipment_bg"), Camera);
		RegisterGameObject(inventoryBackground);

		InventoryView inventoryView = new(Player.Inventory, Camera, input);
		inventoryView.Position = new(912, 0);
		inventoryView.EquipmentLocked = true;
		RegisterGameObject(inventoryView);

		// Stats
		TextObject statsTextLeft = new(new(970, 240), Camera, "StatsLeft",
			new(255, 255, 255), spriteManager.DefaultFont);
		RegisterGameObject(statsTextLeft);

		TextObject statsTextRight = new(new(1082, 264), Camera, "StatsRight",
			new(255, 255, 255), spriteManager.DefaultFont);
		RegisterGameObject(statsTextRight);

		Player.Stats.AddViewSprites(statsTextLeft, statsTextRight);

		// Player sprite
		GameObject playerSpriteObject = new(new(150, 480),
			spriteManager.CreateSprite<AnimatedSprite>("player_fight"), Camera);
		((AnimatedSprite)playerSpriteObject.Sprite!).State = 3;
		RegisterGameObject(playerSpriteObject);

		// Enemy sprite
		EnemySpriteObject = new(new(EnemySpriteX, EnemySpriteY),
			spriteManager.CreateSprite<StaticSprite>("blank_item"), Camera);
		RegisterGameObject(EnemySpriteObject);

		// Attack animations
		GameObject playerAttackAnimationObject = new(new(150, 480),
			spriteManager.CreateSprite<PlayableSprite>("attack_animation_player"), Camera);
		RegisterGameObject(playerAttackAnimationObject);

		GameObject enemyAttackAnimationObject = new(new(EnemySpriteX - 32, EnemySpriteY - 64),
			spriteManager.CreateSprite<PlayableSprite>("attack_animation_enemy"), Camera);
		RegisterGameObject(enemyAttackAnimationObject);

		FightManager.PlayerAttackAnimation = (PlayableSprite)playerAttackAnimationObject.Sprite!;
		FightManager.EnemyAttackAnimation = (PlayableSprite)enemyAttackAnimationObject.Sprite!;

		// Enemy display name
		EnemyDisplayName = new(new(700, 10), Camera, "NULL", new(255, 255, 255), spriteManager.DefaultFont);
		RegisterGameObject(EnemyDisplayName);

		// Spell buttons
		for (int i = 0; i < 5; i++)
		{
			SpellButtons.Add(new(Camera, FightManager));
			SpellButtons[i].Position = new(64 + i * 128, 64);
			RegisterGameObject(SpellButtons[i]);
		}

		SpellButtons[0].Spell = itemRegister.CreateItem("spell_weapon");
	}

	UICamera Camera { get; }
	Player Player { get; }
	FightManager FightManager { get; }
	GameObject EnemySpriteObject { get; }
	TextObject EnemyDisplayName { get; }
	List<SpellButton> SpellButtons { get; } = new();

	public override void OnEnter()
	{
		EnemyDisplayName.Text = FightManager.Enemy.DisplayName;
		EnemySpriteObject.Sprite = FightManager.Enemy.FightSprite;
		EnemySpriteObject.Position = new(EnemySpriteX - EnemySpriteObject.Sprite.GetWidth() / 2,
			EnemySpriteY - EnemySpriteObject.Sprite.GetHeight());
		for (int i = 1; i < 5; i++)
			if (Player.Inventory.Slots[Inventory.SpellStartIndex + i - 1].Item.Type == ItemType.Spell)
				SpellButtons[i].Spell = Player.Inventory.Slots[Inventory.SpellStartIndex + i - 1].Item;
			else
				SpellButtons[i].Spell = null;
	}
}
