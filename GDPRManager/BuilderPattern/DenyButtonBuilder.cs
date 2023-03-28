using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.BuilderPattern
{
    public class DenyButtonBuilder : IBuilder
    {
        private GameObject gameObject;

        public void BuildGameObject()
        {
            gameObject = new GameObject();

            BuildComponents();
        }

        private void BuildComponents()
        {
            DenyButton denyButton = (DenyButton)gameObject.AddComponent(new DenyButton());
            gameObject.AddComponent(new SpriteRenderer());
            gameObject.AddComponent(new Collider());
            gameObject.AddComponent(new Clickable());
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
