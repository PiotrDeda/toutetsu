using Rokuro;
using Rokuro.Graphics;
using Rokuro.Objects;

namespace Toutetsu.Components;

public class QuitButton : InteractableObject
{
	public QuitButton(Camera camera) : base(App.GetSprite("quit_button"), camera) {}

	public override void OnClick() => App.Quit();
}
