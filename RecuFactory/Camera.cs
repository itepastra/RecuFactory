using Microsoft.Xna.Framework;
using System;

namespace RecuFactory
{
    internal class Camera
    {
        private Point position { get; set; }
        private GameWindow window { get; set; }
        
        private int zoom { get; set; }


        public Camera(GameWindow window, Point point)
        {
            position = point;
            zoom = 16;
            this.window = window;
        }

        internal void Move(int x, int y)
        {
            position = position + new Point(x, y);
        }

        internal void Move(Point point)
        {
            position = position + point;
        }

        internal Point Position() { return position; }

        internal Point Zoom()
        {
            return new Point(zoom);
        }

        internal void AddZoom(int zoom)
        {
            int newZoom = this.zoom + zoom;
            if (newZoom < 16) newZoom = 16;

            this.zoom = newZoom;
        }

        internal Point RightTopPosition()
        {
            int hOffset = window.ClientBounds.Width / 2;
            int vOffset = window.ClientBounds.Height / 2;
            return position - new Point(hOffset, vOffset);
        }
    }
}
