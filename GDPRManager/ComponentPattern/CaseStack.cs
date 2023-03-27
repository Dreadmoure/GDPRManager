using GDPRManager.CommandPattern;
using GDPRManager.ObserverPattern;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    public class CaseStack : Clickable
    {
        /// <summary>
        /// sets sprite and position
        /// </summary>
        public override void Start()
        {
            SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            spriteRenderer.SetSprite("Sprites\\CaseStack");
            spriteRenderer.LayerDepth = 0.7f;
            spriteRenderer.Scale = 1f;
            GameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 6f, GameWorld.ScreenSize.Y / 1.5f);

            GameObject.Tag = "Stack"; 
        }

        public void Onclick()
        {
            //do something call resolve case
        }

        //public void Notify(GameEvent gameEvent)
        //{
        //    if (gameEvent is CollisionEvent)
        //    {
        //        GameObject other = (gameEvent as CollisionEvent).Other;

        //        if (other.Tag == "Mouse")
        //        {
        //            SpriteRenderer s = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;

        //            s.SetSprite("Sprites\\StickyNote");

        //            //ClickHandler.Instance.Execute(this);
        //        }
        //    }
        //}
    }
}
