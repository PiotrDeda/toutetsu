using Rokuro.Graphics;

namespace Toutetsu.Map;

public class Wall : MapObject
{
	public Wall() : base(SpriteManager.CreateSprite<StaticSprite>("wall")) {}
}
