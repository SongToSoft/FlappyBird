using System.Collections.Generic;
using SirenaEngineMG.SirenaSrc.Objects;

namespace SirenaEngineMG.SirenaSrc
{
    static class SESceneManager
    {
        static private Dictionary<string, SEScene> scenesLoable;
        static private SEScene currentScene;

        public static void Init()
        {
            scenesLoable = new Dictionary<string, SEScene>();
        }

        public static void AddScene(SEScene scene)
        {
            scenesLoable.Add(scene.GetName(), scene);
        }

        public static SEScene GetSceneByName(string sceneName)
        {
            SEScene outScene = null;
            scenesLoable.TryGetValue(sceneName, out outScene);
            return outScene;
        }

        public static void LoadScene(string sceneName)
        {
            var newScene = GetSceneByName(sceneName);
            for (int i = 0; i < newScene.GetChilds().Count; ++i)
            {
                if (newScene.GetChilds()[i].IsDestroyOnLoad())
                {
                    newScene.AddChild(newScene.GetChilds()[i]);
                }
            }
            currentScene = newScene;
        }

        public static SEScene GetCurrentScene()
        {
            return currentScene;
        }
    }
}
