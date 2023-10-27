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
		Name = "SceneFight";
		Camera = new(drawer, windowData);
		Player = player;
		FightManager = fightManager;

		// Background
		SimpleObject background = new(spriteManager.CreateSprite<StaticSprite>("fight_bg"), Camera);
		RegisterGameObject(background);

		// Inventory
		SimpleObject inventoryBackground = new(spriteManager.CreateSprite<StaticSprite>("equipment_bg"), Camera);
		inventoryBackground.Position = new(912, 0);
		RegisterGameObject(inventoryBackground);

		InventoryView inventoryView = new(Player.Inventory, Camera, input);
		inventoryView.Position = new(912, 0);
		inventoryView.EquipmentLocked = true;
		RegisterGameObject(inventoryView);

		// Stats
		TextObject statsTextLeft = new(Camera, "StatsLeft", new(255, 255, 255), spriteManager.DefaultFont);
		statsTextLeft.Position = new(970, 240);
		RegisterGameObject(statsTextLeft);

		TextObject statsTextRight = new(Camera, "StatsRight", new(255, 255, 255), spriteManager.DefaultFont);
		statsTextRight.Position = new(1082, 264);
		RegisterGameObject(statsTextRight);

		Player.Stats.AddViewSprites(statsTextLeft, statsTextRight);

		// Player sprite
		SimpleObject playerSpriteObject = new(spriteManager.CreateSprite<AnimatedSprite>("player_fight"), Camera);
		playerSpriteObject.Position = new(150, 480);
		((AnimatedSprite)playerSpriteObject.Sprite).State = 3;
		RegisterGameObject(playerSpriteObject);

		// Enemy sprite
		EnemySpriteObject = new(spriteManager.CreateSprite<StaticSprite>("blank_item"), Camera);
		EnemySpriteObject.Position = new(EnemySpriteX, EnemySpriteY);
		RegisterGameObject(EnemySpriteObject);

		// Attack animations
		SimpleObject playerAttackAnimationObject =
			new(spriteManager.CreateSprite<PlayableSprite>("attack_animation_player"), Camera);
		playerAttackAnimationObject.Position = new(150, 480);
		RegisterGameObject(playerAttackAnimationObject);

		SimpleObject enemyAttackAnimationObject =
			new(spriteManager.CreateSprite<PlayableSprite>("attack_animation_enemy"), Camera);
		enemyAttackAnimationObject.Position = new(EnemySpriteX - 32, EnemySpriteY - 64);
		RegisterGameObject(enemyAttackAnimationObject);

		FightManager.PlayerAttackAnimation = (PlayableSprite)playerAttackAnimationObject.Sprite;
		FightManager.EnemyAttackAnimation = (PlayableSprite)enemyAttackAnimationObject.Sprite;

		// Enemy display name
		EnemyDisplayName = new(Camera, "NULL", new(255, 255, 255), spriteManager.DefaultFont);
		EnemyDisplayName.Position = new(700, 10);
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
	SimpleObject EnemySpriteObject { get; }
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
