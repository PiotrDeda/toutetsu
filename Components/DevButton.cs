using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;
using Toutetsu.Loaders;

namespace Toutetsu.Components;

public class DevButton : InteractableObject
{
	public DevButton(Vector2D position, Camera camera, SpriteManager spriteManager, SceneManager sceneManager) :
		base(position, spriteManager.CreateSprite<StaticSprite>("dev_button"), camera)
	{
		SceneManager = sceneManager;
	}

	SceneManager SceneManager { get; }

	public override void OnClick() => SceneManager.SetNextScene("Debug");
}
