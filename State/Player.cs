using Rokuro.Graphics;
using Rokuro.MathUtils;
using Toutetsu.Map;

namespace Toutetsu.State;

public class Player
{
	public Player(SpriteManager spriteManager)
	{
		Puppet = new(spriteManager);
		Inventory = new(spriteManager, Stats);
	}

	public Vector2D Position { get; set; }
	public PlayerPuppet Puppet { get; }
	public PlayerStats Stats { get; } = new();
	public Inventory Inventory { get; }
}
