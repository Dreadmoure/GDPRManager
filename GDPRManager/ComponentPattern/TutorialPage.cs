using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    /// <summary>
    /// class for a TutorialPage
    /// </summary>
    public class TutorialPage : Component
    {
        /// <summary>
        /// property used for getting and setting the text on the TutorialPage
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// sets sprite, scale, layer, tag, font and position
        /// </summary>
        public override void Start()
        {
            SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            spriteRenderer.SetSprite("Sprites\\CaseFile");
            spriteRenderer.LayerDepth = 0.8f;
            spriteRenderer.Scale = 1f;

            GameObject.Transform.Position = new Vector2(GameWorld.ScreenSize.X / 2f, GameWorld.ScreenSize.Y / 2f);
            GameObject.Tag = "CaseFile";

            TextRenderer textRenderer = GameObject.GetComponent<TextRenderer>() as TextRenderer;
            textRenderer.LayerDepth = 0.81f;
            textRenderer.FontName = "NormalTextFont";
            Text = "";
        }
    }
}
