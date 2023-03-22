﻿using GDPRManager.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.BuilderPattern
{
    /// <summary>
    /// class for PlayerBuilder
    /// </summary>
    public class PlayerBuilder : IBuilder
    {
        private GameObject gameObject;

        /// <summary>
        /// creates a new gameobject
        /// </summary>
        public void BuildGameObject()
        {
            gameObject = new GameObject();

            BuildComponents();
        }

        /// <summary>
        /// adds components to the gameobject
        /// </summary>
        private void BuildComponents()
        {
            Player player = (Player)gameObject.AddComponent(new Player());
            gameObject.AddComponent(new SpriteRenderer());
            //gameObject.AddComponent(new Animator());
            gameObject.AddComponent(new Collider());
            Collider collider = (Collider)gameObject.AddComponent(new Collider());
            collider.CollisionEvent.Attach(player);

        }

        /// <summary>
        /// returns the object we built
        /// </summary>
        /// <returns>gameobject which was just built out of components</returns>
        public GameObject GetResult()
        {
            return gameObject;
        }

    }
}
