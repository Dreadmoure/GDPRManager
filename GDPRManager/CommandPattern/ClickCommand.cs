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
        private GameObject gameObject;
        private StickyNote stickyNote;

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

                gameObject = new GameObject();
                gameObject = CaseFileFactory.Instance.Create(GameWorld.Instance.CaseFileID);
                GameWorld.Instance.Instantiate(gameObject);

                SetStickyNoteText();

                // make buttons 
                approveButton = new GameObject();
                approveButton = ButtonFactory.Instance.Create(1);
                GameWorld.Instance.Instantiate(approveButton);
                denyButton = new GameObject();
                denyButton = ButtonFactory.Instance.Create(2);
                GameWorld.Instance.Instantiate(denyButton);

                //Debug.WriteLine("Clicked on CaseStack");
            }
            else if(clickable.GameObject.Tag == "ApproveButton" && isCaseActive)
            {
                isCaseActive = false;
                clickable.ResolveCase("Approve", gameObject);
                GameWorld.Instance.CaseFileID++;
                GameWorld.Instance.Destroy(gameObject);

                RemoveStickyNoteText();

                GameWorld.Instance.Destroy(approveButton); 
                GameWorld.Instance.Destroy(denyButton); 

                //Debug.WriteLine("Clicked on ApproveButton");
            }
            else if(clickable.GameObject.Tag == "DenyButton" && isCaseActive)
            {
                isCaseActive = false;
                clickable.ResolveCase("Deny", gameObject);
                GameWorld.Instance.CaseFileID++;
                GameWorld.Instance.Destroy(gameObject);

                RemoveStickyNoteText();

                GameWorld.Instance.Destroy(approveButton);
                GameWorld.Instance.Destroy(denyButton);
                //Debug.WriteLine("Clicked on DenyButton");
            }


        }

        private void SetStickyNoteText()
        {
            CaseFile casefile = gameObject.GetComponent<CaseFile>() as CaseFile;
            stickyNote = GameWorld.Instance.StickyNoteObject.GetComponent<StickyNote>() as StickyNote;
            stickyNote.Text = casefile.StickyNoteText;
            stickyNote.TextRenderer.SetText(stickyNote.Text, GameWorld.Instance.StickyNoteObject.Transform.Position);
        }

        private void RemoveStickyNoteText()
        {
            CaseFile casefile = gameObject.GetComponent<CaseFile>() as CaseFile;
            stickyNote = GameWorld.Instance.StickyNoteObject.GetComponent<StickyNote>() as StickyNote;
            stickyNote.Text = "";
            stickyNote.TextRenderer.SetText(stickyNote.Text, GameWorld.Instance.StickyNoteObject.Transform.Position);
        }
    }
}
