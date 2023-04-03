using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.BuilderPattern
{
    /// <summary>
    /// class for CaseStackBuilder
    /// </summary>
    public class CaseStackBuilder : IBuilder
    {
        private GameObject gameObject;

        #region methods
        /// <summary>
        /// method for Building a gameobject
        /// </summary>
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
            CaseStack caseStack = (CaseStack)gameObject.AddComponent(new CaseStack());
            SpriteRenderer spriteRenderer = (SpriteRenderer)gameObject.AddComponent(new SpriteRenderer());
            Collider collider = (Collider)gameObject.AddComponent(new Collider());
            Clickable clickable = (Clickable)gameObject.AddComponent(new Clickable());
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
