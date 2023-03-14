using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuFactory
{
    internal abstract class Entity : IPositioned, IDrawable
    {
        private Point position;
        private Texture2D texture;

        public Point Position { get => position; set => position = value; }
        public Texture2D Texture { get => texture; set => texture = value; }

        public Entity(Point position) => Position = position;

        public Entity(Point position, Texture2D texture)
        {
            Position = position;
            Texture = texture;
        }

        public void Move(Point movement)
        {
            Position += movement;
            EntityMoved?.Invoke(this, EventArgs.Empty);
        }

        public void Move(int x, int y) => Move(new Point(x, y));

        public event EventHandler EntityMoved;

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Point screenPosition = camera.WorldToScreen(Position);
            spriteBatch.Draw(Texture, new Rectangle(screenPosition, camera.GetScalePoint()), Color.White);
        }
    }
}
