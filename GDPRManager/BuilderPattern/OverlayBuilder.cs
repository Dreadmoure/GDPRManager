using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.BuilderPattern
{
    public class OverlayBuilder : IBuilder
    {
        private GameObject gameObject;

        public void BuildGameObject()
        {
            gameObject = new GameObject();

            BuildComponents();
        }

        private void BuildComponents()
        {
            Overlay overlay = (Overlay)gameObject.AddComponent(new Overlay());
            gameObject.AddComponent(new SpriteRenderer());
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
