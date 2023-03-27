using GDPRManager.ComponentPattern;
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
        public ClickCommand()
        {

        }

        public void Execute(Clickable clickable)
        {

            //Debug.WriteLine("kage");

            if (clickable.GameObject.Tag == "CaseStack")
            {
                //clickable.CreateCaseFile() but shouldnt that be one 
                Debug.WriteLine("Clicked on CaseStack");
            }
            else if(clickable.GameObject.Tag == "ApproveButton")
            {
                Debug.WriteLine("Clicked on ApproveButton");
            }
            else if(clickable.GameObject.Tag == "DenyButton")
            {
                Debug.WriteLine("Clicked on DenyButton");
            }


        }
    }
}
