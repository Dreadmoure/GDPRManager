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
            tutorialPagePrototype.AddComponent(new TutorialPage());
            tutorialPagePrototype.AddComponent(new SpriteRenderer());
            tutorialPagePrototype.AddComponent(new TextRenderer());
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
            
            TutorialPage tutorialPage = gameObject.GetComponent<TutorialPage>() as TutorialPage;

            TextRenderer textRenderer = gameObject.GetComponent<TextRenderer>() as TextRenderer;
            textRenderer.FontName = "NormalTextFont";

            switch (id)
            {
                case 1:
                    tutorialPage.Text = "Personfoelsom data:\n" +
                                        "Race og etnisk oprindelse\n" +
                                        "Politisk overbevisning\n" +
                                        "Religioes eller filosofisk overbevisning\n" +
                                        "Fagforeningsmaessige tilhoersforhold\n" +
                                        "Genetiske data\n" +
                                        "Biometriske data med henblik paa entydig identifikation\n" +
                                        "Helbredsoplysninger\n" +
                                        "Seksuelle forhold eller seksuel orientering.";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 2:
                    tutorialPage.Text = "Personfoelsom data:\n" +
                                        "Race og etnisk oprindelse\n" +
                                        "Politisk overbevisning\n" +
                                        "Religioes eller filosofisk overbevisning\n" +
                                        "Fagforeningsmaessige tilhoersforhold\n" +
                                        "Genetiske data\n" +
                                        "Biometriske data med henblik paa entydig identifikation\n" +
                                        "Helbredsoplysninger\n" +
                                        "Seksuelle forhold eller seksuel orientering.";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 3:
                    tutorialPage.Text = "Man er underlagt databeskyttelsesreglerne naar man\n" +
                                        "ikke agerer i arbejde eller organisationssammenhaeng\n" +
                                        "saa vidt man er en del af virksomheden eller organisationen.";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 4:
                    tutorialPage.Text = "Personfoelsom data kan udveksles internt i organisationen.";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 5:
                    tutorialPage.Text = "Man maa opbevare person- og personfoelsom data ved samtykke.";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 6:
                    tutorialPage.Text = "Man maa kun behandle oplysninger, man har brug for\n" +
                                        "og naar man ikke har brug for dem laengere, skal de slettes.";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 7:
                    tutorialPage.Text = "Ved ophaevning af samtykke skal sletning af\n" +
                                        "persondata og personfoelsom data ske hurtigst muligt.";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 8:
                    tutorialPage.Text = "Ved ophaevelse af en ansaettelseskontrakt ophaeves\n" +
                                        "dermed ogsaa samtykke fra den tidligere ansatte.";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 9:
                    tutorialPage.Text = "Dataoverfoersel i blandt organisationer skal foregaa sikkert.";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
                case 10:
                    tutorialPage.Text = "Ingen hjaelp at hente";
                    textRenderer.SetText(tutorialPage.Text, gameObject.Transform.Position);
                    break;
            }
            return gameObject;
        }
    }
}
