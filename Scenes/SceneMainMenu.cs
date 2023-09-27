using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneMainMenu : Scene
{
	public SceneMainMenu()
	{
		Name = "SceneMainMenu";

		SimpleObject title = new(App.SpriteManager.CreateSpriteFromTemplate("title"), Camera);
		title.Position = new(482, 64);
		RegisterGameObject(title);

		PlayButton playButton = new(Camera);
		playButton.Position = new(482, 317);
		RegisterGameObject(playButton);

		QuitButton quitButton = new(Camera);
		quitButton.Position = new(482, 445);
		RegisterGameObject(quitButton);
	}

	UICamera Camera { get; } = new();
}
