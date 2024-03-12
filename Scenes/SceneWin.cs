using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneWin : Scene
{
	public SceneWin()
	{
		Name = "Win";
		Camera = new("Camera");

		GameObject winScreen = new(new(0, 0), SpriteManager.CreateSprite<StaticSprite>("ui/win_screen"), Camera);
		RegisterGameObject(winScreen);

		QuitButton quitButton = new(new(482, 445), Camera);
		RegisterGameObject(quitButton);
	}

	UICamera Camera { get; }
}
