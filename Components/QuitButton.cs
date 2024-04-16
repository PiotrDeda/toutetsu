using Rokuro.Core;
using Rokuro.Objects;

namespace Toutetsu.Components;

public class QuitButton : InteractableObject
{
	public override void OnClick() => App.Quit();
}
