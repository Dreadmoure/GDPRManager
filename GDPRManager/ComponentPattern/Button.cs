using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    public abstract class Button : Component
    {
        protected string answer;

        #region methods
        public override void Start()
        {

        }

        public abstract void Onclick();
        #endregion
    }
}
