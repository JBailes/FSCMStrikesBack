using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    public static class MediaHandler
    {
        private static string background = "SimpleEngine2Logo";
        private static SoundObserverInterface bgm;
        private static SoundObserverInterface sfx;
        
        public static void registerBGM(SoundObserverInterface observer)
        {
            bgm = observer;
        }

        public static void playBGM(byte[] song, string name)
        {
            bgm.Song = song;
            bgm.Name = name;
            bgm.Play();
        }
        
        public static void Pause()
        {
            bgm.Pause();
        }

        public static void Unpause()
        {
            bgm.Unpause();
        }

        public static void registerSFX(SoundObserverInterface observer)
        {
            sfx = observer;
        }

        public static void playSFX(byte[] song, string name)
        {
            sfx.Song = song;
            sfx.Name = name;
            sfx.Play();
        }

        public static string checkUpdateBackground()
        {
            return background;
        }

        internal static string Background
        {
            get { return background; }
            set { background = value; }
        }

        public static string getBackground()
        {
            return MediaHandler.checkUpdateBackground();
        }

    }//end MediaHandler class

}//end namespace