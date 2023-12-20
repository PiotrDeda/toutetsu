using Newtonsoft.Json;
using Rokuro.Core;
using Rokuro.Dtos;
using Rokuro.Graphics;
using Rokuro.Objects;

namespace Toutetsu.Scenes;

public class SceneDebug : Scene
{
	public SceneDebug(SpriteManager spriteManager, Drawer drawer, WindowData windowData)
	{
		Name = "SceneDebug";
		Camera = new(drawer, windowData);

		JsonConvert.DeserializeObject<SceneDto>(File.ReadAllText("assets/autogen/data/scenes/debug.json"))!
			.GameObjects.ForEach(objectDto => RegisterGameObject(GameObject.FromDto(objectDto, Camera, spriteManager)));
	}

	Camera Camera { get; }
}
