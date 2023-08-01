using Rokuro.Graphics;

namespace Toutetsu.Scenes;

public class SceneLoader
{
	public static List<Scene> GetScenes()
	{
		List<Scene> scenes = new();

		scenes.Add(new SceneMainMenu());
		scenes.Add(new SceneGameMap());
		scenes.Add(new SceneFight());
		scenes.Add(new SceneWin());
		scenes.Add(new SceneLose());

		//GameState.SetSceneGameMap(scenes[1]);
		//GameState.SetSceneFight(scenes[2]);

		return scenes;
	}
}
