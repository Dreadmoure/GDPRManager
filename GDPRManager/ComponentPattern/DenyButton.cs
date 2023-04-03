using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    /// <summary>
    /// class for denyButton
    /// </summary>
    public class DenyButton : Clickable
    {
        /// <summary>
        /// sets sprite, tag and position
        /// </summary>
        public override void Start()
        {
            SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            spriteRenderer.SetSprite("Sprites\\DenyButtonV2");
            spriteRenderer.LayerDepth = 0.71f;
            spriteRenderer.Scale = 1f;
            GameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 1.73f, GameWorld.ScreenSize.Y / 1.2f);
            GameObject.Tag = "DenyButton";
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
                spriteRenderer.SetSprite("Sprites\\DenyButtonV2Hover");
            }
            else
            {
                SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
                spriteRenderer.SetSprite("Sprites\\DenyButtonV2");
            }

            Hover = false;
        }
    }
}
