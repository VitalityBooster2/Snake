using Snake.Sneak;
using System.Collections.Generic;


namespace Snake.Controllers
{
    public class ColisionManager
    {
        Serpent player;

        public ColisionManager(Serpent snake)
        {
            player = snake;
        }

        public void Colision(ref List<ICollidable> collidables)
        {

            for (int i = 0; i < collidables.Count; i++)
            {
                if (!collidables[i].GetType().Equals(player.Head.GetType()))
                {
                    if (player.Head.Hitbox.Intersects(collidables[i].Hitbox) && collidables[i] is Segment)
                    {
                        player.Head.Collided = true;
                        foreach (var item in collidables) item.Collided = true;

                    }
                }

                if (player.Head.Hitbox.Intersects(collidables[i].Hitbox) && collidables[i] is Wall)
                {
                    player.Head.Collided = true;
                }

                if (player.Head.Hitbox.Intersects(collidables[i].Hitbox) && collidables[i] is Food)
                {
                    collidables[i].Collided = true;
                    player.Addsegment();
                    collidables.Add(player.body[player.body.Count - 1]);
                }


            }
        }
    }
}

