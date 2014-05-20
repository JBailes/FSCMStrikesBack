using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMInterfaces
{
    public interface SoundObserverInterface
    {
        string Name{ get; set; }
        byte[] Song { get; set; }
        void Play();
        void Pause();
        void Unpause();
    }
}
