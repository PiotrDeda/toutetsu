using Rokuro;
using Rokuro.Graphics;
using Rokuro.Math;
using Rokuro.Objects;
using Toutetsu.Components.UI;

namespace Toutetsu.Scenes;

public class SceneWin : Scene
{
	public SceneWin()
	{
		Name = "SceneWin";
		
		var winScreen = new SimpleObject(App.GetSprite("win_screen"), Camera);
		RegisterGameObject(winScreen);
		
		var quitButton = new QuitButton(Camera);
		quitButton.Position = new Vector(482, 445);
		RegisterGameObject(quitButton);
	}
	
	UICamera Camera { get; set; } = new();
}
