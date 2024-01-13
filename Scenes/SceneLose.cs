using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneLose : Scene
{
	public SceneLose(SpriteManager spriteManager, Drawer drawer, IQuittable appQuittable)
	{
		Name = "Lose";
		Camera = new("Camera", drawer);

		GameObject loseScreen = new(new(0, 0), spriteManager.CreateSprite<StaticSprite>("lose_screen"), Camera);
		RegisterGameObject(loseScreen);

		QuitButton quitButton = new(new(482, 445), Camera, spriteManager, appQuittable);
		RegisterGameObject(quitButton);
	}

	UICamera Camera { get; }
}
