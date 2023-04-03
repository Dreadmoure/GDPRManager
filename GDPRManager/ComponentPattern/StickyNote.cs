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
        public string Text { get; set; }
        public TextRenderer TextRenderer { get; set; }

        /// <summary>
        /// sets sprite and position
        /// </summary>
        public override void Start()
        {
            SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            spriteRenderer.SetSprite("Sprites\\StickyNote");
            spriteRenderer.LayerDepth = 0.5f;
            spriteRenderer.Scale = 1f;

            GameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 1.2f, GameWorld.ScreenSize.Y / 3f);
            GameObject.Tag = "StickyNote";
            
            TextRenderer = GameObject.GetComponent<TextRenderer>() as TextRenderer;
            TextRenderer.LayerDepth = 0.51f;
            TextRenderer.FontName = "StickyNoteFont";
            Text = "";
            TextRenderer.SetText(Text, GameObject.Transform.Position);
        }
    }
}
