using Rokuro.Graphics;

namespace Toutetsu.Map;

public class Floor : MapObject
{
	public Floor() : base(SpriteManager.CreateSprite<StaticSprite>("floor")) {}
}
