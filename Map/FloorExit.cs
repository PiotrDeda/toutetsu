using Rokuro.Core;
using Toutetsu.State;

namespace Toutetsu.Map;

public class FloorExit : MapObject
{
	public FloorExit() : base(App.SpriteManager.CreateSpriteFromTemplate("floor_exit")) {}

	public override bool OnInteract()
	{
		GameState.NextLevel();
		return true;
	}
}
