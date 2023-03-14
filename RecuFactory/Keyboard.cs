using Microsoft.Xna.Framework.Input;

namespace RecuFactory
{
    internal class Keyboard
    {
        static KeyboardState currentKeyState;
        static KeyboardState previousKeyState;

        public static KeyboardState CheckState()
        {
            previousKeyState = currentKeyState;
            currentKeyState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            return currentKeyState;
        }

        public static bool CheckPressed(Keys key)
        {
            return currentKeyState.IsKeyDown(key);
        }

        public static bool CheckPressedNow(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
        }

        public static bool CheckReleasedNow(Keys key)
        {
            return !currentKeyState.IsKeyDown(key) && previousKeyState.IsKeyDown(key);
        }
    }
}