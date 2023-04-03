using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    /// <summary>
    /// class for a stickyNote
    /// </summary>
    public class StickyNote : Component
    {
        #region properties
        /// <summary>
        /// Property for getting and setting the text on the stickynote
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Property for getting and setting the textrenderer on the stickynote
        /// </summary>
        public TextRenderer TextRenderer { get; set; }
        #endregion

        /// <summary>
        /// method setting things on the component when start is called
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
            TextRenderer.Rotation = -0.05f;
            Text = "";
            TextRenderer.SetText(Text, GameObject.Transform.Position);
        }
    }
}
