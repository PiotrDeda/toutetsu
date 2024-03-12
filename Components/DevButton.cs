using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;

namespace Toutetsu.Components;

public class DevButton : InteractableObject
{
	public DevButton(Vector2D position, Camera camera) :
		base(position, SpriteManager.CreateSprite<StaticSprite>("ui/dev_button"), camera) {}

	public override void OnClick() => SceneManager.SetNextScene("Debug");
}
