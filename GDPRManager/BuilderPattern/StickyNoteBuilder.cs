using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.BuilderPattern
{
    public class StickyNoteBuilder : IBuilder
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
            StickyNote stickyNote = (StickyNote)gameObject.AddComponent(new StickyNote());
            gameObject.AddComponent(new SpriteRenderer());
            gameObject.AddComponent(new TextRenderer());

        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
