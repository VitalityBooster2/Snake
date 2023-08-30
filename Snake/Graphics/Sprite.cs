using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.Graphics
{
    public class Sprite
    {
        public Point Size { get; set; }

        private Vector2 origin;

        public Vector2 Origin
        {

            get { return origin; }
            set
            {
                origin = value.X >= 0 & value.Y >= 0 ? value : throw new Exception("incorrect origin");
            }

        }

        public int FrameCount { get; private set; }

        public float Rotation { get; set; }

        public Vector2 Position { get; set; }

        public Texture2D texture { get; set; }

        public SpriteEffects spriteEffects { get; set; }

        public Sprite(Vector2 position, Texture2D texture)
        {
            spriteEffects = SpriteEffects.None;
            Size = texture.Bounds.Size;
            Position = position;
            this.texture = texture;
            FrameCount = texture.Width / Size.X;
            origin = new Vector2(this.texture.Width / 2, this.texture.Height / 2);
        }

        private int FindFrameCount()
        {
            try
            {
                string text = "";
                bool flag = false;
                for (int i = 0; i < texture.Name.Length && texture.Name[i] != '_'; i++)
                {
                    if (flag)
                    {
                        text = text += texture.Name[i];
                    }

                    if (texture.Name[i] == '/')
                    {
                        flag = true;
                    }
                }

                return int.Parse(text);
            }
            catch (FormatException)
            {
                throw new Exception("Rename pic according to this template  {Framecount_FileName}");
            }
        }
    }
}