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
    /// class for making minerals of different types
    /// </summary>
    public class CaseFileFactory : Factory
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
            caseFilePrototype.AddComponent(new CaseFile());
            caseFilePrototype.AddComponent(new SpriteRenderer());
            caseFilePrototype.AddComponent(new TextRenderer());

            CaseFile caseFile = caseFilePrototype.GetComponent<CaseFile>() as CaseFile;
        }

        /// <summary>
        /// Method for creating a gameobject
        /// </summary>
        /// <param name="type">of a type based on an enum</param>
        /// <returns>the created gameobject</returns>
        public override GameObject Create(int id)
        {
            GameObject gameObject = new GameObject();
            gameObject = (GameObject)caseFilePrototype.Clone();
            gameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y / 2);

            CaseFile caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;

            TextRenderer textRenderer = gameObject.GetComponent<TextRenderer>() as TextRenderer;
            textRenderer.FontName = "NormalTextFont";

            switch (id)
            {
                case 1:             
                    caseFile.Text = "Anklage\nFirma A har delt personfoelsom data.\n\n" +
                                    "Scenarie\nEn ansat i Firma A har ved et uheld vedhaeftet fornavn\n" +
                                    "efternavn og deres politiske overbevisning, paa en anden kunde\n" +
                                    "i en mail til en helt tredje som er en privatperson.";
                    caseFile.StickyNoteText = "- Race og etnicitet\n- Politik\n- Religion eller filosofi\n- Fagforening\n- Helbred\n";
                    caseFile.Solution = "Approve";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 2:
                    caseFile.Text = "Anklage\nPerson A har anklaget sin nabo, person B\nfor at dele personfoelsom data.\n\n" +
                                    "Scenarie\nPerson B har gjort grin med Person A paa Facebook\n" +
                                    "hvor de udstiller As etnicitet.";
                    caseFile.StickyNoteText = "- Regler omfatter:\n- Organisationer\n- Virksomheder\n -Ikke privatpersoner\n";
                    caseFile.Solution = "Deny";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 3:
                    caseFile.Text = "Anklage\nPerson A har anklaget sin ven, person B, for at dele personfoelsom data.\n\n" +
                                    "Scenarie\nPerson B er en laege som har sin egen private praksis.\n" +
                                    "Person A og person B havde en samtale omkring en klient fra Bs arbejde\n" +
                                    "hvor B naevnte klienten ved navn og syntes det var\n" +
                                    "forfaerdeligt at de havde kraeft.";
                    caseFile.StickyNoteText = "- Gaelder uden for jobbet";
                    caseFile.Solution = "Approve";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 4:
                    caseFile.Text = "Anklage\nPerson A anklager firma B for at dele personfoelsom data.\n\n" +
                                    "Scenarie\nPerson A har faaet kendskab til at firma B\n" +
                                    "har delt personfoelsom data blandt medarbejdere.\n" +
                                    "Person A ved dog ikke hvilke personfoelsom data det omhandler\n" +
                                    "men ved at det er sket.\n";
                    caseFile.StickyNoteText = "-Internt er ok";
                    caseFile.Solution = "Deny";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 5:
                    caseFile.Text = "Anklage\nPerson A har anklaget firma B for at opbevare\n og behandle deres persondata uden samtykke.\n\n" +
                                    "Scenarie\nPerson A har koebt en vare paa en webshop\n" +
                                    "styret af firma B, hvor A har fundet ud af at B opbevarer deres\n" +
                                    "persondata som indbefatter deres koen.\n" +
                                    "Ved koeb af en vare har firma B nogle formularer som kunden skal\n" +
                                    "godkende som omhandler haandtering og brug af data.\n";
                    caseFile.StickyNoteText = "- OK ved samtykke";
                    caseFile.Solution = "Deny";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 6:
                    caseFile.Text = "Anklage\nPolitiet anklager firma B for at opbevare persondata\n" +
                                    "som de ikke anvender.\n\n" +
                                    "Scenarie\nVed koeb af varer hos webshoppen, firma B, bliver kunder spurgt\n" +
                                    "om hvilket politiske parti de stoetter.\n" +
                                    "Den data anvendes til statistikker.\n" +
                                    "Politiet har undersoegt sagen og fundet ud af at firma B\n" +
                                    "falsificerer deres statistikker.\n";                    
                    caseFile.StickyNoteText = "- Kun det man\nhar brug for";
                    caseFile.Solution = "Approve";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 7:
                    caseFile.Text = "Anklage\nPerson A har anklaget firma B, for ikke at have\n" +
                                    "slettet deres data ved ophaevelse af samtykke.\n\n" +
                                    "Scenarie\nPerson A har skrevet en mail til firma B, hvor de udtrykker deres oenske\n" +
                                    "om at ophaeve samtykket angaaende deres persondata.\n" +
                                    "Firma B har set mailen og svaret at de fjerner data med det samme.\n" +
                                    "Den dataansvarlige hos Firma B har vaeret syg i et par dage\n" +
                                    "og derfor foerst slettet data, efter de kom tilbage paa jobbet.\n";
                    caseFile.StickyNoteText = "- Slet hurtigst muligt";
                    caseFile.Solution = "Deny";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 8:
                    caseFile.Text = "Anklage\nPerson A anfoerte i sagen, at de ikke havde givet samtykke til\n" +
                                    "at billeder af dem kunne benyttes i markedsfoeringsoejemed\n" +
                                    "af sin tidligere arbejdsgiver.\n\n" +
                                    "Scenarie\nHadsund Apotek i forbindelse med apotekets rekruttering af nye\n" +
                                    "farmakonom-elever benyttede billeder af en tidligere medarbejder\n" +
                                    "person A, i en markedsfoeringsvideo som blev offentliggjort paa Facebook.\n" +
                                    "Omvendt anfoerte Hadsund Apotek, at Hadsund Apotek kunne\n" +
                                    "benytte billederne uden klagers samtykke, da Hadsund Apoteks legitime\n" +
                                    "interesse heri oversteg klagers interesser.\n";
                    caseFile.StickyNoteText = "Ved kontraktophoevelse\n- Ophoeves samtykke\n";
                    caseFile.Solution = "Approve";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 9:
                    caseFile.Text = "Anklage\nAnmelderen har anklaget, at Silkeborg Kommune sendte en e-mail\n" +
                                    "til Danmarks Statistik Consulting.\n" +
                                    "E-mailen indeholdt en liste med cpr-nummer skolenavn\n" +
                                    "og skolekode for 12.915 skoleelever.\n" +
                                    "Det fremgaar af anmeldelsen at e-mailen ikke var sendt sikkert\n" +
                                    "og saaledes ikke krypteret fra afsender til modtager.\n\n" +
                                    "Scenarie\nSilkeborg Kommune har den 12. august 2021 paa Datatilsynets\n" +
                                    "forespoergsel oplyst at der paa tidspunktet for e-mailens afsendelse\n" +
                                    "var implementeret TLS 1.1 kryptering i kommunen, hvorfor den\n" +
                                    "paagaeldende e-mail muligvis kunne vaere krypteret paa\n" +
                                    "transportlaget med TLS 1.1.\n" +
                                    "Kommunen kontaktede hurtigt efter afsendelsen modtageren\n" +
                                    "og sikrede sig at e-mailen var kommet frem til rette modtager.";
                    caseFile.StickyNoteText = "Er det sikkert?";
                    caseFile.Solution = "Approve";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 10:
                    caseFile.Text = "Anklage\nTo konkrete klager har givet anledning til en anklage, at Gul og Gratis\n" +
                                    "brug af saakaldte cookie walls bryder rammerne af\n" +
                                    "databeskyttelsesreglerne.\n\n" +
                                    "Scenarie\nGul og Gratis brug af cookie walls inbefatter:\n" +
                                    "-Virksomheden tilbyder et alternativ til at give samtykke i\n" +
                                    "form af adgang mod betaling.\n" +
                                    "-Betaling giver adgang til en tjeneste, der i vidt omfang er\n" +
                                    "tilsvarende den tjeneste man kan faa adgang til gennem samtykke.\n" +
                                    "-Prissaetningen af betalingsalternativet er ikke urimelig hoej\n" +
                                    "dvs. at prissaetningen ikke er saa hoej, at den registrerede reelt\n" +
                                    "og i praksis ikke har et valg mellem betalingsalternativet\n" +
                                    "og at give sit samtykke.";
                    caseFile.StickyNoteText = "Samtykke?";
                    caseFile.Solution = "Deny";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
            }
            return gameObject;
        }
    }
}
