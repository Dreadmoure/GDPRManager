using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace GDPRManager.ComponentPattern
{
    public class TextRenderer : Component
    {

        #region properties
        /// <summary>
        /// Property for getting or setting the sprite
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Property for getting or setting the font for normal text
        /// </summary>
        public SpriteFont TextFont { get; private set; }

        public string FontName { get; set; }

        /// <summary>
        /// Property for getting or setting the origin of the sprite
        /// </summary>
        public Vector2 Origin { get; set; }

        /// <summary>
        /// Property for getting or setting the layerdepth of the image
        /// </summary>
        public float LayerDepth { get; set; }

        /// <summary>
        /// Property for getting or setting the position of the text
        /// </summary>
        public Vector2 Position { get; private set; }

        public float Rotation { get; set; }
        #endregion

        #region methods
        /// <summary>
        /// method for setting the origin for the text by using measurestring
        /// </summary>
        public override void Start()
        {

        }

        /// <summary>
        /// method for setting the sprite based on the input string
        /// </summary>
        /// <param name="spriteName">path and name of the file</param>
        public void SetText(string text, Vector2 position)
        {
            TextFont = GameWorld.Instance.Content.Load<SpriteFont>($"Fonts\\{FontName}");
            Text = text;
            Position = position;
        }

        /// <summary>
        /// method for drawing a sprite to the screen
        /// </summary>
        /// <param name="spriteBatch">passed in from gameworld so we can draw through it</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            float textX = TextFont.MeasureString(Text).X / 2;
            float textY = TextFont.MeasureString(Text).Y / 2;

            Origin = new Vector2(textX, textY);

            spriteBatch.DrawString(TextFont, Text, Position, Color.Black, Rotation, Origin, 1f, SpriteEffects.None, LayerDepth);
        }
        #endregion
    }
}
