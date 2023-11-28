using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Loaders;

namespace Toutetsu.Components;

public class DevButton : InteractableObject
{
	public DevButton(Camera camera, SpriteManager spriteManager, SceneManager sceneManager) :
		base(spriteManager.CreateSprite<StaticSprite>("dev_button"), camera)
	{
		SceneManager = sceneManager;
	}

	SceneManager SceneManager { get; }

	public override void OnClick() => SceneManager.SetNextScene((int)SceneID.Debug);
}
