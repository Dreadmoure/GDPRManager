using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.BuilderPattern
{
    public class CaseStackBuilder : IBuilder
    {
        private GameObject gameObject;

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

            collider.CollisionEvent.Attach(caseStack); 
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
