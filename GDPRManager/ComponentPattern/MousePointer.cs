using GDPRManager.CommandPattern;
using GDPRManager.ObserverPattern;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDPRManager.ComponentPattern
{
    public class MousePointer : Component, IGameListener
    {
        private Vector2 mousePosition;
        private MouseState mouseState;

        public override void Start()
        {
            SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            spriteRenderer.SetSprite("Sprites\\Pixel");
            spriteRenderer.LayerDepth = 0.7f;
            spriteRenderer.Scale = 1f;

            GameObject.Tag = "Mouse";
        }

        public override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            mousePosition = new Vector2(mouseState.X, mouseState.Y);
            GameObject.Transform.Position = new Vector2(mousePosition.X, mousePosition.Y);
        }

        public void Notify(GameEvent gameEvent)
        {
            if (gameEvent is CollisionEvent)
            {
                GameObject other = (gameEvent as CollisionEvent).Other;

                if (other.Tag == "Stack")
                {
                    SpriteRenderer s = other.GetComponent<SpriteRenderer>() as SpriteRenderer;

                    s.SetSprite("Sprites\\StickyNote");

                    Clickable clickable = other.GetComponent<Clickable>() as Clickable; 

                    ClickHandler.Instance.Execute(clickable);
                }
            }
        }
    }
}
