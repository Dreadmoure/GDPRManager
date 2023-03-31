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
            
            
            SpriteRenderer spriteRenderer = caseFilePrototype.AddComponent(new SpriteRenderer()) as SpriteRenderer;
            caseFilePrototype.Tag = "CaseFile";
            spriteRenderer.LayerDepth = 0.7f;
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
        public override GameObject Create(int id)
        {
            GameObject gameObject = new GameObject();
            gameObject = (GameObject)caseFilePrototype.Clone();
            gameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y / 2);
            TextRenderer textRenderer = gameObject.GetComponent<TextRenderer>() as TextRenderer;
            CaseFile caseFile;

            textRenderer.FontName = "NormalTextFont";

            switch (id)
            {
                case 1:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;                    
                    caseFile.Text = "Anklage\nFirma A har delt personfoelsom data.\n\n" +
                                    "Scenarie\nEn ansat i Firma A har ved et uheld vedhaeftet fornavn\nefternavn og deres politiske overbevisning, paa en anden kunde\ni en mail til en helt tredje som er en privatperson.";
                    caseFile.StickyNoteText = "- Race og etnicitet\n- Politik\n- Religion eller filosofi\n- Fagforening\n- Helbred\n";
                    caseFile.Solution = "Approve";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    //needs a string for the text that can vary
                    break;
                case 2:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Text = "Anklage\nPerson A har anklaget sin nabo, person B\nfor at dele personfoelsom data.\n\n" +
                                    "Scenarie\nPerson B har gjort grin med Person A paa Facebook\nhvor de udstiller As etnicitet.";
                    caseFile.StickyNoteText = "- Regler omfatter:\n- Organisationer\n- Virksomheder\n -Ikke privatpersoner\n";
                    caseFile.Solution = "Deny";                    
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 3:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Text = "Anklage\nPerson A har anklaget sin ven, person B, for at dele personfoelsom data.\n\n" +
                                    "Scenarie\nPerson B er en laege som har sin egen private praksis.\nPerson A og person B havde en samtale omkring en klient fra Bs arbejde\nhvor B naevnte klienten ved navn og syntes det var\nforfaerdeligt at de havde kraeft.";
                    caseFile.StickyNoteText = "- Gaelder uden for jobbet";
                    caseFile.Solution = "Approve";                                     
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 4:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Text = "Anklage\nPerson A anklager firma B for at dele personfoelsom data.\n\n" +
                                    "Scenarie\nPerson A har faaet kendskab til at firma B\nhar delt personfoelsom data blandt medarbejdere.\nPerson A ved dog ikke hvilke personfoelsom data det omhandler\nmen ved at det er sket.\n";
                    caseFile.StickyNoteText = "-Internt er ok";
                    caseFile.Solution = "Deny"; 
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 5:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Text = "Anklage\nPerson A har anklaget firma B for at opbevare\n og behandle deres persondata uden samtykke.\n\n" +
                                    "Scenarie\nPerson A har koebt en vare paa en webshop\nstyret af firma B, hvor A har fundet ud af at B opbevarer deres\npersondata som indbefatter deres koen.\nVed koeb af en vare har firma B nogle formularer som kunden skal\ngodkende som omhandler haandtering og brug af data.\n";
                    caseFile.StickyNoteText = "- OK ved samtykke";
                    caseFile.Solution = "Deny";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 6:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Text = "Anklage\nPolitiet anklager firma B for at opbevare persondata\nsom de ikke anvender.\n\n" +
                                    "Scenarie\nVed koeb af varer hos webshoppen, firma B, bliver kunder spurgt\nom hvilket politiske parti de stoetter.\nDen data anvendes til statistikker.\nPolitiet har undersoegt sagen og fundet ud af at firma B\nfalsificerer deres statistikker.\n";                    
                    caseFile.StickyNoteText = "- Kun det man\nhar brug for";
                    caseFile.Solution = "Approve";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 7:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Text = "Anklage\nPerson A har anklaget firma B, for ikke at have\nslettet deres data ved ophaevelse af samtykke.\n\n" +
                                    "Scenarie\nPerson A har skrevet en mail til firma B, hvor de udtrykker deres oenske\nom at ophaeve samtykket angaaende deres persondata.\nFirma B har set mailen og svaret at de fjerner data med det samme.\nDen dataansvarlige hos Firma B har vaeret syg i et par dage\nog derfor foerst slettet data, efter de kom tilbage paa jobbet.\n";
                    caseFile.StickyNoteText = "- Slet hurtigst muligt";
                    caseFile.Solution = "Deny";
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 8:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Text = "Anklage\nPerson A anfoerte i sagen, at de ikke havde givet samtykke til\nat billeder af dem kunne benyttes i markedsfoeringsoejemed\naf sin tidligere arbejdsgiver.\n\n" +
                                    "Scenarie\nHadsund Apotek i forbindelse med apotekets rekruttering af nye\nfarmakonom-elever benyttede billeder af en tidligere medarbejder\nperson A, i en markedsfoeringsvideo som blev offentliggjort paa Facebook.\nOmvendt anfoerte Hadsund Apotek, at Hadsund Apotek kunne\nbenytte billederne uden klagers samtykke, da Hadsund Apoteks legitime\ninteresse heri oversteg klagers interesser.\n";
                    caseFile.StickyNoteText = "Ved kontraktophoevelse\n- Ophoeves samtykke\n";
                    caseFile.Solution = "Approve";                  
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 9:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Text = "Anklage\nAnmelderen har anklaget, at Silkeborg Kommune sendte en e-mail\ntil Danmarks Statistik Consulting.\nE-mailen indeholdt en liste med cpr-nummer skolenavn\nog skolekode for 12.915 skoleelever.\nDet fremgaar af anmeldelsen at e-mailen ikke var sendt sikkert\nog saaledes ikke krypteret fra afsender til modtager.\n\n" +
                                    "Scenarie\nSilkeborg Kommune har den 12. august 2021 paa Datatilsynets\nforespoergsel oplyst at der paa tidspunktet for e-mailens afsendelse\nvar implementeret TLS 1.1 kryptering i kommunen, hvorfor den\npaagaeldende e-mail muligvis kunne vaere krypteret paa\ntransportlaget med TLS 1.1.\nKommunen kontaktede hurtigt efter afsendelsen modtageren\nog sikrede sig at e-mailen var kommet frem til rette modtager.";
                    caseFile.StickyNoteText = "Er det sikkert?";
                    caseFile.Solution = "Approve"; 
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
                case 10:
                    caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
                    caseFile.Text = "Anklage\nTo konkrete klager har givet anledning til en anklage, at Gul og Gratis\n brug af saakaldte cookie walls bryder rammerne af\ndatabeskyttelsesreglerne.\n\n" +
                                    "Scenarie\nGul og Gratis brug af cookie walls inbefatter:\n-Virksomheden tilbyder et alternativ til at give samtykke i\nform af adgang mod betaling.\n-Betaling giver adgang til en tjeneste, der i vidt omfang er\ntilsvarende den tjeneste man kan faa adgang til gennem samtykke.\n-Prissaetningen af betalingsalternativet er ikke urimelig hoej\ndvs. at prissaetningen ikke er saa hoej, at den registrerede reelt\nog i praksis ikke har et valg mellem betalingsalternativet\nog at give sit samtykke.";
                    caseFile.StickyNoteText = "Samtykke?";
                    caseFile.Solution = "Deny";                                       
                    textRenderer.SetText(caseFile.Text, gameObject.Transform.Position);
                    break;
            }
            return gameObject;
        }
    }
}
