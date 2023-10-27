using Rokuro.Graphics;

namespace Toutetsu.Map;

public class PlayerPuppet : MapObject
{
	public PlayerPuppet(SpriteManager spriteManager) : base(spriteManager.CreateSprite<AnimatedSprite>("player")) {}
}
