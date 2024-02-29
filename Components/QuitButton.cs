using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;

namespace Toutetsu.Components;

public class QuitButton : InteractableObject
{
	public QuitButton(Vector2D position, Camera camera) :
		base(position, SpriteManager.CreateSprite<StaticSprite>("quit_button"), camera) {}


	public override void OnClick() => App.Quit();
}
