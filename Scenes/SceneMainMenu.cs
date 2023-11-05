using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneMainMenu : Scene
{
	public SceneMainMenu(SpriteManager spriteManager, SceneManager sceneManager, Drawer drawer, WindowData windowData,
		IQuittable appQuittable)
	{
		Name = "SceneMainMenu";
		Camera = new(drawer, windowData);

		SimpleObject title = new(spriteManager.CreateSprite<StaticSprite>("title"), Camera);
		title.Position = new(482, 64);
		RegisterGameObject(title);

		PlayButton playButton = new(Camera, spriteManager, sceneManager);
		playButton.Position = new(482, 317);
		RegisterGameObject(playButton);

		QuitButton quitButton = new(Camera, spriteManager, appQuittable);
		quitButton.Position = new(482, 445);
		RegisterGameObject(quitButton);

		DevButton devButton = new(Camera, spriteManager, sceneManager);
		devButton.Position = new(1160, 600);
		RegisterGameObject(devButton);
	}

	UICamera Camera { get; }
}
