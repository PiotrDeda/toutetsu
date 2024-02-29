using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;

namespace Toutetsu.Components;

public class PlayButton : InteractableObject
{
	public PlayButton(Vector2D position, Camera camera) :
		base(position, SpriteManager.CreateSprite<StaticSprite>("play_button"), camera) {}

	public override void OnClick() => SceneManager.SetNextScene("Game Map");
}
