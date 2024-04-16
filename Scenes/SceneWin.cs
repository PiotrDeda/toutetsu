using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneWin : Scene
{
	public SceneWin()
	{
		Name = "Win";
		Camera = new() {
			Name = "Camera"
		};

		GameObject winScreen = new() {
			Camera = Camera,
			Sprite = SpriteManager.CreateSprite<StaticSprite>("ui/win_screen")
		};
		RegisterGameObject(winScreen);

		QuitButton quitButton = new() {
			Position = new(482, 445),
			Camera = Camera,
			Sprite = SpriteManager.CreateSprite<StaticSprite>("ui/quit_button")
		};
		RegisterGameObject(quitButton);
	}

	UICamera Camera { get; }
}
