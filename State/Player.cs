using Rokuro.Graphics;
using Rokuro.MathUtils;

namespace Toutetsu.State;

public class Player
{
	public Player(SpriteManager spriteManager)
	{
		Inventory = new(spriteManager, Stats);
	}

	public Vector2D Position { get; set; }
	public PlayerStats Stats { get; } = new();
	public Inventory Inventory { get; }
}
