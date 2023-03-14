using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace RecuFactory
{
    public class RecuFactory : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Floor floor;
        private Camera camera;
        private SpriteFont overlayFont;

        public RecuFactory()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Texture2D floorTex = Content.Load<Texture2D>("BaseFloor");
            floor = new Floor(32, 32, floorTex);

            camera = new Camera(Window, new Point(0));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            floor.SetTileSpriteBatch(new SpriteBatch(GraphicsDevice));

            overlayFont = Content.Load<SpriteFont>("OverlayFont");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            Keyboard.CheckState();
            Mouse.CheckState();

            if (Keyboard.CheckPressed(Keys.Escape)) Exit();


            // * w *
            // a * d
            // * s *
            if (Keyboard.CheckPressedNow(Keys.W)) camera.Move(0, -camera.Zoom().Y);
            if (Keyboard.CheckPressedNow(Keys.A)) camera.Move(-camera.Zoom().X, 0);
            if (Keyboard.CheckPressedNow(Keys.S)) camera.Move(0, camera.Zoom().Y);
            if (Keyboard.CheckPressedNow(Keys.D)) camera.Move(camera.Zoom().X, 0);

            if (Mouse.ScrolledDown()) camera.AddZoom(-4);
            if (Mouse.ScrolledUp()) camera.AddZoom(4);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            floor.Draw(camera);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.DrawString(overlayFont, $"Camera at: {camera.Position()}, Zoom: {camera.Zoom()}", new Vector2(20, 20), Color.Purple);
            _spriteBatch.DrawString(overlayFont, $"Window at: {Window.ClientBounds}", new Vector2(20, 40), Color.Purple);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}