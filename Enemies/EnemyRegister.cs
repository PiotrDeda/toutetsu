using Rokuro.Core;
using Rokuro.Graphics;

namespace Toutetsu.Enemies;

public class EnemyRegister
{
	public EnemyRegister()
	{
		BlankEnemy = new("blank_enemy", "NULL", SpriteManager.CreateSprite<StaticSprite>("items/blank_item"),
			SpriteManager.CreateSprite<StaticSprite>("items/blank_item"), new());
		Enemies.Add("blank_enemy", BlankEnemy);
	}

	Dictionary<string, EnemyData> Enemies { get; } = new();
	EnemyData BlankEnemy { get; }

	public void LoadEnemyData()
	{
		try
		{
			EnemyData.FromYaml(File.ReadAllText(Path.Combine("assets", "data", "enemies.yaml")))
				.ToList().ForEach(x => Enemies.Add(x.Key, x.Value));
		}
		catch (Exception e)
		{
			Logger.ThrowError($"Couldn't load enemies: {e.Message}");
		}
	}

	public EnemyData GetEnemy(string id)
	{
		if (Enemies.TryGetValue(id, out EnemyData? enemy))
			return enemy;

		Logger.ThrowError($"Enemy \"{id}\" not found");
		return BlankEnemy;
	}
}
