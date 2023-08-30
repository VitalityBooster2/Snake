
using Microsoft.Xna.Framework;
using Snake.Graphics;
using System;

namespace Snake.Sneak
{
    public class Segment : Entity, IMovable
    {
        public int Velocity { get; set; }

        public Directions Direction { get; set; }

        public event IMovable.MoveHandler MoveEvent;

        public Segment(Vector2 HeadPos, Directions direction, Sprite sprite) : base(HeadPos, sprite)
        {
            Direction = direction;


            switch (Direction)
            {
                case Directions.Left:
                    Position = new Vector2(HeadPos.X + Sprite.Size.X, HeadPos.Y);
                    break;
                case Directions.Right:
                    Position = new Vector2(HeadPos.X - Sprite.Size.X, HeadPos.Y);
                    break;
                case Directions.Up:
                    Position = new Vector2(HeadPos.X, HeadPos.Y + Sprite.Size.Y);
                    break;
                case Directions.Down:
                    Position = new Vector2(HeadPos.X, HeadPos.Y - Sprite.Size.Y);
                    break;
            }

            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, Sprite.Size.X, Sprite.Size.Y);
       


            Velocity = Constants.Speed;
            MoveEvent += Move;

        }

        public override string ToString() => $"Direction:{Direction} Pos:{Position}  Hitbox:{Hitbox}";


        public void PerformMove(GameTime gameTime)
        {
            MoveEvent?.Invoke(gameTime);
        }

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