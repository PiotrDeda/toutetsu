using Rokuro.Core;

namespace Toutetsu.Map;

public class Wall : MapObject
{
	public Wall() : base(App.SpriteManager.CreateSpriteFromTemplate("wall")) {}
}
