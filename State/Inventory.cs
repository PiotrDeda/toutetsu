using Rokuro.Graphics;
using Toutetsu.Items;
using static Toutetsu.Items.ItemType;

namespace Toutetsu.State;

public class Inventory
{
	public const int CursorIndex = 0;
	public const int EquipmentStartIndex = 1;
	public const int EquipmentEndIndex = 7;
	public const int SpellStartIndex = 8;
	public const int SpellEndIndex = 11;
	public const int MainInventoryStartIndex = 12;
	public const int MainInventoryEndIndex = 36;

	public Inventory(SpriteManager spriteManager, PlayerStats playerStats)
	{
		PlayerStats = playerStats;

		// Cursor
		Slots[0] = new(CursorIndex, new(0, 0), General, spriteManager);

		// Weapon
		Slots[1] = new(EquipmentStartIndex, new(32, 96), Weapon, spriteManager);

		// Helmet, armor, boots, trinket, shield, book
		for (int i = EquipmentStartIndex + 1; i <= EquipmentEndIndex; i++)
			Slots[i] = new(i, new(
				96 + (i - EquipmentStartIndex - 1) / 3 * 64,
				32 + (i - EquipmentStartIndex - 1) % 3 * 64
			), Helmet + i - EquipmentStartIndex - 1, spriteManager);

		// Spells
		for (int i = SpellStartIndex; i <= SpellEndIndex; i++)
			Slots[i] = new(i, new(
				272,
				40 + (i - SpellStartIndex) * 80
			), Spell, spriteManager);

		// Main inventory
		for (int i = MainInventoryStartIndex; i <= MainInventoryEndIndex; i++)
			Slots[i] = new(i, new(
				32 + (i - MainInventoryStartIndex) % 5 * 64,
				384 + (i - MainInventoryStartIndex) / 5 * 64
			), General, spriteManager);
	}

	public InventorySlot[] Slots { get; } = new InventorySlot[37];

	PlayerStats PlayerStats { get; }

	public void SwitchCursorItem(int index, bool equipmentLocked)
	{
		if (equipmentLocked && index > CursorIndex && index < MainInventoryStartIndex)
			return;

		if (Slots[CursorIndex].Item.Type == Blank || Slots[index].Type == General ||
			Slots[index].Type == Slots[CursorIndex].Item.Type)
		{
			ItemData temp = Slots[index].Item;
			Slots[index].Item = Slots[CursorIndex].Item;
			Slots[CursorIndex].Item = temp;
		}

		RefreshStats();
	}

	public void AddItem(ItemData item)
	{
		for (int i = MainInventoryStartIndex; i <= MainInventoryEndIndex; i++)
			if (Slots[i].Item.Type == Blank)
			{
				Slots[i].Item = item;
				RefreshStats();
				return;
			}

		Slots[MainInventoryEndIndex].Item = item;
		RefreshStats();
	}

	public void AddItem(ItemData item, int slot)
	{
		Slots[slot].Item = item;
		RefreshStats();
	}

	void RefreshStats()
	{
		List<ItemData> items = new();
		for (int i = EquipmentStartIndex; i <= EquipmentEndIndex; i++)
			if (Slots[i].Item.Type != Blank)
				items.Add(Slots[i].Item);
		PlayerStats.UpdateStats(items);
	}
}
