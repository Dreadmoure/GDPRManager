using GDPRManager.ComponentPattern;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CreationalPattern
{
    public class TutorialPageFactory : Factory
    {
        #region singleton
        private static TutorialPageFactory instance;

        public static TutorialPageFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TutorialPageFactory();
                }
                return instance;
            }
        }
        #endregion

        private GameObject tutorialPagePrototype;

        private TutorialPageFactory()
        {
            CreateCaseFilePrototype();
        }

        private void CreateCaseFilePrototype()
        {
            tutorialPagePrototype = new GameObject();


            SpriteRenderer spriteRenderer = tutorialPagePrototype.AddComponent(new SpriteRenderer()) as SpriteRenderer;
            tutorialPagePrototype.Tag = "TutorialPage";
            spriteRenderer.LayerDepth = 0.8f;
            spriteRenderer.Scale = 1f;
            spriteRenderer.SetSprite("Sprites\\CaseFile");
            tutorialPagePrototype.AddComponent(new TutorialPage());
            TextRenderer textRenderer = tutorialPagePrototype.AddComponent(new TextRenderer()) as TextRenderer;
            textRenderer.LayerDepth = 0.81f;


        }

        /// <summary>
        /// Method for creating a gameobject
        /// </summary>
        /// <param name="type">of a type based on an enum</param>
        /// <returns>the created gameobject</returns>
        public override GameObject Create(int id)
        {
            GameObject gameObject = new GameObject();
            gameObject = (GameObject)tutorialPagePrototype.Clone();
            gameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y / 2);
            TextRenderer textRenderer = gameObject.GetComponent<TextRenderer>() as TextRenderer;
            TutorialPage tutorialPage;

            textRenderer.FontName = "NormalTextFont";

            switch (id)
            {
                case 1:
                    tutorialPage = gameObject.GetComponent<TutorialPage>() as TutorialPage;
                    tutorialPage.Text = "1";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 2:
                    tutorialPage = gameObject.GetComponent<TutorialPage>() as TutorialPage;
                    tutorialPage.Text = "2";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 3:
                    tutorialPage = gameObject.GetComponent<TutorialPage>() as TutorialPage;
                    tutorialPage.Text = "3";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 4:
                    tutorialPage = gameObject.GetComponent<TutorialPage>() as TutorialPage;
                    tutorialPage.Text = "4";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 5:
                    tutorialPage = gameObject.GetComponent<TutorialPage>() as TutorialPage;
                    tutorialPage.Text = "5";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 6:
                    tutorialPage = gameObject.GetComponent<TutorialPage>() as TutorialPage;
                    tutorialPage.Text = "6";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 7:
                    tutorialPage = gameObject.GetComponent<TutorialPage>() as TutorialPage;
                    tutorialPage.Text = "7";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 8:
                    tutorialPage = gameObject.GetComponent<TutorialPage>() as TutorialPage;
                    tutorialPage.Text = "8";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 9:
                    tutorialPage = gameObject.GetComponent<TutorialPage>() as TutorialPage;
                    tutorialPage.Text = "9";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 10:
                    tutorialPage = gameObject.GetComponent<TutorialPage>() as TutorialPage;
                    tutorialPage.Text = "10";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
            }
            return gameObject;
        }
    }
}
