using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.Math;
using Rokuro.Objects;
using Toutetsu.Components;

namespace Toutetsu.Scenes;

public class SceneLose : Scene
{
	public SceneLose()
	{
		Name = "SceneLose";
		
		var loseScreen = new SimpleObject(App.SpriteManager.CreateSpriteFromTemplate("lose_screen"), Camera);
		RegisterGameObject(loseScreen);
		
		var quitButton = new QuitButton(Camera);
		quitButton.Position = new Vector2D(482, 445);
		RegisterGameObject(quitButton);
	}
	
	UICamera Camera { get; set; } = new();
}
