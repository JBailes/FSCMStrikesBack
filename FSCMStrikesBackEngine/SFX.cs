using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrrKlang;

namespace Engine
{
    class SFX
    {
        public SFX(string effect)
        {
            if (effect == null)
                return;

            ISoundEngine sfx = new ISoundEngine();

            sfx.Play2D(effect);
        }

        public SFX(byte[] song, string name)
        {
            ISoundEngine sfx = new ISoundEngine();
            ISoundSource source = sfx.AddSoundSourceFromMemory(song, name);

            sfx.Play2D(source, false, false, true);
        }
    }
}
