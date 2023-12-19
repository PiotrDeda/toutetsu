using JetBrains.Annotations;
using Rokuro.Core;
using Rokuro.Graphics;
using Rokuro.MathUtils;
using Rokuro.Objects;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Toutetsu.Scenes;

public class SceneDebug : Scene
{
	public SceneDebug(SpriteManager spriteManager, Drawer drawer, WindowData windowData)
	{
		Name = "SceneDebug";
		Camera = new(drawer, windowData);

		var yamlObjects = new DeserializerBuilder()
			.WithNamingConvention(UnderscoredNamingConvention.Instance)
			.Build()
			.Deserialize<List<YamlObjectModel>>(File.ReadAllText("assets/autogen/data/scenes/debug.yaml"));
		foreach (YamlObjectModel objectModel in yamlObjects)
			RegisterGameObject(objectModel.ToObject(Camera, spriteManager));
	}

	Camera Camera { get; }

	class YamlObjectModel
	{
		[UsedImplicitly] public string? Name { get; set; }
		[UsedImplicitly] public string? TextureName { get; set; }
		[UsedImplicitly] public string? Class { get; set; }
		[UsedImplicitly] public int X { get; set; }
		[UsedImplicitly] public int Y { get; set; }

		public GameObject ToObject(Camera camera, SpriteManager spriteManager)
		{
			var o = (GameObject)Activator.CreateInstance(Type.GetType(Class!)!, new Vector2D(X, Y),
				spriteManager.CreateSprite<StaticSprite>(TextureName!), camera)!;
			o.Position = new(X, Y);
			return o;
		}
	}
}
