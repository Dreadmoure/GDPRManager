﻿using GDPRManager.ComponentPattern;
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
    /// <summary>
    /// class for ClickCommand
    /// </summary>
    public class ClickCommand : ICommand<Clickable>
    {
        #region fields
        private bool isCaseActive = false;
        private GameObject caseFile;
        private GameObject tutorialPage;
        private GameObject stickyNote;

        private GameObject approveButton; 
        private GameObject denyButton; 
        private GameObject nextButton;
        #endregion

        /// <summary>
        /// private constructor for ClickCommand
        /// </summary>
        public ClickCommand()
        {

        }

        /// <summary>
        /// Method for checking what is being clicked on
        /// </summary>
        /// <param name="clickable">the clickable object we click on</param>
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
                    GameOver();
                }
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
                    GameOver(); 
                }
            }
            else if(clickable.GameObject.Tag == "ExitButton" && !isCaseActive)
            {
                GameWorld.Instance.Exit(); 
            }
        }

        /// <summary>
        /// method for setting the text on the stickynote
        /// </summary>
        private void SetStickyNoteText()
        {
            CaseFile casefile = caseFile.GetComponent<CaseFile>() as CaseFile;
            StickyNote note = stickyNote.GetComponent<StickyNote>() as StickyNote;
            note.Text = casefile.StickyNoteText;
            note.TextRenderer.SetText(note.Text, stickyNote.Transform.Position);
        }

        /// <summary>
        /// method for removing the text on the stickynote
        /// </summary>
        private void RemoveStickyNoteText()
        {
            CaseFile casefile = caseFile.GetComponent<CaseFile>() as CaseFile;
            StickyNote note = stickyNote.GetComponent<StickyNote>() as StickyNote;
            note.Text = "";
            note.TextRenderer.SetText(note.Text, stickyNote.Transform.Position);
        }

        /// <summary>
        /// method for gameover, which is being called when there are no more cases left
        /// </summary>
        private void GameOver()
        {
            GameObject exitButton = ButtonFactory.Instance.Create(4);
            GameWorld.Instance.Instantiate(exitButton);

            GameObject overlay = OverlayFactory.Instance.Create(1);
            GameWorld.Instance.Instantiate(overlay);
        }
    }
}
