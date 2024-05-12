using Rokuro.MathUtils;

namespace Toutetsu.State;

public class Player
{
	public Player()
	{
		Inventory = new(Stats);
	}

	public Vector2I Position { get; set; } = Vector2I.Zero;
	public PlayerStats Stats { get; } = new();
	public Inventory Inventory { get; }
}
