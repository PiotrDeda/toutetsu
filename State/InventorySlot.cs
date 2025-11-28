using Rokuro.MathUtils;
using Toutetsu.Items;

namespace Toutetsu.State;

public class InventorySlot(int index, Vector2I offset, ItemType type)
{
	public int Index { get; set; } = index;
	public Vector2I Offset { get; set; } = offset;
	public ItemType Type { get; set; } = type;
	public ItemData Item { get; set; } = new BlankItem();
}
