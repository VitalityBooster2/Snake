using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Snake.Graphics;
using Snake.SoundEffects;
using System;
using System.Collections.Generic;

namespace Snake.Sneak
{

    public class Serpent : IUpdateable, IPlayable
    {
        public bool turning { get; set; }
        public Vector2 beforeTurnPos { get; set; }
        public List<SoundEffect> soundEffects { get; set; }

        public List<Segment> body { get; private set; }

        public SoundEffect currentSE { get; set; }

        public int Lenght { get; private set; }

        public Head Head { get; private set; }

        public bool AddSegment { get; set; }



        public Serpent()
        {

        }

        public Serpent(Head head, Texture2D bodySprite,  List<SoundEffect> SE)
        {

            Head = head;
            body = new List<Segment>();
            soundEffects = SE;

            currentSE = soundEffects.Find(x => x.Name == @"Sounds\SnakeSound\increase");

            body.Add(new Segment(Head.Position, Head.Direction, new Sprite(Head.Sprite.Position, bodySprite)));




        }

        public void Addsegment()
        {
            currentSE.Play();
            body.Add(new Segment(body[body.Count - 1].Position, body[body.Count - 1].Direction, new Sprite(Head.Sprite.Position, body[body.Count - 1].Sprite.texture)));
            Lenght++;
            AddSegment = true;

        }


        public void Update(GameTime gameTime)
        {
            Head.PerformMove(gameTime);
            Head.Update(gameTime);
            if (Head.Position.X >= beforeTurnPos.X + Head.Sprite.Size.X ||
                Head.Position.Y >= beforeTurnPos.Y + Head.Sprite.Size.Y ||
                Head.Position.X <= beforeTurnPos.X - Head.Sprite.Size.X ||
                Head.Position.Y <= beforeTurnPos.Y - Head.Sprite.Size.Y
                ) turning = false;

            for (int i = 0; i < body.Count; i++)
            {
                body[i].PerformMove(gameTime);
                body[i].Update(gameTime);
            }
        }
    }
}
