using GDPRManager.ComponentPattern;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.CreationalPattern
{
    /// <summary>
    /// used to hold types of minerals
    /// </summary>
    public enum MineralType { Red, Green }

    /// <summary>
    /// class for making minerals of different types
    /// </summary>
    public class CaseFactory
    {
        #region singleton
        private static CaseFactory instance;

        public static CaseFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CaseFactory();
                }
                return instance;
            }
        }
        #endregion

        private Random random = new Random();

        /// <summary>
        /// Method for creating a gameobject
        /// </summary>
        /// <param name="type">of a type based on an enum</param>
        /// <returns>the created gameobject</returns>
        public GameObject Create(Enum type)
        {
            GameObject gameObject = new GameObject();

            SpriteRenderer spriteRenderer = gameObject.AddComponent(new SpriteRenderer()) as SpriteRenderer;
            gameObject.Transform.Position = new Vector2(random.Next(0, GameWorld.Instance.GraphicsDevice.Viewport.Width), -20);
            gameObject.AddComponent(new Collider());
            Collider collider = (Collider)gameObject.AddComponent(new Collider());
            gameObject.Tag = "Mineral";
            spriteRenderer.LayerDepth = 0.4f;
            spriteRenderer.Scale = 1f;


            Mineral mineral;


            switch (type)
            {
                case MineralType.Green:
                    spriteRenderer.SetSprite("Minerals\\RockWater_2V3");
                    mineral = gameObject.AddComponent(new Mineral(50)) as Mineral;
                    break;
                case MineralType.Red:
                    spriteRenderer.SetSprite("Minerals\\RockWaterV3");
                    mineral = gameObject.AddComponent(new Mineral(100)) as Mineral;
                    break;
            }
            return gameObject;
        }
    }
}
