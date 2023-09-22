using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneMainMenu : Scene
{
	public SceneMainMenu()
	{
		Name = "SceneMainMenu";

		var title = new SimpleObject(App.SpriteManager.CreateSpriteFromTemplate("title"), Camera);
		title.Position = new Vector2D(482, 64);
		RegisterGameObject(title);

		var playButton = new PlayButton(Camera);
		playButton.Position = new Vector2D(482, 317);
		RegisterGameObject(playButton);

		var quitButton = new QuitButton(Camera);
		quitButton.Position = new Vector2D(482, 445);
		RegisterGameObject(quitButton);
	}

	UICamera Camera { get; } = new();
}
