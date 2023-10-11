using Rokuro.Graphics;

namespace Toutetsu.Items;

public class BlankItem : ItemData
{
	public BlankItem(SpriteManager spriteManager)
	{
		Sprite = spriteManager.CreateSpriteFromTemplate("blank_item");
		Type = ItemType.Blank;
	}
}
