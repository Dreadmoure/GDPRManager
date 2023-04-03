using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    /// <summary>
    /// class for the exitbutton
    /// </summary>
    public class ExitButton : Clickable
    {
        /// <summary>
        /// method for setting the sprite, tag and position
        /// </summary>
        public override void Start()
        {
            SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            spriteRenderer.SetSprite("Sprites\\Afslut");
            spriteRenderer.LayerDepth = 1f;
            spriteRenderer.Scale = 1f;
            GameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 2f, GameWorld.ScreenSize.Y / 2f);
            GameObject.Tag = "ExitButton";
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
                spriteRenderer.SetSprite("Sprites\\AfslutHover");
            }
            else
            {
                SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
                spriteRenderer.SetSprite("Sprites\\Afslut");
            }

            Hover = false;
        }
    }
}
