using Microsoft.Xna.Framework;

namespace Snake
{
    public interface IMovable
    {
        delegate void MoveHandler(GameTime gameTime);

        void PerformMove(GameTime gameTime);
        Directions Direction { get; set; }

        Vector2 Position { get; set; }
        
        event MoveHandler MoveEvent;

        int Velocity { get; set; }
    }
}