using Rokuro.Objects;

namespace Toutetsu.Components;

public class DebugButton : InteractableObject
{
	public override void OnClick() => SceneManager.SetNextScene("Debug");
}
