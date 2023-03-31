using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CreationalPattern
{
    public class ButtonFactory : Factory
    {
        #region singleton
        private static ButtonFactory instance;

        public static ButtonFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ButtonFactory();
                }
                return instance;
            }
        }
        #endregion

        private GameObject approveButtonPrototype; 
        private GameObject denyButtonPrototype; 
        private GameObject nextButtonPrototype; 

        private ButtonFactory()
        {
            ApproveButtonPrototype();
            DenyButtonPrototype();
            NextButtonPrototype(); 
        }

        private void ApproveButtonPrototype()
        {
            approveButtonPrototype = new GameObject();
            approveButtonPrototype.AddComponent(new ApproveButton());
            approveButtonPrototype.AddComponent(new SpriteRenderer());
            approveButtonPrototype.AddComponent(new Collider());
            approveButtonPrototype.AddComponent(new Clickable());
        }

        private void DenyButtonPrototype()
        {
            denyButtonPrototype = new GameObject();
            denyButtonPrototype.AddComponent(new DenyButton());
            denyButtonPrototype.AddComponent(new SpriteRenderer());
            denyButtonPrototype.AddComponent(new Collider());
            denyButtonPrototype.AddComponent(new Clickable());
        }

        private void NextButtonPrototype()
        {
            nextButtonPrototype = new GameObject();
            //nextButtonPrototype.AddComponent(new NextButton());
            nextButtonPrototype.AddComponent(new SpriteRenderer());
            nextButtonPrototype.AddComponent(new Collider());
            nextButtonPrototype.AddComponent(new Clickable());
        }

        public override GameObject Create(int id)
        {
            GameObject gameObject = new GameObject();

            switch (id)
            {
                case 1:
                    gameObject = (GameObject)approveButtonPrototype.Clone(); 
                    break;
                case 2:
                    gameObject = (GameObject)denyButtonPrototype.Clone();
                    break;
                case 3:
                    gameObject = (GameObject)nextButtonPrototype.Clone();
                    break; 
            }

            return gameObject;
        }
    }
}
