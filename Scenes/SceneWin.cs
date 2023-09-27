using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneWin : Scene
{
	public SceneWin()
	{
		Name = "SceneWin";

		SimpleObject winScreen = new(App.SpriteManager.CreateSpriteFromTemplate("win_screen"), Camera);
		RegisterGameObject(winScreen);

		QuitButton quitButton = new(Camera);
		quitButton.Position = new(482, 445);
		RegisterGameObject(quitButton);
	}

	UICamera Camera { get; } = new();
}
