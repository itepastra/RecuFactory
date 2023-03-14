using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RecuFactory
{
    internal interface IDrawable : IPositioned
    {
        Texture2D Texture { get; }

        void Draw(SpriteBatch spriteBatch, Camera camera);

    }
}
