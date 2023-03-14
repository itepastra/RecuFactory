using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RecuFactory
{
    public class RecuFactory : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Floor floor;
        private Camera camera;
        private SpriteFont overlayFont;
        private Player player;

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

            Texture2D playerTex = Content.Load<Texture2D>("player");
            player = new Player(new Point(0), playerTex);

            camera = new Camera(Window, new Point(0));
            player.EntityMoved += camera.FollowPositioned;

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
            if (Keyboard.CheckPressedNow(Keys.W)) player.Move(0, -1);
            if (Keyboard.CheckPressedNow(Keys.A)) player.Move(-1, 0);
            if (Keyboard.CheckPressedNow(Keys.S)) player.Move(0, 1);
            if (Keyboard.CheckPressedNow(Keys.D)) player.Move(1, 0);

            if (Mouse.ScrolledDown()) camera.AddScale(-4);
            if (Mouse.ScrolledUp()) camera.AddScale(4);




            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            floor.Draw(camera);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            player.Draw(_spriteBatch, camera);

            _spriteBatch.DrawString(overlayFont, $"Camera at: {camera.Position}, Scale: {camera.Scale}", new Vector2(20, 20), Color.Purple);
            _spriteBatch.DrawString(overlayFont, $"Window at: {Window.ClientBounds}", new Vector2(20, 40), Color.Purple);
            _spriteBatch.DrawString(overlayFont, $"Window at: {Mouse.CheckState().Position}", new Vector2(20, 60), Color.Purple);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}