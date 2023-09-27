using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneLose : Scene
{
	public SceneLose()
	{
		Name = "SceneLose";

		SimpleObject loseScreen = new(App.SpriteManager.CreateSpriteFromTemplate("lose_screen"), Camera);
		RegisterGameObject(loseScreen);

		QuitButton quitButton = new(Camera);
		quitButton.Position = new(482, 445);
		RegisterGameObject(quitButton);
	}

	UICamera Camera { get; } = new();
}
