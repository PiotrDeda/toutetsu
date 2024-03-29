using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;

namespace Toutetsu.Map;

public class Tile : GameObject
{
	public Tile(Camera camera, Vector2D position)
	{
		Camera = camera;
		Position = position;
	}

	public MapObject? MapObject { get; set; }

	public override void Draw()
	{
		if (Enabled && MapObject != null && Camera != null)
			Camera.Draw(MapObject.Sprite, Position);
	}
}
