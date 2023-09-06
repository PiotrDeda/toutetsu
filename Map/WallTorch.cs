using Rokuro.Core;

namespace Toutetsu.Map;

public class WallTorch : MapObject
{
	public WallTorch() : base(App.SpriteManager.CreateSpriteFromTemplate("wall_torch")) {}
}
