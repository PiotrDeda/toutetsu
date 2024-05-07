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
			Position += new Vector2I(0, 10);
	}
}
