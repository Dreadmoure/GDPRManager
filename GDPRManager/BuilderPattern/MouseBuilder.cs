using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.BuilderPattern
{
    public class MouseBuilder : IBuilder
    {
        private GameObject gameObject;

        public void BuildGameObject()
        {
            gameObject = new GameObject();

            MousePointer mouse = (MousePointer)gameObject.AddComponent(new MousePointer());
            SpriteRenderer spriteRenderer = (SpriteRenderer)gameObject.AddComponent(new SpriteRenderer());
            Collider collider = (Collider)gameObject.AddComponent(new Collider());

            collider.CollisionEvent.Attach(mouse); 
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
