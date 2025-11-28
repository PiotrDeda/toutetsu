using Toutetsu.Items;
using Toutetsu.State;

namespace Toutetsu.Map;

public class PickupItem(ItemData itemData) : MapObject(itemData.Sprite)
{
	ItemData ItemData { get; } = itemData;

	public override bool OnInteract(Player player)
	{
		player.Inventory.AddItem(ItemData);
		return false;
	}
}
