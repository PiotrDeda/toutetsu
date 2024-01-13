using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneWin : Scene
{
	public SceneWin(SpriteManager spriteManager, Drawer drawer, WindowData windowData, IQuittable appQuittable)
	{
		Name = "Win";
		Camera = new("Camera", drawer, windowData);

		GameObject winScreen = new(new(0, 0), spriteManager.CreateSprite<StaticSprite>("win_screen"), Camera);
		RegisterGameObject(winScreen);

		QuitButton quitButton = new(new(482, 445), Camera, spriteManager, appQuittable);
		RegisterGameObject(quitButton);
	}

	UICamera Camera { get; }
}
