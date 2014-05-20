using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSCMInterfaces;

namespace Engine
{
    public class SFXObserver : SoundObserverInterface
    {
        string name;
        byte[] song;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public byte[] Song
        {
            get { return song; }
            set { song = value; }
        }

        public void Play()
        {
            SFX temp = new SFX(Song, Name);
        }

        public void Pause()
        {
            // Unimplemented for this.
        }

        public void Unpause()
        {
            // Unimplemented for SFX
        }
    }
}
