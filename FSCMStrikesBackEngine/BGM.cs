using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrrKlang;
using FSCMInterfaces;

namespace Engine
{
    static class BGM
    {
        static ISoundEngine bgm = new ISoundEngine();
        static ISoundSource source;

        static public void stop()
        {
            bgm.StopAllSounds();
            bgm.Dispose();
            bgm = new ISoundEngine();
        }

        static public void play(string mp3)
        {
            if (mp3 == null)
                return;

            stop();
            bgm.Play2D(mp3, true);
        }

        static public void play(byte[] song, string name, bool repeat)
        {
            stop();
            source = bgm.AddSoundSourceFromMemory(song, name);

            bgm.Play2D(source, repeat, false, true);
        }

        static public void play(SoundObserverInterface sound)
        {
            play(sound.Song, sound.Name, true);
        }

        static public void pause()
        {
            bgm.SetAllSoundsPaused(true);
        }

        static public void unpause()
        {
            bgm.SetAllSoundsPaused(false);
        }
    }
}
