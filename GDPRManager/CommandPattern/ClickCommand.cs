using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CommandPattern
{
    public class ClickCommand : ICommand<Clickable>
    {
        public ClickCommand()
        {

        }

        public void Execute(Clickable clickable)
        {
            if(clickable is CaseStack)
            {

            }
        }
    }
}
