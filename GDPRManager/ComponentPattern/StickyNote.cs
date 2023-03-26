using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    public class StickyNote : Component
    {
        /// <summary>
        /// sets sprite and position
        /// </summary>
        public override void Start()
        {
            SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            spriteRenderer.SetSprite("Sprites\\StickyNote");
            spriteRenderer.LayerDepth = 0.9f;
            spriteRenderer.Scale = 0.7f;
            GameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 1.2f, GameWorld.ScreenSize.Y / 3f);
        }

        public void Update()
        {
            //check what case you are at and change string based on it
        }
    }
}
