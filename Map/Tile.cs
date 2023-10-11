using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;

namespace Toutetsu.Map;

public class Tile : BaseObject, IDrawable
{
	public Tile(Camera camera, Vector2D position)
	{
		Camera = camera;
		Position = position;
	}

	public Camera Camera { get; set; }
	public MapObject? MapObject { get; set; }

	public void Draw()
	{
		if (Enabled && MapObject is not null)
			Camera.Draw(MapObject.Sprite, Position);
	}
}
