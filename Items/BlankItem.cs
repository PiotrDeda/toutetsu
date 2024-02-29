using Rokuro.Graphics;

namespace Toutetsu.Items;

public class BlankItem : ItemData
{
	public BlankItem()
	{
		Sprite = SpriteManager.CreateSprite<StaticSprite>("blank_item");
		Type = ItemType.Blank;
	}
}
