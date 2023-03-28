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
        public SpriteFont NormalTextFont { get; private set; }

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

        /// <summary>
        /// property for getting or setting the scale of the image
        /// </summary>
        public float Scale { get; set; }
        #endregion

        #region methods
        /// <summary>
        /// method for setting the origin for the text by using measurestring
        /// </summary>
        public override void Start()
        {
            LayerDepth = 0.8f;
            Scale = 1f;
        }

        /// <summary>
        /// method for setting the sprite based on the input string
        /// </summary>
        /// <param name="spriteName">path and name of the file</param>
        public void SetText(string text, Vector2 position)
        {
            NormalTextFont = GameWorld.Instance.Content.Load<SpriteFont>("Fonts\\NormalTextFont");
            Text = text;
            Position = position;
        }

        /// <summary>
        /// method for drawing a sprite to the screen
        /// </summary>
        /// <param name="spriteBatch">passed in from gameworld so we can draw through it</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            float textX = NormalTextFont.MeasureString(Text).X / 2;
            float textY = NormalTextFont.MeasureString(Text).Y / 2;

            Origin = new Vector2(textX, textY);

            spriteBatch.DrawString(NormalTextFont, Text, Position, Color.Black, 0f, Origin, Scale, SpriteEffects.None, LayerDepth);
        }
        #endregion
    }
}
