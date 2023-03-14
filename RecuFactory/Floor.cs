using Microsoft.Xna.Framework.Graphics;

namespace RecuFactory
{
    internal class Floor
    {
        private Tile[,] tiles;
        private SpriteBatch _tileSpriteBatch;

        internal Floor(int width, int height, Texture2D texture)
        {
            BaseFloor(width, height, texture);
        }

        private void BaseFloor(int width, int height, Texture2D texture)
        {
            int widthOffset = width / 2;
            int heightOffset = height / 2;
            tiles = new Tile[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    tiles[i, j] = new Tile(i - widthOffset, j - heightOffset, texture);
                }
            }
        }



        internal void Draw(Camera camera)
        {
            _tileSpriteBatch.Begin();
            foreach (var tile in tiles)
            {
                tile.Draw(_tileSpriteBatch, camera);
            }
            _tileSpriteBatch.End();
        }

        internal void SetTileSpriteBatch(SpriteBatch spriteBatch)
        {
            _tileSpriteBatch = spriteBatch;
        }
    }
}
