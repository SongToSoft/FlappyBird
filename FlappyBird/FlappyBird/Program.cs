using SirenaEngineMG.FlappyBirdProjectCode;
using SirenaEngineMG.SirenaSrc;
using System;

namespace FlappyBird
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            SEResourcesManager.Init();
            SESceneManager.Init();

            using (var game = new FlappyBirdCore())
                game.Run();
        }
    }
#endif
}
