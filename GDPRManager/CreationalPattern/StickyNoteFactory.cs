using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CreationalPattern
{
    /// <summary>
    /// class for making different StickyNotes
    /// </summary>
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

        /// <summary>
        /// private constructor for stickyNoteFactory
        /// </summary>
        private StickyNoteFactory()
        {
            CreateStickyNotePrototype();
        }

        #region
        /// <summary>
        /// Method for creating a stickynote prototype
        /// </summary>
        private void CreateStickyNotePrototype()
        {
            stickyNotePrototype = new GameObject();

            stickyNotePrototype.AddComponent(new StickyNote());
            stickyNotePrototype.AddComponent(new SpriteRenderer());            
            stickyNotePrototype.AddComponent(new TextRenderer());
        }

        /// <summary>
        /// Method for creating a gameobjecgt
        /// </summary>
        /// <param name="id">the type of stickynote we want to make</param>
        /// <returns>GameObject</returns>
        public override GameObject Create(int id)
        {
            GameObject gameObject = new GameObject();
            gameObject = (GameObject)stickyNotePrototype.Clone();

            return gameObject;
        }
        #endregion
    }
}
