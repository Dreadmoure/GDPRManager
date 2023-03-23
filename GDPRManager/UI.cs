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
        private UI instance;

        public UI Instance
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
        //if any is needed
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

        }

        /// <summary>
        /// Method for updating specific things in the UI for each frame
        /// </summary>
        /// <param name="gameTime">variable we can access the gametime should we need it</param>
        public void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Method for drawing things to the UI
        /// </summary>
        /// <param name="spriteBatch">we can access the sprite renderer through this</param>
        public void Draw(SpriteBatch spriteBatch)
        {

        }
        #endregion
    }
}
