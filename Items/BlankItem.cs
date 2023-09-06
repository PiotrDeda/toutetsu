using Rokuro.Core;

namespace Toutetsu.Items;

public class BlankItem : ItemData
{
	public BlankItem()
	{
		Sprite = App.SpriteManager.CreateSpriteFromTemplate("blank_item");
		Type = ItemType.Blank;
	}
}
