using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;
using Toutetsu.Items;
using Toutetsu.State;

namespace Toutetsu.Scenes;

public class SceneFight : Scene
{
	Player? Player { get; set; }
	FightManager? FightManager { get; set; }
	List<SpellButton> SpellButtons { get; } = new();

	public void Init(Player player, FightManager fightManager, ItemRegister itemRegister)
	{
		Player = player;
		FightManager = fightManager;
		Camera camera = GetCamera("Camera");

		// Inventory
		((InventoryView)GetGameObject("Inventory View")).Init(Player.Inventory, camera);
		Player.Stats.AddViewSprites((TextObject)GetGameObject("Stats Text Left"),
			(TextObject)GetGameObject("Stats Text Right"));

		// Sprites & animations
		((AnimatedSprite)GetGameObject("Player Sprite").Sprite!).State = 3;
		FightManager.PlayerAttackAnimation = (PlayableSprite)GetGameObject("Player Attack Animation").Sprite!;
		FightManager.EnemyAttackAnimation = (PlayableSprite)GetGameObject("Enemy Attack Animation").Sprite!;

		// Spell buttons
		for (int i = 0; i < 5; i++)
		{
			SpellButtons.Add(new(camera, FightManager));
			SpellButtons[i].Position = new(64 + i * 128, 64);
			RegisterGameObject(SpellButtons[i]);
		}
		SpellButtons[0].Spell = itemRegister.CreateItem("spell_weapon");
	}

	public override void OnEnter()
	{
		((TextObject)GetGameObject("Enemy Display Name")).Text = FightManager!.Enemy.DisplayName;
		GameObject enemySpriteObject = GetGameObject("Enemy Sprite");
		enemySpriteObject.Sprite = FightManager.Enemy.FightSprite;
		enemySpriteObject.Position = new(732 - enemySpriteObject.Sprite.Width / 2, 544 - enemySpriteObject.Sprite.Height);
		for (int i = 1; i < 5; i++)
			if (Player!.Inventory.Slots[Inventory.SpellStartIndex + i - 1].Item.Type == ItemType.Spell)
				SpellButtons[i].Spell = Player.Inventory.Slots[Inventory.SpellStartIndex + i - 1].Item;
			else
				SpellButtons[i].Spell = null;
	}
}
