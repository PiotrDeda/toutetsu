using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneLose : Scene
{
	public SceneLose(SpriteManager spriteManager, Drawer drawer, WindowData windowData, IQuittable appQuittable)
	{
		Name = "SceneLose";
		Camera = new(drawer, windowData);

		SimpleObject loseScreen = new(spriteManager.CreateSpriteFromTemplate("lose_screen"), Camera);
		RegisterGameObject(loseScreen);

		QuitButton quitButton = new(Camera, spriteManager, appQuittable);
		quitButton.Position = new(482, 445);
		RegisterGameObject(quitButton);
	}

	UICamera Camera { get; }
}
