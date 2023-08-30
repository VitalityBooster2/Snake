using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Snake
{
    public static class Constants
    {
        private static string fileName = "Config.json";
        public static readonly int WIDTH;
        public static readonly int HEIGHT;


        static Constants()
        {
            JObject config;
            if (!File.Exists(fileName))
                File.WriteAllText(fileName, JsonConvert.SerializeObject(new { Width = 1280, Height = 720 }));


            config = JObject.Parse(File.ReadAllText(fileName));
            WIDTH = config.Value<int>("Width");
            HEIGHT = config.Value<int>("Height");
            HudPos = new Vector2(40, Constants.HEIGHT - 70);

        }

        public static readonly int Speed = 5;
        public static Vector2 HudPos = new Vector2(40, HEIGHT - 70);


    }
}
