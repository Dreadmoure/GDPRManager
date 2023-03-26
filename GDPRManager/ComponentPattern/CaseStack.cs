using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    public class CaseStack : Component
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
        }

        public void Onclick()
        {
            //do something call resolve case
        }
    }
}
