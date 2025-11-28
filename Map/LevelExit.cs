using Rokuro.Graphics;
using Toutetsu.State;

namespace Toutetsu.Map;

public class LevelExit(ILevelHandler levelHandler) : MapObject(SpriteManager.CreateSprite<StaticSprite>("tiles/floor_exit"))
{
	ILevelHandler LevelHandler { get; } = levelHandler;

	public override bool OnInteract(Player player)
	{
		LevelHandler.NextLevel();
		return true;
	}
}
