using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CreationalPattern
{
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

        private OverlayFactory()
        {
            CreateOverlayPrototype(); 
        }

        private void CreateOverlayPrototype()
        {
            overlayPrototype = new GameObject(); 
            overlayPrototype.AddComponent(new Overlay());
            overlayPrototype.AddComponent(new SpriteRenderer());
        }

        public override GameObject Create(int id)
        {
            GameObject gameObject = (GameObject)overlayPrototype.Clone(); 

            return gameObject; 
        }
    }
}
