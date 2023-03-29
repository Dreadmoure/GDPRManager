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
            caseFilePrototype.Tag = "CaseFile";
            spriteRenderer.LayerDepth = 0.8f;
            spriteRenderer.Scale = 1f;
            spriteRenderer.SetSprite("Sprites\\CaseFile");
            caseFilePrototype.AddComponent(new CaseFile());
            caseFilePrototype.AddComponent(new TextRenderer());


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
            gameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y / 2);
            TextRenderer textRenderer = gameObject.GetComponent<TextRenderer>() as TextRenderer;
            CaseFile caseFile;

            textRenderer.FontName = "NormalTextFont";

            switch (caseID)
            {
                case 1:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;                    
                    caseFile.Solution = "Approve";
                    caseFile.StickyNoteText = "- Race og etnicitet\n- Politik\n- Religion eller filosofi\n- Fagforening\n- Helbred\n";
                    caseFile.Text = "Anklage\nDanske Bank har delt personfoelsom data.\n\nScenarie\nEn ansat i Danske Bank har ved et uheld vedhaeftet fornavn, efternavn\nog deres politiske overbevisning, paa en anden kunde, i en mail\ntil en helt tredje som er en privatperson.\n\n\nEr der hold i anklagen?";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    //needs a string for the text that can vary
                    break;
                case 2:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Deny";
                    caseFile.StickyNoteText = "Test StickyNote Hint2";
                    caseFile.Text = "Test2";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 3:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Approve";
                    caseFile.StickyNoteText = "Test StickyNote Hint3";
                    caseFile.Text = "Test3";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 4:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Deny";
                    caseFile.StickyNoteText = "Test StickyNote Hint4";
                    caseFile.Text = "Test4";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 5:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Deny";
                    caseFile.StickyNoteText = "Test StickyNote Hint5";
                    caseFile.Text = "Test5";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 6:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Approve";
                    caseFile.StickyNoteText = "Test StickyNote Hint6";
                    caseFile.Text = "Test6";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 7:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Approve";
                    caseFile.StickyNoteText = "Test StickyNote Hint7";
                    caseFile.Text = "Test7";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 8:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Deny";
                    caseFile.StickyNoteText = "Test StickyNote Hint8";
                    caseFile.Text = "Test8";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 9:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Deny";
                    caseFile.StickyNoteText = "Test StickyNote Hint9";
                    caseFile.Text = "Test9";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 10:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Solution = "Approve";
                    caseFile.StickyNoteText = "Test StickyNote Hint10";
                    caseFile.Text = "Test10";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
            }
            return gameObject;
        }
    }
}
