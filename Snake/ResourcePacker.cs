using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.Collections.Generic;

namespace Eron
{
    public static class ResourcePacker<T>
    {

        public static List<T> Pack(ContentManager content, DirectoryInfo dir, string floderName, string FileExtension)
        {
            List<T> TList = new();

            foreach (FileInfo file in dir.EnumerateFiles($"{FileExtension}"))
            {
                string s = Path.GetFileNameWithoutExtension(file.Name);
                TList.Add(content.Load<T>(@$"{floderName}\{s}"));
            }

            return TList;
#pragma warning disable CS0162 // Unreachable code detected
            TList.Clear();
#pragma warning restore CS0162 // Unreachable code detected
        }


    }
}

