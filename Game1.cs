using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Topic_2._5
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D quitTexture;

        Rectangle quitButton;

        Rectangle Window;

        MouseState mouseState;
        MouseState prevMouseState;

        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            if (mouseState.LeftButton == ButtonState.Pressed) 
            {
                Exit();
            }
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Window = new Rectangle(0, 0, 800, 500);

            _graphics.PreferredBackBufferWidth = Window.Width;
            _graphics.PreferredBackBufferHeight = Window.Height;

            quitButton = new Rectangle(300, 170, 200, 80);

            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            

            quitTexture = Content.Load<Texture2D>("QuitButton");

            

        }

        protected override void Update(GameTime gameTime)
        {

            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                if (quitButton.Contains(mouseState.Position))
                    Exit();
            }




            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Lime);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(quitTexture, quitButton, Color.White);


            if (quitButton.Contains(mouseState.Position)) 
            {
                _spriteBatch.Draw(quitTexture, quitButton, Color.Green);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
