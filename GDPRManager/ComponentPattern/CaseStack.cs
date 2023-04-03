using GDPRManager.CommandPattern;
using GDPRManager.ObserverPattern;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            spriteRenderer.SetSprite("Sprites\\CaseStackV2");
            spriteRenderer.LayerDepth = 0.7f;
            spriteRenderer.Scale = 1f;
            GameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 6f, GameWorld.ScreenSize.Y / 1.5f);

            GameObject.Tag = "CaseStack"; 
        }

        public override void Update(GameTime gameTime)
        {
            if (Hover)
            {
                SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
                spriteRenderer.SetSprite("Sprites\\CaseStackV2Hover");
            }
            else
            {
                SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
                spriteRenderer.SetSprite("Sprites\\CaseStackV2");
            }

            Hover = false; 
        }
    }
}
