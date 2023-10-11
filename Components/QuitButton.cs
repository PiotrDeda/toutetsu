using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Objects;

namespace Toutetsu.Components;

public class QuitButton : InteractableObject
{
	public QuitButton(Camera camera, SpriteManager spriteManager, IQuittable quittable) :
		base(spriteManager.CreateSpriteFromTemplate("quit_button"), camera)
	{
		Quittable = quittable;
	}

	IQuittable Quittable { get; }

	public override void OnClick() => Quittable.Quit();
}
