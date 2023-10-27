using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneWin : Scene
{
	public SceneWin(SpriteManager spriteManager, Drawer drawer, WindowData windowData, IQuittable appQuittable)
	{
		Name = "SceneWin";
		Camera = new(drawer, windowData);

		SimpleObject winScreen = new(spriteManager.CreateSprite<StaticSprite>("win_screen"), Camera);
		RegisterGameObject(winScreen);

		QuitButton quitButton = new(Camera, spriteManager, appQuittable);
		quitButton.Position = new(482, 445);
		RegisterGameObject(quitButton);
	}

	UICamera Camera { get; }
}
