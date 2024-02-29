using Rokuro.Core;
using Rokuro.MathUtils;
using Toutetsu.Enemies;
using Toutetsu.Items;
using Toutetsu.State;
using static Toutetsu.Map.RandomMapGenerator.MapValues;

namespace Toutetsu.Map;

public class RandomMapGenerator
{
	public enum MapValues
	{
		TileNothing = ' ',
		TileWallRandom = 'W',
		TileWall = 'w',
		TileWallTorch = 't',
		TileFloor = '.',
		TileEntrance = 'O',
		TileExit = 'X',
		TileItem = 'I',
		TileEnemy = 'E',
		ReservedFloor = '$'
	}

	public RandomMapGenerator(RandomItemGenerator randomItemGenerator, RandomEnemyGenerator randomEnemyGenerator,
		FightManager fightManager, ILevelHandler levelHandler)
	{
		RandomItemGenerator = randomItemGenerator;
		RandomEnemyGenerator = randomEnemyGenerator;
		FightManager = fightManager;
		LevelHandler = levelHandler;
	}

	RandomItemGenerator RandomItemGenerator { get; }
	RandomEnemyGenerator RandomEnemyGenerator { get; }
	FightManager FightManager { get; }
	ILevelHandler LevelHandler { get; }

	public void Generate(GameMap objectMap, RandomMapParameters p, int currentLevel)
	{
		// Create map to store tile values
		var valueMap = new MapValues[objectMap.MapSize, objectMap.MapSize];
		for (int i = 0; i < objectMap.MapSize; i++)
			for (int j = 0; j < objectMap.MapSize; j++)
				valueMap[i, j] = TileNothing;

		// Generate room amount
		int roomAmount = RNG.Rand.Next(p.MinRoomAmount, p.MaxRoomAmount + 1);

		// Generate room grid locations
		int gridSize = (int)Math.Floor(Math.Sqrt(roomAmount * 2));
		List<Vector2D> roomGridLocations = new();
		for (int x = 0; x < gridSize; x++)
			for (int y = 0; y < gridSize; y++)
				roomGridLocations.Add(new(x, y));
		roomGridLocations = roomGridLocations.OrderBy(_ => RNG.Rand.Next()).ToList();

		// Generate rooms
		List<Vector2D> roomCenters = new();
		for (int i = 0; i < roomAmount; i++)
		{
			roomCenters.Add(new(
				RNG.Rand.Next(roomGridLocations[i].X * objectMap.MapSize / gridSize + 1,
					(roomGridLocations[i].X + 1) * objectMap.MapSize / gridSize - 2),
				RNG.Rand.Next(roomGridLocations[i].Y * objectMap.MapSize / gridSize + 1,
					(roomGridLocations[i].Y + 1) * objectMap.MapSize / gridSize - 2)
			));
			Vector2D size = new(RNG.Rand.Next(p.MinRoomSize, p.MaxRoomSize + 1),
				RNG.Rand.Next(p.MinRoomSize, p.MaxRoomSize + 1));
			PlaceRoom(valueMap, roomCenters[i], size.X, size.X, size.Y, size.Y);
			Logger.LogInfo($"Placed room [{i}] (grid: {roomGridLocations[i]}) at {roomCenters[i]} with size {size}");
		}

		// Generate corridors
		List<RoomConnection> roomConnections = new();
		for (int i = 0; i < roomAmount; i++)
			for (int j = i + 1; j < roomAmount; j++)
				roomConnections.Add(new(i, j,
					Math.Abs(roomCenters[i].X - roomCenters[j].X) + Math.Abs(roomCenters[i].Y - roomCenters[j].Y)));
		roomConnections.Sort((a, b) => a.Distance.CompareTo(b.Distance));
		for (int i = 0; i < roomAmount - 1; i++)
		{
			PlaceCorridor(valueMap, roomCenters[roomConnections[i].Room1], roomCenters[roomConnections[i].Room2]);
			Logger.LogInfo(
				$"Placed corridor between rooms [{roomConnections[i].Room1}] and [{roomConnections[i].Room2}]");
		}

		// Detect room clusters
		var roomCluster = Enumerable.Repeat(-1, roomAmount).ToList();
		int clusterCount = 0;
		for (int i = 0; i < roomAmount; i++)
		{
			if (roomCluster[i] != -1)
				continue;
			roomCluster[i] = clusterCount;
			Queue<int> roomQueue = new();
			roomQueue.Enqueue(i);
			while (roomQueue.Count != 0)
			{
				int room = roomQueue.Dequeue();
				for (int j = 0; j < roomAmount - 1; j++)
					if (roomConnections[j].Room1 == room && roomCluster[roomConnections[j].Room2] == -1)
					{
						roomCluster[roomConnections[j].Room2] = clusterCount;
						roomQueue.Enqueue(roomConnections[j].Room2);
					}
					else if (roomConnections[j].Room2 == room && roomCluster[roomConnections[j].Room1] == -1)
					{
						roomCluster[roomConnections[j].Room1] = clusterCount;
						roomQueue.Enqueue(roomConnections[j].Room1);
					}
			}

			clusterCount++;
		}

		clusterCount--;

		// Place corridors between closest rooms in separate room clusters
		for (int i = 1; i <= clusterCount; i++)
		{
			int room1 = -1, room2 = -1;
			int minDistance = int.MaxValue;
			for (int j = 0; j < roomAmount; j++)
			{
				for (int k = j + 1; k < roomAmount; k++)
				{
					int distance = Math.Abs(roomCenters[j].X - roomCenters[k].X) +
								   Math.Abs(roomCenters[j].Y - roomCenters[k].Y);
					if (distance < minDistance && ((roomCluster[j] == i && roomCluster[k] == i - 1) ||
												   (roomCluster[j] == i - 1 && roomCluster[k] == i)))
					{
						room1 = j;
						room2 = k;
						minDistance = distance;
					}
				}
			}

			PlaceCorridor(valueMap, roomCenters[room1], roomCenters[room2]);
			Logger.LogInfo($"Placed corridor between clustered rooms [{room1}] and [{room2}]");
		}

		// Place entrance and exit
		int startRoom = roomConnections.Last().Room1;
		int endRoom = roomConnections.Last().Room2;
		valueMap[roomCenters[startRoom].X, roomCenters[startRoom].Y] = TileEntrance;
		valueMap[roomCenters[endRoom].X, roomCenters[endRoom].Y] = TileExit;
		Logger.LogInfo($"Placed entrance in room [{startRoom}] and exit in room [{endRoom}]");

		// Reserve room around entrance
		for (int i = -1; i <= 1; i++)
			for (int j = -1; j <= 1; j++)
				if (valueMap[roomCenters[startRoom].X + i, roomCenters[startRoom].Y + j] == TileFloor)
					valueMap[roomCenters[startRoom].X + i, roomCenters[startRoom].Y + j] = ReservedFloor;

		// Generate enemies
		for (int i = 0; i < valueMap.GetLength(0); i++)
			for (int j = 0; j < valueMap.GetLength(1); j++)
				if (valueMap[i, j] == TileFloor && RNG.Rand.Next(100) < p.EnemyChance)
					valueMap[i, j] = TileEnemy;

		// Generate items
		for (int i = 0; i < valueMap.GetLength(0); i++)
			for (int j = 0; j < valueMap.GetLength(1); j++)
				if (valueMap[i, j] == TileFloor && RNG.Rand.Next(100) < p.ItemChance)
					valueMap[i, j] = TileItem;

		// Convert reserved floor to regular floor
		for (int i = 0; i < valueMap.GetLength(0); i++)
			for (int j = 0; j < valueMap.GetLength(1); j++)
				if (valueMap[i, j] == ReservedFloor)
					valueMap[i, j] = TileFloor;

		// Convert to real map
		ConvertValueMapToObjectMap(valueMap, objectMap, p, currentLevel);
	}

