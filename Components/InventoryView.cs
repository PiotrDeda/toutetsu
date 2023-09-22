using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;
using Toutetsu.State;

namespace Toutetsu.Components;

public class InventoryView : BaseObject, IDrawable, IMouseInteractable
{
	public InventoryView(Inventory inventory, Camera camera)
	{
		Inventory = inventory;
		Camera = camera;
	}

	public Inventory Inventory { get; set; }
	public Camera Camera { get; set; }
	public bool EquipmentLocked { get; set; } = false;

	int LastClickedIndex { get; set; }

	public void Draw()
	{
		if (Enabled)
			foreach (InventorySlot slot in Inventory.Slots)
				if (slot.Index != Inventory.CursorIndex)
					App.Drawer.Draw(slot.Item.Sprite, Camera, Position + slot.Offset);

		ISprite cursorSprite = Inventory.Slots[Inventory.CursorIndex].Item.Sprite;
		Vector2D cursorPosition = App.GetMousePosition() -
								  new Vector2D(cursorSprite.Width(), cursorSprite.Height()) * Camera.Scale / 2;
		App.Drawer.Draw(cursorSprite, Camera, cursorPosition);
	}

	public bool WasMouseoverHandled { get; set; } = false;

	public bool IsMouseOver(Vector2D mousePosition)
	{
		if (Enabled)
			foreach (InventorySlot slot in Inventory.Slots)
			{
				Vector2D screenPosition =
					Camera.GetScreenPosition(Position + slot.Offset);
				if (slot.Index != Inventory.CursorIndex &&
					mousePosition.X >= screenPosition.X &&
					mousePosition.X <= screenPosition.X + slot.Item.Sprite.Width() * Camera.Scale &&
					mousePosition.Y >= screenPosition.Y &&
					mousePosition.Y <= screenPosition.Y + slot.Item.Sprite.Height() * Camera.Scale)
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
}
