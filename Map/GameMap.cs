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
		FloorLayer = new Tile[mapSize, mapSize];
		WallLayer = new Tile[mapSize, mapSize];
		InteractLayer = new Tile[mapSize, mapSize];
	}

	public int MapSize { get; private set; }
	public PlayerPuppet? Player { get; set; }

	Camera Camera { get; set; }
	Tile[,] FloorLayer { get; set; }
	Tile[,] WallLayer { get; set; }
	Tile[,] InteractLayer { get; set; }

	public void Draw() {}
}
