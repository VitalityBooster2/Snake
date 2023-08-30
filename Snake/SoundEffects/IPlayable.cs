using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.SoundEffects
{
    public interface IPlayable
    {
        List<SoundEffect> soundEffects { get; set; }

        SoundEffect currentSE { get; set; }
    }
}
