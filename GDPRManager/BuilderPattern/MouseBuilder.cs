using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.BuilderPattern
{
    /// <summary>
    /// class for MouseBuilder
    /// </summary>
    public class MouseBuilder : IBuilder
    {
        private GameObject gameObject;

        #region methods
        /// <summary>
        /// method for Building a gameobject
        /// </summary>
        public void BuildGameObject()
        {
            gameObject = new GameObject();

            MousePointer mouse = (MousePointer)gameObject.AddComponent(new MousePointer());
            SpriteRenderer spriteRenderer = (SpriteRenderer)gameObject.AddComponent(new SpriteRenderer());
            Collider collider = (Collider)gameObject.AddComponent(new Collider());

            collider.CollisionEvent.Attach(mouse); 
        }

        /// <summary>
        /// Method for returning the gameobject
        /// </summary>
        /// <returns>GameObject</returns>
        public GameObject GetResult()
        {
            return gameObject;
        }
        #endregion
    }
}
