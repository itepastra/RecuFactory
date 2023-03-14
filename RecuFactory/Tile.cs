using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RecuFactory
{
    internal class Tile
    {
        private readonly Texture2D texture;
        private readonly Point position;

        internal Tile(int x, int y, Texture2D texture)
        {
            position = new Point(x, y);
            this.texture = texture;
        }

        internal Tile(Point position, Texture2D texture)
        {
            this.position = position;
            this.texture = texture;
        }

        internal void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Point cameraPosition = camera.RightTopPosition();
            Point zoom = camera.Zoom();
            Point screenPosition = position * zoom - cameraPosition;
            spriteBatch.Draw(texture, new Rectangle(screenPosition,zoom), Color.White);
        }
         
    }
}