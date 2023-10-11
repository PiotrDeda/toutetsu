using Rokuro.Graphics;
using Toutetsu.State;

namespace Toutetsu.Scenes;

public class SceneFight : Scene
{
	public SceneFight(Player player, FightManager fightManager)
	{
		Player = player;
	}

	Player Player { get; }
}
