using System;
using Microsoft.Xna.Framework;
using Snake.Graphics;

namespace Snake
{
    public abstract class Entity : IUpdateable, IAnimatabe, ICollidable
    {
        #region  Properties
        public Vector2 Position { get; set; }

        public Rectangle Hitbox { get; set; }

        public bool Collided { get; set; }

        public Sprite Sprite { get; set; }
        #endregion

        public Entity(Vector2 position, Sprite sprite)
        {
          
            Position = position;
            Sprite = sprite;
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, sprite.Size.X, sprite.Size.Y);
        }

        public virtual void Update(GameTime gameTime)
        {

            Sprite.Position = Position;
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, Sprite.Size.X, Sprite.Size.Y);
        }
    }
}
