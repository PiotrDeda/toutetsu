using Rokuro.Graphics;
using Rokuro.Inputs;
using Rokuro.MathUtils;
using Rokuro.Objects;
using Toutetsu.State;

namespace Toutetsu.Components;

public class InventoryView : GameObject, IMouseInteractable
{
	public InventoryView(Inventory inventory, Camera camera)
	{
		Inventory = inventory;
		Camera = camera;
	}

	public bool EquipmentLocked { get; set; }

	Inventory Inventory { get; }
	int LastClickedIndex { get; set; }

	public bool WasMouseoverHandled { get; set; } = false;

	public bool IsMouseOver(Vector2I mousePosition)
	{
		if (Enabled && Camera != null)
			foreach (InventorySlot slot in Inventory.Slots)
			{
				Vector2I screenPosition = Camera.GetScreenPosition(Position + slot.Offset);
				if (slot.Index != Inventory.CursorIndex &&
					mousePosition.X >= screenPosition.X &&
					mousePosition.X <= screenPosition.X + slot.Item.Sprite.Width * Camera.Scale &&
					mousePosition.Y >= screenPosition.Y &&
					mousePosition.Y <= screenPosition.Y + slot.Item.Sprite.Height * Camera.Scale)
				{
					LastClickedIndex = slot.Index;
					return true;
				}
			}

		return false;
	}

	public void OnMouseover() {}

	public void OnClick()
	{
		Inventory.SwitchCursorItem(LastClickedIndex, EquipmentLocked);
	}

	public override void Draw()
	{
		if (!Enabled || Camera == null)
			return;

		foreach (InventorySlot slot in Inventory.Slots)
			if (slot.Index != Inventory.CursorIndex)
				Camera.DrawSprite(slot.Item.Sprite, Position + slot.Offset);

		Sprite cursorSprite = Inventory.Slots[Inventory.CursorIndex].Item.Sprite;
		Vector2I cursorPosition = Input.GetMousePosition() -
								  new Vector2I(cursorSprite.Width, cursorSprite.Height) * Camera.Scale / 2;
		Camera.DrawSprite(cursorSprite, cursorPosition);
	}
}
