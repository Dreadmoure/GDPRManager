using GDPRManager.ComponentPattern;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.BuilderPattern
{
    public class StarBuilder : IBuilder
    {
        #region fields
        private GameObject gameObject;
        private int starID;
        #endregion

        /// <summary>
        /// constructor for heartbuilder which takes 1 parameter
        /// </summary>
        /// <param name="i">tag to identify it later on</param>
        public StarBuilder(int i)
        {
            starID = i;
        }

        #region methods
        public void BuildGameObject()
        {
            gameObject = new GameObject();

            BuildComponents();
        }

        /// <summary>
        /// adds components to the gameobject
        /// </summary>
        private void BuildComponents()
        {
            Vector2 starPosition = new Vector2(GameWorld.Instance.GraphicsDevice.Viewport.Width - 80, GameWorld.Instance.GraphicsDevice.Viewport.Height - 80);

            gameObject.AddComponent(new Star(starID, starPosition - new Vector2(starID * 75, 0)));
            gameObject.AddComponent(new SpriteRenderer());
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
        #endregion
    }
}
