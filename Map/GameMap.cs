using Rokuro.Graphics;
using Rokuro.MathUtils;
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
		for (int i = 0; i < mapSize; i++)
		{
			for (int j = 0; j < mapSize; j++)
			{
				var position = new Vector2D(i * TileSize, j * TileSize);
				FloorLayer[i, j] = new Tile(Camera, position);
				WallLayer[i, j] = new Tile(Camera, position);
				InteractLayer[i, j] = new Tile(Camera, position);
			}
		}
	}

	public int MapSize { get; }
	public Tile[,] FloorLayer { get; }
	public Tile[,] WallLayer { get; }
	public Tile[,] InteractLayer { get; }
	public Vector2D PlayerPosition { get; set; }
	public Vector2D ExitPosition { get; set; }

	Camera Camera { get; }

	public void Draw()
	{
		foreach (Tile tile in FloorLayer)
			tile.Draw();
		foreach (Tile tile in WallLayer)
			tile.Draw();
		foreach (Tile tile in InteractLayer)
			tile.Draw();
	}

	public void MoveInteract(Vector2D oldPosition, Vector2D newPosition)
	{
		InteractLayer[newPosition.X, newPosition.Y].MapObject = InteractLayer[oldPosition.X, oldPosition.Y].MapObject;
		InteractLayer[oldPosition.X, oldPosition.Y].MapObject = null;
	}

	public void MovePlayer(Vector2D direction)
	{
		var dest = new Vector2D(PlayerPosition.X + direction.X, PlayerPosition.Y + direction.Y);

		if (dest.X >= 0 && dest.X < MapSize && dest.Y >= 0 && dest.Y < MapSize)
			if (WallLayer[dest.X, dest.Y].MapObject is null &&
				FloorLayer[dest.X, dest.Y].MapObject is not null)
			{
				MapObject? mapObject = InteractLayer[dest.X, dest.Y].MapObject;
				if (mapObject is not null && mapObject.OnInteract())
					return;
				MoveInteract(PlayerPosition, dest);
				PlayerPosition += direction;
				Camera.Position += direction * TileSize;
			}

		var playerSprite = (AnimatedSprite)InteractLayer[PlayerPosition.X, PlayerPosition.Y].MapObject!.Sprite;
		if (direction.X == 0 && direction.Y == 1)
			playerSprite.State = 0;
		else if (direction.X == 0 && direction.Y == -1)
			playerSprite.State = 1;
		else if (direction.X == -1 && direction.Y == 0)
			playerSprite.State = 2;
		else if (direction.X == 1 && direction.Y == 0)
			playerSprite.State = 3;
	}

	public void Clear()
	{
		foreach (Tile tile in FloorLayer)
			tile.MapObject = null;
		foreach (Tile tile in WallLayer)
			tile.MapObject = null;
		foreach (Tile tile in InteractLayer)
			tile.MapObject = null;
	}
}
