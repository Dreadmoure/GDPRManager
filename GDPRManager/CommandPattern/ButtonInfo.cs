using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CommandPattern
{
    public class ButtonInfo
    {
        public bool IsDown { get; set; }

        public ButtonState State { get; set; }

        public ButtonInfo(ButtonState state)
        {
            State = state; 
        }
    }
}
