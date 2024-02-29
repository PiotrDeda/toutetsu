using Rokuro.MathUtils;

namespace Toutetsu.State;

public class Player
{
	public Player()
	{
		Inventory = new(Stats);
	}

	public Vector2D Position { get; set; }
	public PlayerStats Stats { get; } = new();
	public Inventory Inventory { get; }
}
