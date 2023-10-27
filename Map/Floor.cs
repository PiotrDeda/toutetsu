using Rokuro.Graphics;

namespace Toutetsu.Map;

public class Floor : MapObject
{
	public Floor(SpriteManager spriteManager) : base(spriteManager.CreateSprite<StaticSprite>("floor")) {}
}
