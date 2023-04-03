using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CreationalPattern
{
    /// <summary>
    /// class for a overlayfactory which inherits from factory
    /// </summary>
    public class OverlayFactory : Factory
    {
        #region singleton
        private static OverlayFactory instance;

        public static OverlayFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OverlayFactory();
                }
                return instance;
            }
        }
        #endregion

        private GameObject overlayPrototype; 

        /// <summary>
        /// private constructor for overlayFactory
        /// </summary>
        private OverlayFactory()
        {
            CreateOverlayPrototype(); 
        }

        /// <summary>
        /// method for creating a overlayPrototype
        /// </summary>
        private void CreateOverlayPrototype()
        {
            overlayPrototype = new GameObject(); 
            overlayPrototype.AddComponent(new Overlay());
            overlayPrototype.AddComponent(new SpriteRenderer());
        }

        /// <summary>
        /// method for creating a gameobject
        /// </summary>
        /// <param name="id">the type of overlay we want to make</param>
        /// <returns>GameObject</returns>
        public override GameObject Create(int id)
        {
            GameObject gameObject = (GameObject)overlayPrototype.Clone(); 

            return gameObject; 
        }
    }
}
