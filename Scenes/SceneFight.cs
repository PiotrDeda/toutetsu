using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;
using Toutetsu.Items;
using Toutetsu.State;

namespace Toutetsu.Scenes;

public class SceneFight : Scene
{
	static readonly int EnemySpriteX = 732;
	static readonly int EnemySpriteY = 544;

	public SceneFight(Player player, FightManager fightManager, ItemRegister itemRegister)
	{
		// Variable init
		Name = "Fight";
		Camera = new() {
			Name = "Camera"
		};
		Player = player;
		FightManager = fightManager;

		// Background
		GameObject background = new() {
			Camera = Camera,
			Sprite = SpriteManager.CreateSprite<StaticSprite>("ui/fight_bg")
		};
		RegisterGameObject(background);

		// Inventory
		GameObject inventoryBackground = new() {
			Position = new(912, 0),
			Camera = Camera,
			Sprite = SpriteManager.CreateSprite<StaticSprite>("ui/equipment_bg")
		};
		RegisterGameObject(inventoryBackground);

		InventoryView inventoryView = new(Player.Inventory, Camera);
		inventoryView.Position = new(912, 0);
		inventoryView.EquipmentLocked = true;
		RegisterGameObject(inventoryView);

		// Stats
		TextObject statsTextLeft = new() {
			Position = new(970, 240),
			Camera = Camera,
			Text = "StatsLeft",
			Color = new(255, 255, 255)
		};
		RegisterGameObject(statsTextLeft);

		TextObject statsTextRight = new() {
			Position = new(1082, 264),
			Camera = Camera,
			Text = "StatsRight",
			Color = new(255, 255, 255)
		};
		RegisterGameObject(statsTextRight);

		Player.Stats.AddViewSprites(statsTextLeft, statsTextRight);

		// Player sprite
		GameObject playerSpriteObject = new() {
			Position = new(150, 480),
			Camera = Camera,
			Sprite = SpriteManager.CreateSprite<AnimatedSprite>("tiles/player")
		};
		((AnimatedSprite)playerSpriteObject.Sprite).State = 3;
		RegisterGameObject(playerSpriteObject);

		// Enemy sprite
		EnemySpriteObject = new() {
			Position = new(EnemySpriteX, EnemySpriteY),
			Camera = Camera,
			Sprite = SpriteManager.CreateSprite<StaticSprite>("items/blank_item")
		};
		RegisterGameObject(EnemySpriteObject);

		// Attack animations
		GameObject playerAttackAnimationObject = new() {
			Position = new(150, 480),
			Camera = Camera,
			Sprite = SpriteManager.CreateSprite<PlayableSprite>("ui/attack_animation")
		};
		RegisterGameObject(playerAttackAnimationObject);

		GameObject enemyAttackAnimationObject = new() {
			Position = new(EnemySpriteX - 32, EnemySpriteY - 64),
			Camera = Camera,
			Sprite = SpriteManager.CreateSprite<PlayableSprite>("ui/attack_animation")
		};
		RegisterGameObject(enemyAttackAnimationObject);

		FightManager.PlayerAttackAnimation = (PlayableSprite)playerAttackAnimationObject.Sprite!;
		FightManager.EnemyAttackAnimation = (PlayableSprite)enemyAttackAnimationObject.Sprite!;

		// Enemy display name
		EnemyDisplayName = new() {
			Position = new(700, 10),
			Camera = Camera,
			Text = "NULL",
			Color = new(255, 255, 255)
		};
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
		EnemySpriteObject.Position = new(EnemySpriteX - EnemySpriteObject.Sprite.Width / 2,
			EnemySpriteY - EnemySpriteObject.Sprite.Height);
		for (int i = 1; i < 5; i++)
			if (Player.Inventory.Slots[Inventory.SpellStartIndex + i - 1].Item.Type == ItemType.Spell)
				SpellButtons[i].Spell = Player.Inventory.Slots[Inventory.SpellStartIndex + i - 1].Item;
			else
				SpellButtons[i].Spell = null;
	}
}
