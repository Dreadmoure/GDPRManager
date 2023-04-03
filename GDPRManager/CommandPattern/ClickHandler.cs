using GDPRManager.ComponentPattern;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CommandPattern
{
    /// <summary>
    /// class for a ClickHandler
    /// </summary>
    public class ClickHandler
    {
        #region singleton
        private static ClickHandler instance;

        public static ClickHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClickHandler();
                }
                return instance;
            }
        }
        #endregion

        private Dictionary<ButtonInfo, ICommand<Clickable>> mouseBinds = new Dictionary<ButtonInfo, ICommand<Clickable>>();

        /// <summary>
        /// private constructor for a clickHandler
        /// </summary>
        private ClickHandler()
        {
            mouseBinds.Add(new ButtonInfo(Mouse.GetState().LeftButton), new ClickCommand());
        }

        /// <summary>
        /// Method for checking if the mousebutton is clicked
        /// </summary>
        /// <param name="clickable">the object which has the clickhandler</param>
        public void Execute(Clickable clickable)
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                mouseBinds.Values.First().Execute(clickable);
                mouseBinds.Keys.First().IsDown = true; 
            }
            else if(mouseState.LeftButton == ButtonState.Released && mouseBinds.Keys.First().IsDown)
            {
                mouseBinds.Keys.First().IsDown = false; 
            }
        }

    }
}
