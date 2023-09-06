using Rokuro.Core;

namespace Toutetsu.Map;

public class Floor : MapObject
{
	public Floor() : base(App.SpriteManager.CreateSpriteFromTemplate("floor")) {}
}
