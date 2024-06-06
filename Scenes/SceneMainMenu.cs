using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneMainMenu : Scene
{
	public SceneMainMenu()
	{
		Name = "Main Menu";
		Camera = new() {
			Name = "Camera"
		};

		GameObject title = new() {
			Position = new(482, 64),
			Camera = Camera,
			Sprite = SpriteManager.CreateSprite<StaticSprite>("ui/title")
		};
		RegisterGameObject(title);

		PlayButton playButton = new() {
			Position = new(482, 317),
			Camera = Camera,
			Sprite = SpriteManager.CreateSprite<StaticSprite>("ui/play_button")
		};
		RegisterGameObject(playButton);

		QuitButton quitButton = new() {
			Position = new(482, 445),
			Camera = Camera,
			Sprite = SpriteManager.CreateSprite<StaticSprite>("ui/quit_button")
		};
		RegisterGameObject(quitButton);

		DebugButton debugButton = new() {
			Position = new(1160, 600),
			Camera = Camera,
			Sprite = SpriteManager.CreateSprite<StaticSprite>("debug/debug_button")
		};
		RegisterGameObject(debugButton);
	}

	UICamera Camera { get; }
}
