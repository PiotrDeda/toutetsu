using Rokuro.Graphics;

namespace Toutetsu.Map;

public class PlayerPuppet : MapObject
{
	public PlayerPuppet() : base(SpriteManager.CreateSprite<AnimatedSprite>("tiles/player")) {}
}
