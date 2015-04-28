using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TDJD_Platformer.Actors;
using TDJD_Platformer.Interfaces;

namespace TDJD_Platformer
{
    public static class World
    {
        public static float DeltaTime;
        public const float Gravity = 9.8f; // Este valor vai ter que ser mudado, 9.8f acho que é muito pouco, é uma questão de testar.
        public static List<Actor> Actors { get; private set; }

        static World()
        {
            Actors = new List<Actor>();
        }

        public static void Update()
        {
            for (int i = Actors.Count - 1; i >= 0; i--) {
                if (!Actors[i].Alive) {
                    ICollidable collidable = Actors[i] as ICollidable;
                    if (collidable != null) Collisions.Colliders.Remove(collidable.Collider);
                    Actors.RemoveAt(i);
                }
            }
        }
    }

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Platformer : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        // Camera2D camera;

        private ControllableCharacter c1, c2, c3;

        public Platformer()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            

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

            // camera = new Camera2D(this);
            // camera.Initialize();
            // this.Components.Add(Camera);
            // camera.Focus = Actor...
            
            c1 = new ControllableCharacter(100, 100);
            c2 = new ControllableCharacter(200, 200);
            c3 = new ControllableCharacter(300, 300);
            
            c1.Load(Content, "test");
            c2.Load(Content, "test");
            c3.Load(Content, "test");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            World.DeltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

            c1.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            c1.Draw(spriteBatch);
            c2.Draw(spriteBatch);
            c3.Draw(spriteBatch);

            Collisions.Debug(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
