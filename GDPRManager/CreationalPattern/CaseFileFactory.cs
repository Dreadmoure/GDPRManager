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
            CaseFile caseFile;

            switch (caseID)
            {
                case 1:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Approve";
                    caseFile.StickyNoteText = "Test StickyNote Hint1";
                    //needs a string for the text that can vary
                    break;
                case 2:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Deny";
                    caseFile.StickyNoteText = "Test StickyNote Hint2";
                    break;
                case 3:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Approve";
                    caseFile.StickyNoteText = "Test StickyNote Hint3";
                    break;
                case 4:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Deny";
                    caseFile.StickyNoteText = "Test StickyNote Hint4";
                    break;
                case 5:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Deny";
                    caseFile.StickyNoteText = "Test StickyNote Hint5";
                    break;
                case 6:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Approve";
                    caseFile.StickyNoteText = "Test StickyNote Hint6";
                    break;
                case 7:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Approve";
                    caseFile.StickyNoteText = "Test StickyNote Hint7";
                    break;
                case 8:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Deny";
                    caseFile.StickyNoteText = "Test StickyNote Hint8";
                    break;
                case 9:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Deny";
                    caseFile.StickyNoteText = "Test StickyNote Hint9";
                    break;
                case 10:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Approve";
                    caseFile.StickyNoteText = "Test StickyNote Hint10";
                    break;
            }
            return gameObject;
        }
    }
}
