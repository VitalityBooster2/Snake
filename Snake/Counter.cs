using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake
{
    public class Counter
    {
        public int count = 1;

        private SpriteFont font;


        public Counter(SpriteFont spriteFont)
        {
            font = spriteFont;   
        }

        public void DrawCount(SpriteBatch sb)
        {
            sb.DrawString(font, $"Score: {count}", Constants.HudPos, Color.White);
        }
    }
}
