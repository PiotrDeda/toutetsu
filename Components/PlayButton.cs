using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Loaders;

namespace Toutetsu.Components;

public class PlayButton : InteractableObject
{
	public PlayButton(Camera camera, SpriteManager spriteManager, SceneManager sceneManager) :
		base(spriteManager.CreateSprite<StaticSprite>("play_button"), camera)
	{
		SceneManager = sceneManager;
	}

	SceneManager SceneManager { get; }

	public override void OnClick() => SceneManager.SetNextScene((int)SceneID.GameMap);
}
