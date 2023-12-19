using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;

namespace Toutetsu.Components;

public class QuitButton : InteractableObject
{
	public QuitButton(Vector2D position, Camera camera, SpriteManager spriteManager, IQuittable quittable) :
		base(position, spriteManager.CreateSprite<StaticSprite>("quit_button"), camera)
	{
		Quittable = quittable;
	}

	IQuittable Quittable { get; }

	public override void OnClick() => Quittable.Quit();
}
