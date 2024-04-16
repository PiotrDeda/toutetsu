using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneLose : Scene
{
	public SceneLose()
	{
		Name = "Lose";
		Camera = new() {
			Name = "Camera"
		};

		//GameObject loseScreen = new(new(0, 0), SpriteManager.CreateSprite<StaticSprite>("ui/lose_screen"), Camera);
		GameObject loseScreen = new() {
			Camera = Camera,
			Sprite = SpriteManager.CreateSprite<StaticSprite>("ui/lose_screen")
		};
		RegisterGameObject(loseScreen);

		QuitButton quitButton = new() {
			Position = new(482, 445),
			Camera = Camera,
			Sprite = SpriteManager.CreateSprite<StaticSprite>("ui/quit_button")
		};
		RegisterGameObject(quitButton);
	}

	UICamera Camera { get; }
}
