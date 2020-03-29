using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SirenaEngineMG.SirenaSrc.InputManagers
{
    static class SEMouseManager
    {
        private static MouseState currentMouseState = Mouse.GetState();
        private static MouseState lastMouseState;

        static public bool CheckMouseLeftClick()
        {
            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            return (lastMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed);
        }

        static public bool IsMouseLeftPressed()
        {
            return (Mouse.GetState().LeftButton == ButtonState.Pressed);
        }

        static public Vector2 GetCursorPosition()
        {
            return new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
        }
    }
}
