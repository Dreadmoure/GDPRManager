using GDPRManager.BuilderPattern;
using GDPRManager.ComponentPattern;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        private List<GameObject> gameObjects = new List<GameObject>();
        private List<GameObject> destroyGameObjects = new List<GameObject>();
        private List<GameObject> newGameObjects = new List<GameObject>();

        private Star[] stars;
        #endregion

        #region properties
        /// <summary>
        /// property for getting the elapsed gametime
        /// </summary>
        public static float DeltaTime { get; private set; }

        /// <summary>
        /// Property for getting or setting the score
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Used to add colliders on instantiated objects and remove from the objects slated for removal
        /// </summary>
        public List<Collider> Colliders { get; private set; } = new List<Collider>();

        /// <summary>
        /// Property for accessing the size of the screen
        /// </summary>
        public static Vector2 ScreenSize { get; private set; }

        /// <summary>
        /// Property for getting and setting the CaseFileID used to identify what case we are at
        /// </summary>
        public int CaseFileID { get; set; } = 1;

        /// <summary>
        /// Propert for getting and setting the stacksize of the stack, dictates how many cases are in the game/stack
        /// </summary>
        public int CaseFileStackSize { get; set; } = 10;
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
            //Stars are added
            stars = new Star[3];
            for (int i = 0; i < stars.Length; i++)
            {
                Director starDirector = new Director(new StarBuilder(i));
                gameObjects.Add(starDirector.Construct());


                stars[i] = (Star)gameObjects[i].GetComponent<Star>();
                stars[i].IsFull = false;
            }

            //background is added
            Director backgroundDirector = new Director(new BackgroundBuilder());
            gameObjects.Add(backgroundDirector.Construct());
            //caseStack is added
            Director caseStackDirector = new Director(new CaseStackBuilder());
            gameObjects.Add(caseStackDirector.Construct());
            // mouse is added 
            Director mouseDirector = new Director(new MouseBuilder());
            gameObjects.Add(mouseDirector.Construct());

            //loop that calls awake on all GameObjects
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Awake();

                Collider collider = (Collider)gameObjects[i].GetComponent<Collider>();
                if (collider != null)
                {
                    Colliders.Add(collider);
                }
            }

            base.Initialize();
        }

        /// <summary>
        /// method for loading our content
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //loads the content in the UI
            UI.Instance.LoadContent(Content);

            //calls start on all gameobjects
            for (int i = 0; i < gameObjects.Count; i++)
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

            //updates the gametime
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //calls update on all gameobjects
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(gameTime);
            }

            //updates the UI
            UI.Instance.Update(gameTime);

            //updates the stars based on points
            UpdateStars();

            base.Update(gameTime);

            //calls cleanup
            Cleanup();
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

            //draw the ui
            UI.Instance.Draw(_spriteBatch);

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

                //if no collider is on the new game object, and there needs to be, adds one
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

                //remove collider
                Collider collider = (Collider)destroyGameObjects[i].GetComponent<Collider>();

                if (collider != null)
                {
                    Colliders.Remove(collider);
                }
            }

            //clear the lists
            destroyGameObjects.Clear();
            newGameObjects.Clear();
        }

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

        /// <summary>
        /// method for updating the stars, based on points it updates it to either empty star of full star
        /// </summary>
        private void UpdateStars()
        {
            if(Score < 300)
            {
                stars[2].IsFull = false;
            }
            if(Score >= 300 && Score < 600)
            {
                stars[2].IsFull = true;
                stars[1].IsFull = false;
            }
            if(Score >= 600 && Score < 900)
            {
                stars[1].IsFull = true;
                stars[0].IsFull = false;
            }
            if(Score >= 900)
            {
                stars[0].IsFull = true;
            }
        }
        #endregion
    }
}