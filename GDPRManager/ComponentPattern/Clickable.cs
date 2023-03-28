using GDPRManager.CommandPattern;
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
    public class Clickable : Component
    {
        public void ResolveCase(string answer, GameObject gameObject)
        {
            CaseFile caseFile = gameObject.GetComponent<CaseFile>() as CaseFile;
            if(answer == caseFile.Solution)
            {
                GameWorld.Instance.Score += 100;
            }
            else if(GameWorld.Instance.Score > 0)
            {
                GameWorld.Instance.Score -= 100;
            }
            Debug.WriteLine(GameWorld.Instance.Score);
        }
    }
}
