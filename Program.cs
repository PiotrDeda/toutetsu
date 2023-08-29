using Rokuro;
using Rokuro.Core;
using Rokuro.Math;
using Toutetsu.Loaders;

App.Run(
	new AppProperties("Toutetsu", new Color(46, 48, 48), 1280, 720),
	SpriteLoader.GetSprites,
	SceneLoader.GetScenes
);
