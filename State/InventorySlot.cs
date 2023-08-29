using Toutetsu.Items;

namespace Toutetsu.State;

public class InventorySlot
{
	public InventorySlot(int index, int offsetX, int offsetY, ItemType type)
	{
		Index = index;
		OffsetX = offsetX;
		OffsetY = offsetY;
		Type = type;
	}

	public int Index { get; set; }
	public int OffsetX { get; set; }
	public int OffsetY { get; set; }
	public ItemType Type { get; set; }
	public ItemData Item { get; set; } = new BlankItem();
}
