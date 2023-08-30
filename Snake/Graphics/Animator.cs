using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.Graphics
{
    public class Animator
    {
        private double changePeriod = 4.0;

        private Rectangle sourceRect;

        private Rectangle DestRect;

        private double timer = 0.0;

        private int frame = 0;

        public double totalDuration { private get; set; }

        public float Rotation { private get; set; }

        public Sprite Sprite { get; private set; }

        public Animator()
        {
        }

        public Animator(Sprite sprite)
        {
            Sprite = sprite;
            totalDuration = sprite.FrameCount * changePeriod;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 origin)
        {
            spriteBatch.Draw(Sprite.texture, DestRect, sourceRect, Color.White, Rotation, origin, Sprite.spriteEffects, 1f);
        }

        public void Update(GameTime gameTime, in Sprite sprite, float rotation)
        {
            Rotation = rotation;
            if (Sprite != sprite)
            {
                totalDuration = changePeriod * sprite.FrameCount;
                sourceRect = new Rectangle(0, 0, Sprite.Size.X, Sprite.Size.Y);
                Sprite = sprite;
                frame = 0;
                timer = 0.0;
            }

            timer += 1.0;
            DestRect = new Rectangle((int)Sprite.Position.X, (int)Sprite.Position.Y, Sprite.Size.X, Sprite.Size.Y);
            if (sourceRect.X >= Sprite.texture.Width - Sprite.Size.X & timer >= changePeriod)
            {
                timer = 0.0;
                frame = 0;
                sourceRect.X = 0;
            }

            if (timer >= changePeriod)
            {
                frame++;
                timer = 0.0;
            }

            if (Sprite.texture.Width == Sprite.Size.X)
            {
                sourceRect = new Rectangle(0, 0, Sprite.Size.X, Sprite.Size.Y);
            }
            else
            {
                sourceRect = new Rectangle(frame * Sprite.Size.X, 0, Sprite.Size.X, Sprite.Size.Y);
            }
        }
    }
}