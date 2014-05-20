using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSCMInterfaces;

namespace Engine
{
    class BGMObserver : SoundObserverInterface
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
            BGM.play(song, name, true);
        }

        public void Pause()
        {
            BGM.pause();
        }

        public void Unpause()
        {
            BGM.unpause();
        }
    }
}
