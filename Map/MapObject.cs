using Rokuro.Graphics;
using Toutetsu.State;

namespace Toutetsu.Map;

public class MapObject(Sprite sprite)
{
	public Sprite Sprite { get; set; } = sprite;

	public virtual bool OnInteract(Player player) => false;
}
