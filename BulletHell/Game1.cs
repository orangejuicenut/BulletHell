using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BulletHell
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        EntityManager manager;
        Player player;
        Wall wall;

        private SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            manager = new EntityManager();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            manager.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            Texture2D wallText = Content.Load<Texture2D>("bricks");
            Texture2D playerText = Content.Load<Texture2D>("Lonk4");

            player = new Player(playerText, new Point(10, 10));
            wall = new Wall(new Rectangle(100, 250, 300, 100), wallText);
            font = Content.Load<SpriteFont>("Yay");

            manager.dynamicEntities.Add(player);
            manager.staticEntities.Add(wall);



            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            manager.Update(gameTime);



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            int lonkX0 = player.HitBox.Left;
            int lonkX1 = player.HitBox.Right;
            int lonkY0 = player.HitBox.Top;
            int lonkY1 = player.HitBox.Bottom;


            int wallX0 = wall.HitBox.Left;
            int wallX1 = wall.HitBox.Right;
            int wallY0 = wall.HitBox.Top;
            int wallY1 = wall.HitBox.Bottom;


            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(samplerState : SamplerState.PointClamp);
            manager.Draw(spriteBatch);

            spriteBatch.DrawString(font, "lonkX0 <= wallX1 :" + (lonkX0 <= wallX1), new Vector2(250, 0), Color.Black);
            spriteBatch.DrawString(font, "wallX0 <= lonkX1 :" + (wallX0 <= lonkX1), new Vector2(250, 14), Color.Black);
            spriteBatch.DrawString(font, "lonkY0 <= wallY1 :" + (lonkY0 <= wallY1), new Vector2(250, 28), Color.Black);
            spriteBatch.DrawString(font, "wallY0 <= lonkY1 :" + (wallY0 <= lonkY1), new Vector2(250, 42), Color.Black);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
