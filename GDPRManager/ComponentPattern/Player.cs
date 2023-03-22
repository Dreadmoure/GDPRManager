using GDPRManager.CommandPattern;
using GDPRManager.ObserverPattern;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    //enum which holds moods
    public enum Mood { Angry, Neutral, Happy }

    /// <summary>
    /// class for the player
    /// </summary>
    public class Player : Component, IGameListener
    {
        #region fields
        private SpriteRenderer spriteRenderer;

        private float speed;
        private bool canShoot = true;
        private int ammoCount;
        private float shootTime = 0;

        public int[] Speed = new int[3] { 150, 250, 350 };
        #endregion

        #region properties
        /// <summary>
        /// Property to get or set the mood
        /// </summary>
        public Mood Mood { get; set; }

        /// <summary>
        /// property to get the ammocount
        /// </summary>
        public int AmmoCount
        {
            get { return ammoCount; }
        }

        /// <summary>
        /// property for getting or setting the score
        /// </summary>
        public float Score { get; set; }

        /// <summary>
        /// property for getting or setting the multiplier
        /// </summary>
        public float ScoreMultiplier { get; set; }
        #endregion

        #region methods
        /// <summary>
        /// Method for moving the player around
        /// </summary>
        /// <param name="velocity"></param>
        public void Move(Vector2 velocity)
        {
            speed = Speed[(int)Mood];

            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            velocity *= speed;
            GameObject.Transform.Translate(velocity * GameWorld.DeltaTime);
        }

        /// <summary>
        /// sets players start values
        /// </summary>
        public override void Awake()
        {
            ammoCount = 0;
            Score = 0;
            Mood = Mood.Neutral;
            speed = Speed[(int)Mood];
        }

        /// <summary>
        /// sets sprite and initial position
        /// </summary>
        public override void Start()
        {
            spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            spriteRenderer.SetSprite("Player\\HippoV3");
            spriteRenderer.LayerDepth = 0.5f;
            spriteRenderer.Scale = 1f;
            GameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y / 1.3f);
        }

        /// <summary>
        /// Updates the player each frame
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //handles input
            InputHandler.Instance.Execute(this);

            //handles limits
            HandleLimits();

            if (canShoot == false)
            {
                shootTime += GameWorld.DeltaTime;

                if (shootTime > 1)
                {
                    canShoot = true;
                    shootTime = 0;
                }
            }

            //sets the multiplier depending on the modd
            if (Mood == Mood.Angry)
            {
                ScoreMultiplier = 1;
            }
            else if (Mood == Mood.Neutral)
            {
                ScoreMultiplier = 1.5f;
            }
            else if (Mood == Mood.Happy)
            {
                ScoreMultiplier = 2;
            }
        }

        /// <summary>
        /// Makes sure the player cannot go outside the bounds of the screen
        /// </summary>
        private void HandleLimits()
        {
            Vector2 origin = new Vector2(spriteRenderer.Sprite.Width / 2, spriteRenderer.Sprite.Height / 2);

            if (GameObject.Transform.Position.X < origin.X)
            {
                GameObject.Transform.Position = new Vector2(origin.X, GameObject.Transform.Position.Y);
            }
            if (GameObject.Transform.Position.Y < origin.Y)
            {
                GameObject.Transform.Position = new Vector2(GameObject.Transform.Position.X, origin.Y);
            }
            if (GameObject.Transform.Position.X > GameWorld.ScreenSize.X - origin.X)
            {
                GameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X - origin.X, GameObject.Transform.Position.Y);
            }
            if (GameObject.Transform.Position.Y > GameWorld.ScreenSize.Y - origin.Y - 120)
            {
                GameObject.Transform.Position = new Vector2(GameObject.Transform.Position.X, GameWorld.ScreenSize.Y - origin.Y - 120);
            }
        }

        /// <summary>
        /// hanldes gameevents
        /// </summary>
        /// <param name="gameEvent"></param>
        public void Notify(GameEvent gameEvent)
        {
            if (gameEvent is CollisionEvent)
            {
                GameObject other = (gameEvent as CollisionEvent).Other;

                if (other.Tag == "Crocodile")
                {
                    Score += 10 * ScoreMultiplier;

                    if (Mood != Mood.Angry)
                    {
                        Mood--;
                    }
                    EnemyPool.Instance.ReleaseObject(other);
                }
                if (other.Tag == "Mineral")
                {
                    ammoCount++;
                    Score += 5 * ScoreMultiplier;
                    MineralPool.Instance.ReleaseObject(other);
                }
            }
        }
        #endregion
    }
