using Rokuro.Inputs;

namespace Toutetsu.State;

public record KeyEvents
{
	public static readonly KeyEvent MoveDown = new();
	public static readonly KeyEvent MoveUp = new();
	public static readonly KeyEvent MoveLeft = new();
	public static readonly KeyEvent MoveRight = new();
	public static readonly KeyEvent CenterCamera = new();
}
