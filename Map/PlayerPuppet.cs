using Rokuro.Core;

namespace Toutetsu.Map;

public class PlayerPuppet : MapObject
{
	public PlayerPuppet() : base(App.SpriteManager.CreateSpriteFromTemplate("player")) {}
}
