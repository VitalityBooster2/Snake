using Microsoft.Xna.Framework;
using Snake.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Wall : Entity, ICollidable
    {
        public Wall(Vector2 position, Sprite sprite) : base(position, sprite)
        {
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, sprite.Size.X, sprite.Size.Y);
           
        }
    }
}
