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
                
                //Debug.WriteLine("Clicked on CaseStack");
            }
            else if(clickable.GameObject.Tag == "ApproveButton" && isCaseActive)
            {
                isCaseActive = false;
                clickable.ResolveCase("Approve", gameObject);
                GameWorld.Instance.CaseFileID++;
                GameWorld.Instance.Destroy(gameObject);

                //Debug.WriteLine("Clicked on ApproveButton");
            }
            else if(clickable.GameObject.Tag == "DenyButton" && isCaseActive)
            {
                isCaseActive = false;
                clickable.ResolveCase("Deny", gameObject);
                GameWorld.Instance.CaseFileID++;
                GameWorld.Instance.Destroy(gameObject);
                //Debug.WriteLine("Clicked on DenyButton");
            }


        }
    }
}
