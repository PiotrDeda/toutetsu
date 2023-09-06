using Rokuro.Graphics;

namespace Toutetsu.Map;

public class MapObject
{
	public MapObject(ISprite sprite)
	{
		Sprite = sprite;
	}

	public ISprite Sprite { get; set; }

	public virtual bool OnInteract() => false;
}
