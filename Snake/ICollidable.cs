using Microsoft.Xna.Framework;

namespace Snake
{
    public interface ICollidable
    {
        bool Collided { get; set; }

        Rectangle Hitbox { get; set; }
    }
}