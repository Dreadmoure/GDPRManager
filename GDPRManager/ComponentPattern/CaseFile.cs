using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    public class CaseFile : Component
    {
        public string Solution { get; set; }

        public string Text { get; set; }

        public string StickyNoteText { get; set; }

        /// <summary>
        /// sets sprite and position
        /// </summary>
        public override void Start()
        {
            SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            spriteRenderer.SetSprite("Sprites\\CaseFile");
            spriteRenderer.LayerDepth = 0.7f;
            spriteRenderer.Scale = 1f;
            
            GameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 2f, GameWorld.ScreenSize.Y / 2f);
            GameObject.Tag = "CaseFile";

            TextRenderer textRenderer = GameObject.GetComponent<TextRenderer>() as TextRenderer;
            textRenderer.LayerDepth = 0.71f;
            textRenderer.FontName = "NormalTextFont";
            Text = "";
            //textRenderer.SetText(Text, GameObject.Transform.Position);
        }
        

    }
}
