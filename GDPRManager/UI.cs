using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager
{
    /// <summary>
    /// Class for the User Interface
    /// </summary>
    public class UI
    {
        #region singleton
        private static UI instance;

        public static UI Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new UI();
                }
                return instance;
            }
        }
        #endregion

        #region fields
        //string som indeholder player score så den kan printes us til skærmen
        //array med 3 pladser til stjerner
        #endregion

        #region properties
        private string scoreText;
        private SpriteFont scoreTextFont;
        #endregion

        #region constructor
        /// <summary>
        /// constructor for the singleton UI, hence why it is private
        /// </summary>
        private UI()
        {
            
        }
        #endregion

        #region methods
        /// <summary>
        /// method for loading the content we need for the UI
        /// </summary>
        /// <param name="content">the variable we can access the contentmanager through</param>
        public void LoadContent(ContentManager content)
        {
            scoreTextFont = content.Load<SpriteFont>("Fonts\\ScoreTextFont");
        }

        /// <summary>
        /// Method for updating specific things in the UI for each frame
        /// </summary>
        /// <param name="gameTime">variable we can access the gametime should we need it</param>
        public void Update(GameTime gameTime)
        {
            scoreText = "Score: " + GameWorld.Instance.Score.ToString();
        }

        /// <summary>
        /// Method for drawing things to the UI
        /// </summary>
        /// <param name="spriteBatch">we can access the sprite renderer through this</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            float scoreTextX = scoreTextFont.MeasureString(scoreText).X / 2;
            float scoreTextY = scoreTextFont.MeasureString(scoreText).Y / 2;

            spriteBatch.DrawString(scoreTextFont, scoreText, new Vector2(GameWorld.ScreenSize.X / 1.1f, GameWorld.ScreenSize.Y / 1.1f), Color.Black, 0f, new Vector2(scoreTextX, scoreTextY), 1f, SpriteEffects.None, 0.9f);
        }
        #endregion
    }
}
