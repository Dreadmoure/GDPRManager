using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    public class Star : Component
    {
        #region fieldds
        //array with 2 spaces of textures
        private SpriteRenderer spriteRenderer;

        private static string[] spriteNames = new string[] { "Sprites\\StarFull", "Sprites\\StarEmpty" }; //change paths
        private Texture2D[] sprites = new Texture2D[spriteNames.Length];

        private Vector2 position;
        #endregion

        #region property
        /// <summary>
        /// property to get or set the ID of the Star
        /// </summary>
        public int StarID { get; private set; }

        /// <summary>
        /// get or set bool to see if the heart is full or not
        /// </summary>
        public bool IsFull { get; set; } = true;
        #endregion

        /// <summary>
        /// constructor for heart
        /// </summary>
        /// <param name="id">id of the star</param>
        /// <param name="position">position of the star</param>
        public Star(int id, Vector2 position)
        {
            StarID = id;
            this.position = position;
        }

        #region methods
        /// <summary>
        /// sets the sprite and position
        /// </summary>
        public override void Start()
        {
            GameObject.Transform.Position = position;

            spriteRenderer = (SpriteRenderer)GameObject.GetComponent<SpriteRenderer>();

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = GameWorld.Instance.Content.Load<Texture2D>(spriteNames[i]);
            }

            spriteRenderer.Sprite = sprites[0];

            spriteRenderer.LayerDepth = 1.0f;
            spriteRenderer.Scale = 1f;
        }

        /// <summary>
        /// checks each frame if the heart is supposed to not be full
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (IsFull)
            {
                spriteRenderer.Sprite = sprites[0];
            }
            else
            {
                spriteRenderer.Sprite = sprites[1];
            }
        }
        #endregion
    }
}
