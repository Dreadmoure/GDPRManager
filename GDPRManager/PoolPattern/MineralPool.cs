using GDPRManager.CreationalPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.PoolPattern
{
    /// <summary>
    /// used to handle a mineral in the mineral pool
    /// </summary>
    public class MineralPool : ObjectPool
    {
        #region singleton
        private static MineralPool instance;

        public static MineralPool Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MineralPool();
                }
                return instance;
            }
        }
        #endregion

        #region fields
        private Random random = new Random();
        #endregion

        #region methods
        /// <summary>
        /// method for resettin references and position, not used as it is not nessecary
        /// </summary>
        /// <param name="gameObject">the object we wish to reset</param>
        protected override void CleanUp(GameObject gameObject)
        {
        }

        /// <summary>
        /// method for creating a new mineral
        /// </summary>
        /// <returns>returns the mineral as a gameobject</returns>
        protected override GameObject Create()
        {
            return MineralFactory.Instance.Create((MineralType)random.Next(0, 2));
        }
        #endregion
    }
}
