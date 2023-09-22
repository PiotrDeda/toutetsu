﻿using Rokuro.Core;
using Rokuro.MathUtils;
using Toutetsu.Loaders;

App.Run(
	new AppProperties("Toutetsu", new Color(46, 48, 48), 1280, 720),
	SpriteTemplateLoader.GetSpriteTemplates,
	SceneLoader.GetScenes
);
