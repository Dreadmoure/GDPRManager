using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    /// <summary>
    /// class for CaseFile
    /// </summary>
    public class CaseFile : Component
    {
        #region properties
        /// <summary>
        /// property for getting or setting the solution of a CaseFile
        /// </summary>
        public string Solution { get; set; }

        /// <summary>
        /// property for getting or setting the Text of a CaseFile
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// property for getting or setting the Text on the StickyNote
        /// </summary>
        public string StickyNoteText { get; set; }
        #endregion

        /// <summary>
        /// sets sprite, tag, font and position
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
        }
    }
}
