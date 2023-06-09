﻿using Microsoft.Xna.Framework;
using SharpDX.XAudio2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    /// <summary>
    /// class for ApproveButton
    /// </summary>
    public class ApproveButton : Clickable
    {
        /// <summary>
        /// sets sprite, tag and position
        /// </summary>
        public override void Start()
        {
            SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            spriteRenderer.SetSprite("Sprites\\ApproveButtonV2");
            spriteRenderer.LayerDepth = 0.71f;
            spriteRenderer.Scale = 1f;
            GameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 2.4f, GameWorld.ScreenSize.Y / 1.2f);
            GameObject.Tag = "ApproveButton";
        }

        /// <summary>
        /// method for updating the sprite, for hover effects
        /// </summary>
        /// <param name="gameTime">we can access the gametime should we need it</param>
        public override void Update(GameTime gameTime)
        {
            if (Hover)
            {
                SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
                spriteRenderer.SetSprite("Sprites\\ApproveButtonV2Hover");
            }
            else
            {
                SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
                spriteRenderer.SetSprite("Sprites\\ApproveButtonV2");
            }

            Hover = false;
        }
    }
}