	void PlaceRoom(MapValues[,] valueMap, Vector2D center, int sizeXLeft, int sizeXRight, int sizeYTop, int sizeYBottom)
	{
		// Trim size to map edges
		if (center.X - sizeXLeft < 0)
			sizeXLeft = center.X;
		if (center.X + sizeXRight >= valueMap.GetLength(0))
			sizeXRight = valueMap.GetLength(0) - center.X - 1;
		if (center.Y - sizeYTop < 0)
			sizeYTop = center.Y;
		if (center.Y + sizeYBottom >= valueMap.GetLength(1))
			sizeYBottom = valueMap.GetLength(1) - center.Y - 1;

		// Place floor
		for (int x = center.X - sizeXLeft + 1; x <= center.X + sizeXRight - 1; x++)
			for (int y = center.Y - sizeYTop + 1; y <= center.Y + sizeYBottom - 1; y++)
				valueMap[x, y] = TileFloor;

		// Place top and bottom walls
		for (int x = center.X - sizeXLeft; x <= center.X + sizeXRight; x++)
		{
			if (valueMap[x, center.Y - sizeYTop] == TileNothing)
				valueMap[x, center.Y - sizeYTop] = TileWallRandom;
			if (valueMap[x, center.Y + sizeYBottom] == TileNothing)
				valueMap[x, center.Y + sizeYBottom] = TileWallRandom;
		}

		// Place left and right walls
		for (int y = center.Y - sizeYTop; y <= center.Y + sizeYBottom; y++)
		{
			if (valueMap[center.X - sizeXLeft, y] == TileNothing)
				valueMap[center.X - sizeXLeft, y] = TileWallRandom;
			if (valueMap[center.X + sizeXRight, y] == TileNothing)
				valueMap[center.X + sizeXRight, y] = TileWallRandom;
		}
	}

