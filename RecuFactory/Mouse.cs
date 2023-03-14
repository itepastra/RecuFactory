using Microsoft.Xna.Framework.Input;

namespace RecuFactory
{
    internal static class Mouse
    {

        static MouseState currentMouseState;
        static MouseState previousMouseState;
        static int previousScrollState;
        static int currentScrollState;
        public static MouseState CheckState()
        {
            previousScrollState = currentScrollState;
            currentScrollState = Microsoft.Xna.Framework.Input.Mouse.GetState().ScrollWheelValue;
            previousMouseState = currentMouseState;
            currentMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            return currentMouseState;
        }

        public static bool ScrolledDown()
        {
            return currentScrollState < previousScrollState;
        }
        public static bool ScrolledUp()
        {
            return currentScrollState > previousScrollState;
        }
    }
}
