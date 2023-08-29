using Rokuro.Graphics;
using Rokuro.Objects;

namespace Toutetsu.Map;

public class GameMap : BaseObject, IDrawable
{
	public static readonly int TileSize = 64;

	public GameMap(Camera camera, int mapSize)
	{
		Camera = camera;
		MapSize = mapSize;
	}

	public int MapSize { get; private set; }

	Camera Camera { get; set; }

	public void Draw() {}
}
