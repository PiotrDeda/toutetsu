using Rokuro.Graphics;
using Rokuro.Objects;

namespace Toutetsu.Components;

public class DevButton : InteractableObject
{
	public override void OnClick() => SceneManager.SetNextScene("Debug");
}
