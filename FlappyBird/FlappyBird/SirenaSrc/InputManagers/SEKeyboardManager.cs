using Microsoft.Xna.Framework.Input;

namespace SirenaEngineMG.SirenaSrc.InputManagers
{
    static class SEKeyboardManager
    {
        private static KeyboardState currentKeyboardState = Keyboard.GetState();
        private static KeyboardState lastKeyboardState;

        public static bool CheckKeyDown(Keys key)
        {
            lastKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            return (lastKeyboardState.IsKeyUp(key) && currentKeyboardState.IsKeyDown(key));
        }

        public static bool IsKeyPressed(Keys key)
        {
            return (Keyboard.GetState().IsKeyDown(key)) ? true : false;
        }
    }
}
