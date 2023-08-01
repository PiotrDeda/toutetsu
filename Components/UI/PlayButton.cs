using Rokuro;
using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Scenes;

namespace Toutetsu.Components.UI;

public class PlayButton : InteractableObject
{
	public PlayButton(Camera camera) : base(App.GetSprite("play_button"), camera) {}

	public override void OnClick() => App.SceneManager.SetNextScene((int)SceneID.GameMap);
}
