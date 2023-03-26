using GDPRManager.ComponentPattern;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CreationalPattern
{
    /// <summary>
    /// used to hold types of minerals
    /// </summary>
    public enum CaseType { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten }

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

        /// <summary>
        /// Method for creating a gameobject
        /// </summary>
        /// <param name="type">of a type based on an enum</param>
        /// <returns>the created gameobject</returns>
        public GameObject Create(Enum type)
        {
            GameObject gameObject = new GameObject();

            SpriteRenderer spriteRenderer = gameObject.AddComponent(new SpriteRenderer()) as SpriteRenderer;
            gameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X /2, GameWorld.ScreenSize.Y /2);
            gameObject.Tag = "Case";
            spriteRenderer.LayerDepth = 0.8f;
            spriteRenderer.Scale = 1f;
            spriteRenderer.SetSprite("Sprites\\CaseFile");


            CaseFile caseFile;


            switch (type)
            {
                case CaseType.One:
                    caseFile = gameObject.AddComponent(new CaseFile()) as CaseFile;
                    //needs a string for the text that can vary
                    break;
                case CaseType.Two:
                    caseFile = gameObject.AddComponent(new CaseFile()) as CaseFile;
                    break;
            }
            return gameObject;
        }
    }
}
