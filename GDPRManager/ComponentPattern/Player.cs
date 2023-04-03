﻿using GDPRManager.CommandPattern;
using GDPRManager.CreationalPattern;
using GDPRManager.ObserverPattern;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{

    /// <summary>
    /// class for the player....do we even need this?
    /// </summary>
    public class Player : Component
    {
        #region fields
        //private MouseState currentMouse;
        //private MouseState previousMouse;
        //public bool isClicked;

        #endregion

        #region properties
        #endregion

        #region methods

        /// <summary>
        /// sets players start values
        /// </summary>
        public override void Awake()
        {
            
        }

        /// <summary>
        /// sets sprite and initial position
        /// </summary>
        public override void Start()
        {
            
        }

        /// <summary>
        /// Updates the player each frame
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //handles input
            InputHandler.Instance.Execute(this);

            //previousMouse = currentMouse;
            //currentMouse = Mouse.GetState();

            //Rectangle mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            //if (mouseRectangle.Intersects(GetRectangle))
            //{
            //    ColorShift();

            //    if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
            //    {
            //        isClicked = true;
            //        color.A = 255;
            //    }
            //}
            //else if (color.A < 255)
            //{
            //    color.A += 3;
            //}

            //if clicked do something

        }


        #endregion
    }
}
