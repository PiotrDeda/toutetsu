using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneMainMenu : Scene
{
	public SceneMainMenu()
	{
		Name = "Main Menu";
		Camera = new("Camera");

		GameObject title = new(new(482, 64), SpriteManager.CreateSprite<StaticSprite>("title"), Camera);
		RegisterGameObject(title);

		PlayButton playButton = new(new(482, 317), Camera);
		RegisterGameObject(playButton);

		QuitButton quitButton = new(new(482, 445), Camera);
		RegisterGameObject(quitButton);

		DevButton devButton = new(new(1160, 600), Camera);
		RegisterGameObject(devButton);
	}

	UICamera Camera { get; }
}
