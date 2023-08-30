using Microsoft.Xna.Framework.Input;
using Snake.Sneak;

namespace Snake.Controllers
{
    public class Controller
    {
        private Serpent snake;    



        public Controller(Serpent snake)
        {
            this.snake = snake;


        }

        public void HandleKeyboard()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && snake.Head.Direction != Directions.Down && snake.Head.Direction != Directions.Up && Keyboard.GetState().GetPressedKeys().Length == 1)
            {
                if (!snake.turning)
                {
                    snake.turning = true;
                    snake.beforeTurnPos = snake.Head.Position;
                    DirectionControl.list.Add(new PointDirection(snake.Head.Position, Directions.Up));
                    snake.Head.Direction = Directions.Up;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && snake.Head.Direction != Directions.Up && snake.Head.Direction != Directions.Down && Keyboard.GetState().GetPressedKeys().Length == 1)
            {

                if (!snake.turning)
                {
                    snake.turning = true;
                    snake.beforeTurnPos = snake.Head.Position;
                    DirectionControl.list.Add(new PointDirection(snake.Head.Position, Directions.Down));
                    snake.Head.Direction = Directions.Down;
                }

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && snake.Head.Direction != Directions.Right && snake.Head.Direction != Directions.Left && Keyboard.GetState().GetPressedKeys().Length == 1)
            {
                if (!snake.turning)
                {
                    snake.turning = true;
                    snake.beforeTurnPos = snake.Head.Position;
                    DirectionControl.list.Add(new PointDirection(snake.Head.Position, Directions.Left));
                    snake.Head.Direction = Directions.Left;
                }

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && snake.Head.Direction != Directions.Left && snake.Head.Direction != Directions.Right && Keyboard.GetState().GetPressedKeys().Length == 1)
            {
                if (!snake.turning)
                {
                    snake.turning = true;
                    snake.beforeTurnPos = snake.Head.Position;
                    DirectionControl.list.Add(new PointDirection(snake.Head.Position, Directions.Right));
                    snake.Head.Direction = Directions.Right;
                }

            }
        }
    }
}
