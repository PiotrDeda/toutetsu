using Rokuro.Graphics;

namespace Toutetsu.Map;

public class WallTorch : MapObject
{
	public WallTorch(SpriteManager spriteManager) : base(spriteManager.CreateSpriteFromTemplate("wall_torch")) {}
}
