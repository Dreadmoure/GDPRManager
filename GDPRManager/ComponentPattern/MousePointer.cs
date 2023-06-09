﻿using GDPRManager.CommandPattern;
using GDPRManager.ObserverPattern;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    /// <summary>
    /// class for the mousepointer used to click and collide with other objects
    /// </summary>
    public class MousePointer : Component, IGameListener
    {
        #region fields
        private Vector2 mousePosition;
        private MouseState mouseState;
        #endregion

        /// <summary>
        /// method for setting sprite and tag
        /// </summary>
        public override void Start()
        {
            SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            spriteRenderer.SetSprite("Sprites\\MousePointer");
            spriteRenderer.LayerDepth = 0.7f;
            spriteRenderer.Scale = 1f;

            GameObject.Tag = "Mouse";
        }

        /// <summary>
        /// Method for updating the mouse position
        /// </summary>
        /// <param name="gameTime">we can access the gametime should we need it</param>
        public override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            mousePosition = new Vector2(mouseState.X, mouseState.Y);
            GameObject.Transform.Position = new Vector2(mousePosition.X, mousePosition.Y);
        }

        /// <summary>
        /// handles gameevents
        /// </summary>
        /// <param name="gameEvent">the gameevent</param>
        public void Notify(GameEvent gameEvent)
        {
            if (gameEvent is CollisionEvent)
            {
                GameObject other = (gameEvent as CollisionEvent).Other;

                if (other.Tag == "CaseStack" || other.Tag == "ApproveButton" || other.Tag == "DenyButton" || other.Tag == "NextButton" || other.Tag == "ExitButton")
                {
                    Clickable clickable = other.GetComponent<Clickable>() as Clickable;
                    ClickHandler.Instance.Execute(clickable);
                }
                if(other.Tag == "CaseStack")
                {
                    CaseStack caseStack = other.GetComponent<CaseStack>() as CaseStack;
                    caseStack.Hover = true; 
                }
                if(other.Tag == "ApproveButton")
                {
                    ApproveButton approveButton = other.GetComponent<ApproveButton>() as ApproveButton;
                    approveButton.Hover = true;
                }
                if (other.Tag == "DenyButton")
                {
                    DenyButton denyButton = other.GetComponent<DenyButton>() as DenyButton;
                    denyButton.Hover = true;
                }
                if (other.Tag == "NextButton")
                {
                    NextButton nextButton = other.GetComponent<NextButton>() as NextButton;
                    nextButton.Hover = true;
                }
                if (other.Tag == "ExitButton")
                {
                    ExitButton exitButton = other.GetComponent<ExitButton>() as ExitButton;
                    exitButton.Hover = true;
                }
            }
        }
    }
}
