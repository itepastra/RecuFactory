using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RecuFactory
{
    public class Tile : IDrawable, IPositioned
    {
        private Point position;
        private Texture2D texture;

        public Point Position { get =>  position; set => position = value; }
        public Texture2D Texture { get => texture; private set => texture = value; }


        internal Tile(int x, int y, Texture2D texture)
        {
            Position = new Point(x, y);
            this.Texture = texture;
        }
        internal Tile(int x, int y)
        {
            Position = new Point(x, y);
        }

        internal Tile(Point position, Texture2D texture)
        {
            this.Position = position;
            this.Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Point screenPosition = camera.WorldToScreen(Position);
            spriteBatch.Draw(Texture, new Rectangle(screenPosition, camera.GetScalePoint()), Color.White);
        }

    }
}