	void PlaceCorridor(MapValues[,] valueMap, Vector2D beginning, Vector2D end)
	{
		Action<int, int> placeCorridorTile = (x, y) => {
			valueMap[x, y] = TileFloor;
			for (int i = -1; i <= 1; i++)
				for (int j = -1; j <= 1; j++)
					if (valueMap[x + i, y + j] == TileNothing)
						valueMap[x + i, y + j] = TileWallRandom;
		};

		if (RNG.Rand.Next(2) == 0)
		{
			for (int x = Math.Min(beginning.X, end.X); x <= Math.Max(beginning.X, end.X); x++)
				placeCorridorTile(x, beginning.Y);
			for (int y = Math.Min(beginning.Y, end.Y); y <= Math.Max(beginning.Y, end.Y); y++)
				placeCorridorTile(end.X, y);
		}
		else
		{
			for (int y = Math.Min(beginning.Y, end.Y); y <= Math.Max(beginning.Y, end.Y); y++)
				placeCorridorTile(beginning.X, y);
			for (int x = Math.Min(beginning.X, end.X); x <= Math.Max(beginning.X, end.X); x++)
				placeCorridorTile(x, end.Y);
		}
	}

	void ConvertValueMapToObjectMap(MapValues[,] valueMap, GameMap objectMap, RandomMapParameters p, int currentLevel)
	{
		objectMap.Clear();
		for (int x = 0; x < objectMap.MapSize; x++)
		{
			for (int y = 0; y < objectMap.MapSize; y++)
				switch (valueMap[x, y])
				{
					case TileWall:
						objectMap.WallLayer[x, y].MapObject = new Wall();
						break;
					case TileWallTorch:
						objectMap.WallLayer[x, y].MapObject = new WallTorch();
						break;
					case TileWallRandom:
						if (RNG.Rand.Next(100) < p.TorchChance)
							objectMap.WallLayer[x, y].MapObject = new WallTorch();
						else
							objectMap.WallLayer[x, y].MapObject = new Wall();
						break;
					case TileFloor:
						objectMap.FloorLayer[x, y].MapObject = new Floor();
						break;
					case TileEntrance:
					{
						objectMap.FloorLayer[x, y].MapObject = new Floor();
						objectMap.InteractLayer[x, y].MapObject = new PlayerPuppet();
						objectMap.Player.Position = new(x, y);
						break;
					}
					case TileExit:
						objectMap.FloorLayer[x, y].MapObject = new Floor();
						objectMap.InteractLayer[x, y].MapObject = new LevelExit(LevelHandler);
						objectMap.ExitPosition = new(x, y);
						break;
					case TileItem:
						objectMap.FloorLayer[x, y].MapObject = new Floor();
						objectMap.InteractLayer[x, y].MapObject = new PickupItem(RandomItemGenerator.Generate(
							RandomItemGenerator.GetTypeFromLevel(currentLevel)));
						break;
					case TileEnemy:
						objectMap.FloorLayer[x, y].MapObject = new Floor();
						objectMap.InteractLayer[x, y].MapObject = new LevelExit(LevelHandler);
						objectMap.InteractLayer[x, y].MapObject = new Unit(RandomEnemyGenerator.Generate(
							RandomEnemyGenerator.GetTypeFromLevel(currentLevel)), FightManager);
						break;
				}
		}
	}

	public record RandomMapParameters(
		int MinRoomAmount = 8,
		int MaxRoomAmount = 10,
		int MinRoomSize = 2,
		int MaxRoomSize = 4,
		int TorchChance = 10,
		int ItemChance = 4,
		int EnemyChance = 4
	);

	record RoomConnection(int Room1, int Room2, int Distance);
}
