using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;
using Toutetsu.Loaders;

namespace Toutetsu.Components;

public class PlayButton : InteractableObject
{
	public PlayButton(Vector2D position, Camera camera, SpriteManager spriteManager, SceneManager sceneManager) :
		base(position, spriteManager.CreateSprite<StaticSprite>("play_button"), camera)
	{
		SceneManager = sceneManager;
	}

	SceneManager SceneManager { get; }

	public override void OnClick() => SceneManager.SetNextScene("Game Map");
}
