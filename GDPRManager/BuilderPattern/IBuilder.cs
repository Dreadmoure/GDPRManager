using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.BuilderPattern
{
    /// <summary>
    /// Interface IBuilder
    /// </summary>
    public interface IBuilder
    {
        /// <summary>
        /// for implementation
        /// </summary>
        public void BuildGameObject();


        public GameObject GetResult();
    }
}
