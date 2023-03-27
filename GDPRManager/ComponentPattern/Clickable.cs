using GDPRManager.CommandPattern;
using GDPRManager.ObserverPattern;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    public class Clickable : Component, IGameListener
    {
        public void Notify(GameEvent gameEvent)
        {
            //if (gameEvent is CollisionEvent)
            //{
            //    GameObject other = (gameEvent as CollisionEvent).Other;

            //    if (other.Tag == "Mouse")
            //    {
            //        //SpriteRenderer s = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;

            //        //s.SetSprite("Sprites\\StickyNote");

            //        ClickHandler.Instance.Execute(this);
            //    }
            //}
        }
    }
}
