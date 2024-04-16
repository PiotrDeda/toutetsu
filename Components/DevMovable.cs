using Rokuro.Graphics;
using Rokuro.Inputs;
using Rokuro.MathUtils;
using Rokuro.Objects;
using Toutetsu.State;

namespace Toutetsu.Components;

public class DevMovable : GameObject, IEventReceiver
{
	public DevMovable(Vector2D position, Sprite sprite, Camera camera) : base(position, sprite, camera) {}

	public void HandleEvent(IInputEvent e)
	{
		if (e is KeyEvent keyEvent && keyEvent == KeyEvents.MoveDown)
			Position += new Vector2D(0, 10);
	}
}
