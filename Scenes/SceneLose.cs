using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneLose : Scene
{
	public SceneLose()
	{
		Name = "Lose";
		Camera = new("Camera");

		GameObject loseScreen = new(new(0, 0), SpriteManager.CreateSprite<StaticSprite>("lose_screen"), Camera);
		RegisterGameObject(loseScreen);

		QuitButton quitButton = new(new(482, 445), Camera);
		RegisterGameObject(quitButton);
	}

	UICamera Camera { get; }
}
