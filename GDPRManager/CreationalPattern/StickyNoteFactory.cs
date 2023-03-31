using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CreationalPattern
{
    public class StickyNoteFactory : Factory
    {
        #region singleton
        private static StickyNoteFactory instance;

        public static StickyNoteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StickyNoteFactory();
                }
                return instance;
            }
        }
        #endregion

        private GameObject stickyNotePrototype;

        private StickyNoteFactory()
        {
            CreateStickyNotePrototype();
        }

        private void CreateStickyNotePrototype()
        {
            stickyNotePrototype = new GameObject();

            stickyNotePrototype.AddComponent(new StickyNote());
            SpriteRenderer spriteRenderer = stickyNotePrototype.AddComponent(new SpriteRenderer()) as SpriteRenderer;            
            stickyNotePrototype.AddComponent(new TextRenderer());

        }


        public override GameObject Create(int id)
        {
            GameObject gameObject = new GameObject();
            gameObject = (GameObject)stickyNotePrototype.Clone();

            return gameObject;
        }
    }
}
