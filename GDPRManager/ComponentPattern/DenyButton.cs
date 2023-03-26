﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    public class DenyButton : Button
    {
        /// <summary>
        /// sets sprite and position
        /// </summary>
        public override void Start()
        {
            SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            spriteRenderer.SetSprite("Sprites\\DenyButton");
            spriteRenderer.LayerDepth = 0.9f;
            spriteRenderer.Scale = 1f;
            GameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 1.4f, GameWorld.ScreenSize.Y / 1.2f);
        }

        public override void Onclick()
        {
            throw new NotImplementedException();
        }
    }
}
