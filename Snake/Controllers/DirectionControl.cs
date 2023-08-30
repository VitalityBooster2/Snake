using Microsoft.Xna.Framework;
using Snake.Sneak;
using System.Collections.Generic;

namespace Snake.Controllers
{
    public struct PointDirection
    {
        public Vector2 Position;
        public Directions direction;

        public override string ToString() => $"{Position}  {direction}";




        public PointDirection(Vector2 position, Directions direction)
        {
            this.direction = direction;
            Position = position;
        }
    }

    public static class DirectionControl
    {
        public static List<PointDirection> list = new List<PointDirection>();

        public static void Control(List<Segment> segments)
        {

            for (int i = 0; i < segments.Count; i++)
            {

                for (int j = 0; j < list.Count; j++)
                {
                    if (segments[i].Position == list[j].Position) segments[i].Direction = list[j].direction;

                    if (segments[0].Position == list[j].Position) segments[0].Direction = list[j].direction;
                    if (segments[segments.Count - 1].Position == list[j].Position)
                    {
                        segments[segments.Count - 1].Direction = list[j].direction;
                        list.Remove(list[j]);
                    }
                }
            }
        }
    }
}
