using GDPRManager.ComponentPattern;
using GDPRManager.CreationalPattern;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CommandPattern
{
    public class ClickCommand : ICommand<Clickable>
    {
        private bool isCaseActive = false;
        private GameObject caseFile;
        private GameObject tutorialPage;
        private GameObject stickyNote;

        private GameObject approveButton; 
        private GameObject denyButton; 
        private GameObject nextButton; 

        public ClickCommand()
        {

        }

        public void Execute(Clickable clickable)
        {
            if (clickable.GameObject.Tag == "CaseStack" && !isCaseActive && GameWorld.Instance.CaseFileID <= 10)
            {
                isCaseActive = true;
                GameWorld.Instance.CaseFileStackSize--; 

                caseFile = new GameObject();
                caseFile = CaseFileFactory.Instance.Create(GameWorld.Instance.CaseFileID);
                GameWorld.Instance.Instantiate(caseFile);
                tutorialPage = new GameObject();
                tutorialPage = TutorialPageFactory.Instance.Create(GameWorld.Instance.CaseFileID);
                GameWorld.Instance.Instantiate(tutorialPage);
                stickyNote = new GameObject();
                stickyNote = StickyNoteFactory.Instance.Create(GameWorld.Instance.CaseFileID);
                GameWorld.Instance.Instantiate(stickyNote);


                // make button 
                nextButton = new GameObject();
                nextButton = ButtonFactory.Instance.Create(3);
                GameWorld.Instance.Instantiate(nextButton);

                //Debug.WriteLine("Clicked on CaseStack");
            }
            else if(clickable.GameObject.Tag == "NextButton" && isCaseActive)
            {
                //destroy tutorial and nextbutton
                GameWorld.Instance.Destroy(tutorialPage);
                GameWorld.Instance.Destroy(nextButton);

                //make buttons
                approveButton = new GameObject();
                approveButton = ButtonFactory.Instance.Create(1);
                GameWorld.Instance.Instantiate(approveButton);
                denyButton = new GameObject();
                denyButton = ButtonFactory.Instance.Create(2);
                GameWorld.Instance.Instantiate(denyButton);

                SetStickyNoteText();
            }
            else if(clickable.GameObject.Tag == "ApproveButton" && isCaseActive)
            {
                isCaseActive = false;
                clickable.ResolveCase("Approve", caseFile);
                GameWorld.Instance.CaseFileID++;
                GameWorld.Instance.Destroy(caseFile);

                RemoveStickyNoteText();

                GameWorld.Instance.Destroy(approveButton); 
                GameWorld.Instance.Destroy(denyButton); 
                GameWorld.Instance.Destroy(stickyNote); 

                if(GameWorld.Instance.CaseFileStackSize == 0)
                {
                    GameObject exitButton = ButtonFactory.Instance.Create(4);
                    GameWorld.Instance.Instantiate(exitButton);
                }
                
                //Debug.WriteLine("Clicked on ApproveButton");
            }
            else if(clickable.GameObject.Tag == "DenyButton" && isCaseActive)
            {
                isCaseActive = false;
                clickable.ResolveCase("Deny", caseFile);
                GameWorld.Instance.CaseFileID++;
                GameWorld.Instance.Destroy(caseFile);

                RemoveStickyNoteText();

                GameWorld.Instance.Destroy(approveButton);
                GameWorld.Instance.Destroy(denyButton);
                GameWorld.Instance.Destroy(stickyNote);
                //Debug.WriteLine("Clicked on DenyButton");

                if (GameWorld.Instance.CaseFileStackSize == 0)
                {
                    GameObject exitButton = ButtonFactory.Instance.Create(4);
                    GameWorld.Instance.Instantiate(exitButton);
                }
            }
            else if(clickable.GameObject.Tag == "ExitButton" && !isCaseActive)
            {
                GameWorld.Instance.Exit(); 
            }
        }

        private void SetStickyNoteText()
        {
            CaseFile casefile = caseFile.GetComponent<CaseFile>() as CaseFile;
            StickyNote note = stickyNote.GetComponent<StickyNote>() as StickyNote;
            note.Text = casefile.StickyNoteText;
            note.TextRenderer.SetText(note.Text, stickyNote.Transform.Position);
        }

        private void RemoveStickyNoteText()
        {
            CaseFile casefile = caseFile.GetComponent<CaseFile>() as CaseFile;
            StickyNote note = stickyNote.GetComponent<StickyNote>() as StickyNote;
            note.Text = "";
            note.TextRenderer.SetText(note.Text, stickyNote.Transform.Position);
        }
    }
}
