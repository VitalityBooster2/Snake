
using Microsoft.Xna.Framework;
using Snake.Graphics;

namespace Snake
{
    public interface IAnimatabe
    {
        Vector2 Position { get; set; }

        Sprite Sprite { get; set; }

    }
}