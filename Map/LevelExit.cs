using Rokuro.Graphics;
using Toutetsu.State;

namespace Toutetsu.Map;

public class LevelExit : MapObject
{
	public LevelExit(ILevelHandler levelHandler) :
		base(SpriteManager.CreateSprite<StaticSprite>("floor_exit"))
	{
		LevelHandler = levelHandler;
	}

	ILevelHandler LevelHandler { get; }

	public override bool OnInteract(Player player)
	{
		LevelHandler.NextLevel();
		return true;
	}
}
