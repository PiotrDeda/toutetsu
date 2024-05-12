using Rokuro.Inputs;
using Rokuro.MathUtils;
using Rokuro.Objects;
using Toutetsu.State;

namespace Toutetsu.Components;

public class DevMovable : GameObject
{
	public DevMovable()
	{
		Input.KeyDownEvent += HandleKeyDown;
	}

	public void HandleKeyDown(object? sender, KeyDownEventArgs e)
	{
		if (e.KeyEvent == KeyEvents.MoveDown)
			Coroutines.Start(MoveTo(Position + new Vector2I(0, 100), 1000, Interpolation.Sine));
		else if (e.KeyEvent == KeyEvents.MoveUp)
			Coroutines.Start(MoveTo(Position + new Vector2I(0, -100), 1000, Interpolation.Sine));
		else if (e.KeyEvent == KeyEvents.MoveLeft)
			Coroutines.Start(MoveTo(Position + new Vector2I(-100, 0), 1000, Interpolation.Sine));
		else if (e.KeyEvent == KeyEvents.MoveRight)
			Coroutines.Start(MoveTo(Position + new Vector2I(100, 0), 1000, Interpolation.Sine));
	}
}
