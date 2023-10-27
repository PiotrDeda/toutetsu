using Rokuro.Graphics;

namespace Toutetsu.Map;

public class Wall : MapObject
{
	public Wall(SpriteManager spriteManager) : base(spriteManager.CreateSprite<StaticSprite>("wall")) {}
}
