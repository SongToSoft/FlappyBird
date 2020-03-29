using System;

namespace SirenaEngineMG.SirenaSrc
{
    static class SEProperties
    {
        //private static int width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        //private static int height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        private static Random random = new Random();

        private static int gameWindowWidth = 836;
        private static int gameWindowHeight = 512;
        private static bool isGameFullScreen = false;
        private static bool isGameMouseVisible = true;


        private static int engineWindowWidth = 836;
        private static int engineWindowHeight = 512;
        private static bool isEngineFullScreen = false;
        private static bool isEngineMouseVisible = true;

        public static Random GetRandomizer()
        {
            return random;
        }

        public static int GetGameWindowWidth()
        {
            return gameWindowWidth;
        }

        public static void SetGameWindowWidth(int _windowWidth)
        {
            gameWindowWidth = _windowWidth;
        }

        public static int GetGameWindowHeight()
        {
            return gameWindowHeight;
        }

        public static void SetGetWindowHeight(int _windowHeight)
        {
            gameWindowHeight = _windowHeight;
        }

        public static bool IsGameFullScreen()
        {
            return isGameFullScreen;
        }

        public static void SetGameFullScreenStatus(bool status)
        {
            isGameFullScreen = status;
        }

        public static bool IsGameMouseVisible()
        {
            return isGameMouseVisible;
        }

        public static void SetGameMouseVisibleStatus(bool status)
        {
            isGameMouseVisible = status;
        }

        public static int GetEngineWindowWidth()
        {
            return engineWindowWidth;
        }

        public static void SetEngineWindowWidth(int _windowWidth)
        {
            engineWindowWidth = _windowWidth;
        }

        public static int GetEngineWindowHeight()
        {
            return engineWindowHeight;
        }

        public static void SetEngineWindowHeight(int _windowHeight)
        {
            engineWindowHeight = _windowHeight;
        }

        public static bool IsEngineFullScreen()
        {
            return isEngineFullScreen;
        }

        public static void SetEngineFullScreenStatus(bool status)
        {
            isEngineFullScreen = status;
        }

        public static bool IsEngineMouseVisible()
        {
            return isEngineMouseVisible;
        }

        public static void SetEngineMouseVisibleStatus(bool status)
        {
            isEngineMouseVisible = status;
        }
    }
}
