using Microsoft.Xna.Framework;
using System;

namespace RecuFactory
{
    public class Camera : IPositioned
    {
        private Point position;

        public Point Position { get => position; set => position = value; }

        private GameWindow Window { get; set; }

        private Point screenMid { get; set; }

        internal int Scale { get; private set; }


        public Camera(GameWindow window, Point point)
        {
            Position = point;
            Scale = 16;
            this.Window = window;
            window.ClientSizeChanged += UpdateMiddle;

            UpdateMiddle(window, null);
        }

        private void UpdateMiddle(object sender, EventArgs e)
        {
            screenMid = new(Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2);
        }

        internal void FollowPositioned(object sender, EventArgs e)
        {
            Position = ((IPositioned)sender).Position;
        }

        internal void Move(int x, int y)
        {
            Position += new Point(x, y);
        }

        internal void Move(Point point)
        {
            Position += point;
        }

        public Point ScreenToWorld(Point point)
        {
            Point relPos = point / new Point(Scale);
            return relPos - screenMid + new Point(Scale / 2);
        }

        public Point WorldToScreen(Point point)
        {
            Point relPos = point - Position;
            return relPos * new Point(Scale) + screenMid - new Point(Scale / 2);
        }

        internal Point GetScalePoint()
        {
            return new Point(Scale);
        }

        internal void AddScale(int v)
        {
            Scale += v;
            if (Scale < 16) Scale = 16;
        }
    }
}
