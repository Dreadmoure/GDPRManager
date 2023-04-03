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
    /// <summary>
    /// class for clickable used to put on objects you can click on
    /// </summary>
    public class Clickable : Component
    {
        /// <summary>
        /// property for getting or setting Hover on a clickable
        /// </summary>
        public bool Hover { get; set; }

        /// <summary>
        /// handed down
        /// </summary>
        /// <param name="gameTime">we can access the gametime should we need it</param>
        public override void Update(GameTime gameTime)
        {
            
        }

        /// <summary>
        /// Checks the answer and evaluates the answer against the solution
        /// </summary>
        /// <param name="answer">the answer the player gives</param>
        /// <param name="gameObject">the caseFile object the solution is on</param>
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
