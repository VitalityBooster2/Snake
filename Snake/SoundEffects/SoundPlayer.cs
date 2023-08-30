using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.SoundEffects
{
    public static class SoundPlayer
    {
        private static SoundEffectInstance Sound { get; set; }
        public static void PlaySound(SoundEffect sound, float volume)
        {
            Sound = sound.CreateInstance();
            Sound.Volume = volume;
            Sound.Play();
        }

        public static void StopSound() 
        {
        
            Sound.Stop();
        }

    }
}
