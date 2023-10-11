using Rokuro.Graphics;
using Toutetsu.State;

namespace Toutetsu.Map;

public class LevelExit : MapObject
{
	public LevelExit(SpriteManager spriteManager, ILevelHandler levelHandler) :
		base(spriteManager.CreateSpriteFromTemplate("floor_exit"))
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
