
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Snake.Graphics;
using System;

namespace Snake.Sneak
{
    public class Head : Entity, IMovable
    {

        public event IMovable.MoveHandler MoveEvent;

        public Directions Direction { get; set; }

        public int Velocity { get; set; }

        public Head(Vector2 position, Sprite sprite) : base(position, sprite)
        {
            MoveEvent += Move;
            Velocity = Constants.Speed;
            Direction = Directions.Right;
            
        }

        public void PerformMove(GameTime gameTime) => MoveEvent?.Invoke(gameTime);


        public override void Update(GameTime gameTime)
        {

            if (!Collided) Velocity = Velocity;
            if (Collided) Velocity = 0;

            base.Update(gameTime);
        }

        private void Move(GameTime gameTime)
        {
            switch (Direction)
            {
                case Directions.Left:
                    Position = new Vector2(Position.X - Velocity, Position.Y);
                    Sprite.Rotation = (float)Math.PI;
                    break;
                case Directions.Right:
                    Position = new Vector2(Position.X + Velocity, Position.Y);
                    Sprite.Rotation = 0;
                    break;
                case Directions.Up:
                    Position = new Vector2(Position.X, Position.Y - Velocity);
                    Sprite.Rotation = -(float)Math.PI / 2;
                    break;
                case Directions.Down:
                    Position = new Vector2(Position.X, Position.Y + Velocity);
                    Sprite.Rotation = (float)Math.PI / 2;
                    break;
            }
        }
    }
}
