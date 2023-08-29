using Rokuro;

namespace Toutetsu.Items;

public class BlankItem : ItemData
{
	public BlankItem()
	{
		Sprite = App.GetSprite("blank_item");
		Type = ItemType.Blank;
	}
}
