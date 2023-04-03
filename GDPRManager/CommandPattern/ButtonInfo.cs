using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CommandPattern
{
    /// <summary>
    /// class for the ButtonInfo
    /// </summary>
    public class ButtonInfo
    {
        /// <summary>
        /// property for getting or setting wether a button is down
        /// </summary>
        public bool IsDown { get; set; }

        /// <summary>
        /// property for getting or setting a buttonstate
        /// </summary>
        public ButtonState State { get; set; }

        /// <summary>
        /// constructor which takes an argument so we can define a button
        /// </summary>
        /// <param name="state">state of the button</param>
        public ButtonInfo(ButtonState state)
        {
            State = state; 
        }
    }
}
