using Rokuro;
using Toutetsu.State;

namespace Toutetsu.Map;

public class FloorExit : MapObject
{
	public FloorExit() : base(App.GetSprite("floor_exit")) {}

	public override bool OnInteract()
	{
		GameState.NextLevel();
		return true;
	}
}
