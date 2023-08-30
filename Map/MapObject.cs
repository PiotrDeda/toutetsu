using Rokuro.Graphics;

namespace Toutetsu.Map;

public class MapObject
{
	public MapObject(Sprite sprite)
	{
		Sprite = sprite;
	}

	public Sprite Sprite { get; set; }

	public virtual bool OnInteract() => false;
}
