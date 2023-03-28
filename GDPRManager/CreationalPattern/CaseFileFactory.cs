using GDPRManager.ComponentPattern;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CreationalPattern
{
    ///// <summary>
    ///// used to hold types of minerals
    ///// </summary>
    //public enum CaseFileType { CaseFileOne, CaseFileTwo, CaseFileThree, CaseFileFour, CaseFileFive, CaseFileSix, CaseFileSeven, CaseFileEight, CaseFileNine, CaseFileTen }

    /// <summary>
    /// class for making minerals of different types
    /// </summary>
    public class CaseFileFactory
    {
        #region singleton
        private static CaseFileFactory instance;

        public static CaseFileFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CaseFileFactory();
                }
                return instance;
            }
        }
        #endregion

        private GameObject caseFilePrototype;

        private CaseFileFactory()
        {
            CreateCaseFilePrototype();
        }

        private void CreateCaseFilePrototype()
        {
            caseFilePrototype = new GameObject();
            
            
            SpriteRenderer spriteRenderer = caseFilePrototype.AddComponent(new SpriteRenderer()) as SpriteRenderer;
            caseFilePrototype.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y / 2);
            caseFilePrototype.Tag = "CaseFile";
            spriteRenderer.LayerDepth = 0.8f;
            spriteRenderer.Scale = 1f;
            spriteRenderer.SetSprite("Sprites\\CaseFile");
            caseFilePrototype.AddComponent(new CaseFile());
            
            
        }

        /// <summary>
        /// Method for creating a gameobject
        /// </summary>
        /// <param name="type">of a type based on an enum</param>
        /// <returns>the created gameobject</returns>
        public GameObject Create(int caseID)
        {
            GameObject gameObject = new GameObject();
            gameObject = (GameObject)caseFilePrototype.Clone();

            switch (caseID)
            {
                case 1:
                    
                    //needs a string for the text that can vary
                    break;
                case 2:
                    break;
            }
            return gameObject;
        }
    }
}
