using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;

namespace Toutetsu.Components;

public class StaticQuitButton : InteractableObject
{
	public StaticQuitButton(Vector2D position, ISprite sprite, Camera camera) : base(position, sprite, camera) {}

	public override void OnClick() => App.Quit();
}
