using Rokuro.Core;
using Toutetsu.Loaders;

App.Run(
	new("Toutetsu", new(46, 48, 48), 1280, 720),
	SpriteTemplateLoader.GetSpriteTemplates,
	SceneLoader.GetScenes
);
