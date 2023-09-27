using Rokuro.Graphics;
using Toutetsu.Scenes;
using Toutetsu.State;

namespace Toutetsu.Loaders;

public class SceneLoader
{
	public static List<Scene> GetScenes()
	{
		List<Scene> scenes = new();

		SceneGameMap sceneGameMap = new();
		SceneFight sceneFight = new();

		scenes.Add(new SceneMainMenu());
		scenes.Add(sceneGameMap);
		scenes.Add(sceneFight);
		scenes.Add(new SceneWin());
		scenes.Add(new SceneLose());

		GameState.SetSceneGameMap(sceneGameMap);
		GameState.SetSceneFight(sceneFight);

		return scenes;
	}
}
