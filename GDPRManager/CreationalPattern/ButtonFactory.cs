using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CreationalPattern
{
    /// <summary>
    /// class for making buttons
    /// </summary>
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

        #region
        private GameObject approveButtonPrototype; 
        private GameObject denyButtonPrototype; 
        private GameObject nextButtonPrototype; 
        private GameObject exitButtonPrototype;
        #endregion

        /// <summary>
        /// private constructor for buttonFactory
        /// </summary>
        private ButtonFactory()
        {
            ApproveButtonPrototype();
            DenyButtonPrototype();
            NextButtonPrototype(); 
            ExitButtonPrototype(); 
        }

        #region methods
        /// <summary>
        /// Method for making a ApproveButton prototype
        /// </summary>
        private void ApproveButtonPrototype()
        {
            approveButtonPrototype = new GameObject();
            approveButtonPrototype.AddComponent(new ApproveButton());
            approveButtonPrototype.AddComponent(new SpriteRenderer());
            approveButtonPrototype.AddComponent(new Collider());
            approveButtonPrototype.AddComponent(new Clickable());
        }

        /// <summary>
        /// Method for making a DenyButton prototype
        /// </summary>
        private void DenyButtonPrototype()
        {
            denyButtonPrototype = new GameObject();
            denyButtonPrototype.AddComponent(new DenyButton());
            denyButtonPrototype.AddComponent(new SpriteRenderer());
            denyButtonPrototype.AddComponent(new Collider());
            denyButtonPrototype.AddComponent(new Clickable());
        }

        /// <summary>
        /// Method for making a NextButton prototype
        /// </summary>
        private void NextButtonPrototype()
        {
            nextButtonPrototype = new GameObject();
            nextButtonPrototype.AddComponent(new NextButton());
            nextButtonPrototype.AddComponent(new SpriteRenderer());
            nextButtonPrototype.AddComponent(new Collider());
            nextButtonPrototype.AddComponent(new Clickable());
        }

        /// <summary>
        /// Method for making a ExitButton prototype
        /// </summary>
        private void ExitButtonPrototype()
        {
            exitButtonPrototype = new GameObject();
            exitButtonPrototype.AddComponent(new ExitButton());
            exitButtonPrototype.AddComponent(new SpriteRenderer());
            exitButtonPrototype.AddComponent(new Collider());
            exitButtonPrototype.AddComponent(new Clickable());
        }

        /// <summary>
        /// Method for creating a gameobject
        /// </summary>
        /// <param name="id">the type of button we want to make</param>
        /// <returns>GameObject</returns>
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
                case 4:
                    gameObject = (GameObject)exitButtonPrototype.Clone();
                    break; 
            }

            return gameObject;
        }
        #endregion
    }
}
