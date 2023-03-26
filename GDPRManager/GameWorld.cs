using GDPRManager.BuilderPattern;
using GDPRManager.ComponentPattern;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GDPRManager
{
    /// <summary>
    /// Our game world
    /// </summary>
    public class GameWorld : Game
    {
        #region singleton
        //singleton gameworld
        private static GameWorld instance;
        
        public static GameWorld Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameWorld();
                }
                return instance;
            }
        }
        #endregion

        #region fields
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private float lastSpawnEnemy = 0;
        private float lastSpawnMineral = 0;
        private Random random = new Random();

        private List<GameObject> gameObjects = new List<GameObject>();
        private List<GameObject> destroyGameObjects = new List<GameObject>();
        private List<GameObject> newGameObjects = new List<GameObject>();

        private SpriteFont font;
        private string ammoCounterText;
        private string scoreText;
        private string scoreMultiplierText;
        #endregion

        #region properties
        /// <summary>
        /// property for getting the elapsed gametime
        /// </summary>
        public static float DeltaTime { get; private set; }

        /// <summary>
        /// Property used to getting or setting wether or not the game is over
        /// </summary>
        public bool GameOver { get; set; } = false; 

        /// <summary>
        /// Used to add colliders on instantiated objects and remove from the objects slated for removal
        /// </summary>
        public List<Collider> Colliders { get; private set; } = new List<Collider>();

        /// <summary>
        /// Property for accessing the size of the screen
        /// </summary>
        public static Vector2 ScreenSize { get; private set; }
        #endregion

        #region constructor
        /// <summary>
        /// Singleton constructor
        /// </summary>
        private GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;

            ScreenSize = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
        }
        #endregion

        #region methods
        /// <summary>
        /// Method for adding our GameObjects
        /// </summary>
        protected override void Initialize()
        {
            //Player is added
            Director playerDirector = new Director(new PlayerBuilder());
            gameObjects.Add(playerDirector.Construct());

            //loop that calls awake on all GameObjects
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Awake();
            }

            base.Initialize();
        }

        /// <summary>
        /// method for loading our content
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //loads font
            font = Content.Load<SpriteFont>("Fonts\\Font");

            //calls start on all gameobjects
            for(int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Start();
            }
        }

        /// <summary>
        /// Method that is called each frame
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            //used to exit the application
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //check if the game is over
            if (!GameOver) 
            {
                //gets a reference to player
                Player player = (Player)GameWorld.Instance.FindObjectOfType<Player>();

                //updates the gametime
                DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

                //updates our texts
                scoreText = $"Score: {(int)player.Score}";

                //calls update on all gameobjects
                for (int i = 0; i < gameObjects.Count; i++)
                {
                    gameObjects[i].Update(gameTime);
                }

                //spawns enemies and minerals
                //SpawnEnemies();
                //SpawnMinerals();

                base.Update(gameTime);

                //calls cleanup
                Cleanup();
            }
        }

        /// <summary>
        /// Method for drawing objects to the screen
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            //sets background color
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //we begin to draw
            _spriteBatch.Begin(SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp);
            
            //calls draw on all gameobjects
            for(int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Draw(_spriteBatch);
            }

            //we measure strings to to get the origin
            float ammoCountOriginX = font.MeasureString(ammoCounterText).X / 2;
            float ammoCountOriginY = font.MeasureString(ammoCounterText).Y / 2;

            float scoreTextOriginX = font.MeasureString(scoreText).X / 2;
            float scoreTextOriginY = font.MeasureString(scoreText).Y / 2;

            float scoreMultiplierOriginX = font.MeasureString(scoreMultiplierText).X / 2;
            float scoreMultiplierOriginY = font.MeasureString(scoreMultiplierText).Y / 2;

            //we draw string to the screen
            _spriteBatch.DrawString(font, ammoCounterText, new Vector2(ScreenSize.X / 2.25f, ScreenSize.Y / 1.1f), Color.Black, 0, new Vector2(ammoCountOriginX, ammoCountOriginY), 2f, SpriteEffects.None, 1);
            _spriteBatch.DrawString(font, scoreText, new Vector2(ScreenSize.X / 2, ScreenSize.Y / 15f), Color.Black, 0, new Vector2(scoreTextOriginX, scoreTextOriginY), 2f, SpriteEffects.None, 1);
            _spriteBatch.DrawString(font, scoreMultiplierText, new Vector2(ScreenSize.X / 3.18f, ScreenSize.Y / 1.06f), Color.Black, 0, new Vector2(scoreMultiplierOriginX, scoreMultiplierOriginY), 2f, SpriteEffects.None, 1);

            //we stop drawing
            _spriteBatch.End();
            
