using Rokuro.Graphics;
using Rokuro.Inputs;
using Rokuro.MathUtils;
using Rokuro.Objects;
using Toutetsu.State;

namespace Toutetsu.Components;

public class InventoryView : GameObject, IMouseInteractable
{
	public InventoryView(Inventory inventory, Camera camera, Input input)
	{
		Inventory = inventory;
		Camera = camera;
		Input = input;
	}

	public bool EquipmentLocked { get; set; } = false;

	Inventory Inventory { get; }
	Input Input { get; }
	int LastClickedIndex { get; set; }

	public bool WasMouseoverHandled { get; set; } = false;

	public bool IsMouseOver(Vector2D mousePosition)
	{
		if (Enabled && Camera != null)
			foreach (InventorySlot slot in Inventory.Slots)
			{
				Vector2D screenPosition = Camera.GetScreenPosition(Position + slot.Offset);
				if (slot.Index != Inventory.CursorIndex &&
					mousePosition.X >= screenPosition.X &&
					mousePosition.X <= screenPosition.X + slot.Item.Sprite.GetWidth() * Camera.Scale &&
					mousePosition.Y >= screenPosition.Y &&
					mousePosition.Y <= screenPosition.Y + slot.Item.Sprite.GetHeight() * Camera.Scale)
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
				Camera.Draw(slot.Item.Sprite, Position + slot.Offset);

		ISprite cursorSprite = Inventory.Slots[Inventory.CursorIndex].Item.Sprite;
		Vector2D cursorPosition = Input.GetMousePosition() -
								  new Vector2D(cursorSprite.GetWidth(), cursorSprite.GetHeight()) * Camera.Scale / 2;
		Camera.Draw(cursorSprite, cursorPosition);
	}
}
