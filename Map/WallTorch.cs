using Rokuro.Graphics;

namespace Toutetsu.Map;

public class WallTorch : MapObject
{
	public WallTorch() : base(SpriteManager.CreateSprite<AnimatedSprite>("tiles/wall_torch")) {}
}
