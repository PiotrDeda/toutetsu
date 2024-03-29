using Rokuro.MathUtils;
using Toutetsu.Items;

namespace Toutetsu.State;

public class InventorySlot
{
	public InventorySlot(int index, Vector2D offset, ItemType type)
	{
		Index = index;
		Offset = offset;
		Type = type;
		Item = new BlankItem();
	}

	public int Index { get; set; }
	public Vector2D Offset { get; set; }
	public ItemType Type { get; set; }
	public ItemData Item { get; set; }
}
