using GDPRManager.CommandPattern;
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
    /// class for the player
    /// </summary>
    public class Player : Component, IGameListener
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

        /// <summary>
        /// hanldes gameevents
        /// </summary>
        /// <param name="gameEvent"></param>
        public void Notify(GameEvent gameEvent)
        {
            if (gameEvent is CollisionEvent)
            {
                GameObject other = (gameEvent as CollisionEvent).Other;

                if (other.Tag == "ApproveButton")
                {
                    //do something
                }
                if (other.Tag == "DenyButton")
                {
                    //do something
                }
            }
        }
        #endregion
    }
}
