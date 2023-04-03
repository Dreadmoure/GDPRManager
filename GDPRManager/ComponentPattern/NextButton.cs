using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    /// <summary>
    /// class for NextButton
    /// </summary>
    public class NextButton : Clickable
    {
        /// <summary>
        /// sets sprite, tag and position
        /// </summary>
        public override void Start()
        {
            SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            spriteRenderer.SetSprite("Sprites\\NextButton");
            spriteRenderer.LayerDepth = 0.81f;
            spriteRenderer.Scale = 1f;
            GameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 1.65f, GameWorld.ScreenSize.Y / 7.6f);
            GameObject.Tag = "NextButton";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime">we can access the gametime here should we need it</param>
        public override void Update(GameTime gameTime)
        {
            if (Hover)
            {
                SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
                spriteRenderer.SetSprite("Sprites\\NextButtonHover");
            }
            else
            {
                SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
                spriteRenderer.SetSprite("Sprites\\NextButton");
            }

            Hover = false;
        }
    }
}