;
            base.Draw(gameTime);
        }

        /// <summary>
        /// method for adding gameobjects to a list slated for removal
        /// </summary>
        /// <param name="gameObject"></param>
        public void Destroy(GameObject gameObject)
        {
            destroyGameObjects.Add(gameObject);
        }

        /// <summary>
        /// method for adding gameobjects to a list slated to be added
        /// </summary>
        /// <param name="gameObject"></param>
        public void Instantiate(GameObject gameObject)
        {
            newGameObjects.Add(gameObject);
        }

        /// <summary>
        /// Method for removing and adding gameobjects during runtime, including colliders
        /// </summary>
        private void Cleanup()
        {
            //add to gameobjects 
            for(int i = 0; i < newGameObjects.Count; i++)
            {
                gameObjects.Add(newGameObjects[i]);
                newGameObjects[i].Awake();
                newGameObjects[i].Start();

                Collider collider = (Collider)newGameObjects[i].GetComponent<Collider>();
                if(collider != null)
                {
                    Colliders.Add(collider);
                }
            }

            //remove from gameobjects
            for (int i = 0; i < destroyGameObjects.Count; i++)
            {
                gameObjects.Remove(destroyGameObjects[i]);
                Collider collider = (Collider)destroyGameObjects[i].GetComponent<Collider>();

                //// if gameobject is a projectile, remove the collision event 
                //if(destroyGameObjects[i].GetComponent<Projectile>() != null)
                //{
                //    Projectile projectile = destroyGameObjects[i].GetComponent<Projectile>() as Projectile; 
                //    collider.CollisionEvent.Detach(projectile);
                //}

                if (collider != null)
                {
                    Colliders.Remove(collider);
                }
            }

            //clear the lists
            destroyGameObjects.Clear();
            newGameObjects.Clear();
        }

        ///// <summary>
        ///// method for spawning in enemies
        ///// </summary>
        //private void SpawnEnemies()
        //{
        //    lastSpawnEnemy += DeltaTime;

        //    if(lastSpawnEnemy > 2)
        //    {
        //        GameObject enemy = EnemyPool.Instance.GetObject();
        //        enemy.Transform.Position = new Vector2(random.Next(0, GraphicsDevice.Viewport.Width), -200);

        //        Instantiate(enemy);

        //        lastSpawnEnemy = 0;
        //    }
        //}

        /// <summary>
        /// method for spawning in minerals
        /// </summary>
        //private void SpawnMinerals()
        //{
        //    lastSpawnMineral += DeltaTime;

        //    if (lastSpawnMineral > 4)
        //    {
        //        GameObject mineral = MineralPool.Instance.GetObject();
        //        mineral.Transform.Position = new Vector2(random.Next(0, GraphicsDevice.Viewport.Width), 0);

        //        Instantiate(mineral);

        //        lastSpawnMineral = 0;
        //    }
        //}

        /// <summary>
        /// Method for finding an object of a type, so we can reference it
        /// </summary>
        /// <typeparam name="T">The type of component we are searching for</typeparam>
        /// <returns>returns the object of the type we are looking for</returns>
        public Component FindObjectOfType<T>() where T : Component
        {
            foreach(GameObject gameObject in gameObjects)
            {
                Component c = gameObject.GetComponent<T>();

                if(c != null)
                {
                    return c;
                }
            }
            return null;
        }
        #endregion
    }
}