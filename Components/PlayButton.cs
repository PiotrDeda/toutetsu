using Rokuro.Graphics;
using Rokuro.Objects;

namespace Toutetsu.Components;

public class PlayButton : InteractableObject
{
	public override void OnClick() => SceneManager.SetNextScene("Game Map");
}
