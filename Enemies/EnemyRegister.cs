using Rokuro.Core;
using Rokuro.Graphics;

namespace Toutetsu.Enemies;

public class EnemyRegister
{
	public EnemyRegister(SpriteManager spriteManager)
	{
		SpriteManager = spriteManager;
		BlankEnemy = new("blank_enemy", "NULL", spriteManager.CreateSprite<StaticSprite>("blank_item"),
			spriteManager.CreateSprite<StaticSprite>("blank_item"), new());
		Enemies.Add("blank_enemy", BlankEnemy);
	}

	SpriteManager SpriteManager { get; }
	Dictionary<string, EnemyData> Enemies { get; } = new();
	EnemyData BlankEnemy { get; }

	public void LoadEnemyData()
	{
		// TODO: Switch to YAML files?
		try
		{
			EnemyData.FromToml(File.ReadAllText("assets/data/enemies/enemies.toml"), SpriteManager)
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

		Logger.LogWarning($"Enemy \"{id}\" not found");
		return BlankEnemy;
	}
}
