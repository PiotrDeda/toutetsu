using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;
using Toutetsu.State;

namespace Toutetsu.Map;

public class GameMap : GameObject
{
	public static readonly int TileSize = 64;

	public GameMap(Camera camera, Player player, int mapSize)
	{
		Camera = camera;
		Player = player;
		MapSize = mapSize;

		FloorLayer = new Tile[mapSize, mapSize];
		WallLayer = new Tile[mapSize, mapSize];
		InteractLayer = new Tile[mapSize, mapSize];
		for (int i = 0; i < mapSize; i++)
		{
			for (int j = 0; j < mapSize; j++)
			{
				Vector2D position = new(i * TileSize, j * TileSize);
				FloorLayer[i, j] = new(Camera, position);
				WallLayer[i, j] = new(Camera, position);
				InteractLayer[i, j] = new(Camera, position);
			}
		}
	}

	public Player Player { get; }
	public int MapSize { get; }
	public Tile[,] FloorLayer { get; }
	public Tile[,] WallLayer { get; }
	public Tile[,] InteractLayer { get; }
	public Vector2D ExitPosition { get; set; }

	public override void Draw()
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
		// TODO: Refactor how object positioning works (shared handling between GameMap and Player is not good)
		Vector2D dest = new(Player.Position.X + direction.X, Player.Position.Y + direction.Y);

		if (dest.X >= 0 && dest.X < MapSize && dest.Y >= 0 && dest.Y < MapSize)
			if (WallLayer[dest.X, dest.Y].MapObject == null && FloorLayer[dest.X, dest.Y].MapObject != null)
			{
				MapObject? mapObject = InteractLayer[dest.X, dest.Y].MapObject;
				if (mapObject != null && mapObject.OnInteract(Player))
					return;
				MoveInteract(Player.Position, dest);
				Player.Position += direction;
				if (Camera != null)
					Camera.Position += direction * TileSize;
			}

		var playerSprite = (AnimatedSprite)InteractLayer[Player.Position.X, Player.Position.Y].MapObject!.Sprite;
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
