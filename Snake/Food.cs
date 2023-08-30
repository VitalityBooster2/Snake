
using Microsoft.Xna.Framework;
using Snake.Graphics;
using System;

namespace Snake
{

    public class Food : Entity
    {
        private Random rnd = new Random();
        public Food(Vector2 position, Sprite sprite):base(position, sprite)
        {
            Position = new Vector2(rnd.Next(80, Constants.WIDTH - 80), rnd.Next(80, Constants.HEIGHT - 80));
            Sprite = sprite;
            Sprite.Position = Position;
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, (int)Sprite.Size.X, (int)Sprite.Size.Y);
        }

        public void Restart() { }

        public override void Update(GameTime gameTime)
        {
            if (Collided) {Position = new Vector2(rnd.Next(80,Constants.WIDTH-80), rnd.Next(80,Constants.HEIGHT-80));  Collided = false;}
            base.Update(gameTime);
        }
    }
}
