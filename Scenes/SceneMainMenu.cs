using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneMainMenu : Scene
{
	public SceneMainMenu(SpriteManager spriteManager, SceneManager sceneManager, Drawer drawer, IQuittable appQuittable)
	{
		Name = "Main Menu";
		Camera = new("Camera", drawer);

		GameObject title = new(new(482, 64), spriteManager.CreateSprite<StaticSprite>("title"), Camera);
		RegisterGameObject(title);

		PlayButton playButton = new(new(482, 317), Camera, spriteManager, sceneManager);
		RegisterGameObject(playButton);

		QuitButton quitButton = new(new(482, 445), Camera, spriteManager, appQuittable);
		RegisterGameObject(quitButton);

		DevButton devButton = new(new(1160, 600), Camera, spriteManager, sceneManager);
		RegisterGameObject(devButton);
	}

	UICamera Camera { get; }
}
