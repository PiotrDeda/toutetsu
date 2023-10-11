using Toutetsu.Items;
using Toutetsu.State;

namespace Toutetsu.Map;

public class PickupItem : MapObject
{
	public PickupItem(ItemData itemData) : base(itemData.Sprite)
	{
		ItemData = itemData;
	}

	ItemData ItemData { get; }

	public override bool OnInteract(Player player)
	{
		player.Inventory.AddItem(ItemData);
		return false;
	}
}
