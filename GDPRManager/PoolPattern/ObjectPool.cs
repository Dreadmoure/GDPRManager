using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.PoolPattern
{
    /// <summary>
    /// used to create and reuse objects
    /// </summary>
    public abstract class ObjectPool
    {
        #region fields
        private List<GameObject> active = new List<GameObject>();
        private Queue<GameObject> inactive = new Queue<GameObject>();
        #endregion

        #region methods
        /// <summary>
        /// method for creating a new object or reusing based on the content of the inactive Queue
        /// </summary>
        /// <returns>Returns the new or reused gameobject</returns>
        public GameObject GetObject()
        {
            GameObject gameObject;

            //if the list is empty create new
            if (inactive.Count == 0)
            {
                gameObject = Create();
                active.Add(gameObject);
                return gameObject;
            }
            //if the list is not empty, remove from stack and add to the active list
            gameObject = inactive.Dequeue();
            active.Add(gameObject);
            return gameObject;
        }

        /// <summary>
        /// Method for removing an object
        /// </summary>
        /// <param name="gameObject">the object we wish to remove</param>
        public void ReleaseObject(GameObject gameObject)
        {
            //remove from active list
            active.Remove(gameObject);

            //add it to the inactive list
            inactive.Enqueue(gameObject);

            //remove object from the game
            GameWorld.Instance.Destroy(gameObject);

            //call cleanup
            CleanUp(gameObject);
        }

        protected abstract GameObject Create();

        protected abstract void CleanUp(GameObject gameObject);
        #endregion
    }
}
