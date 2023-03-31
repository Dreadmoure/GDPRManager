using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    public class TutorialPage : Component
    {
        public string Text { get; set; }

        /// <summary>
        /// sets sprite and position
        /// </summary>
        public override void Start()
        {
            SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            spriteRenderer.SetSprite("Sprites\\CaseFile");
            spriteRenderer.LayerDepth = 0.8f;
            spriteRenderer.Scale = 1f;
            Text = "";
        }
    }
}
