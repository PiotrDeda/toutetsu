using Rokuro;
using Rokuro.Graphics;
using Rokuro.Objects;

namespace Toutetsu.Map;

public class Tile : BaseObject, IDrawable
{
	public Tile(Camera camera)
	{
		Camera = camera;
	}

	public Camera Camera { get; set; }
	public MapObject? MapObject { get; set; }

	public void Draw()
	{
		if (Enabled && MapObject is not null)
			App.Drawer.Draw(MapObject.Sprite, Camera, Position);
	}
}
