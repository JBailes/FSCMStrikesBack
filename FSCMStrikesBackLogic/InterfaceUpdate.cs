using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace FSCMStrikesBackLogic
{
    public static class InterfaceUpdate
    {
        static SoundObserverInterface bgm;
        static SoundObserverInterface sfx;

        public static void pulse()
        {
            StateHandler.Update();
        }

        public static void registerBGM(SoundObserverInterface observer)
        {
            bgm = observer;
        }

        public static void registerSFX(SoundObserverInterface observer)
        {
            sfx = observer;
        }

        public static void playBGM(byte[] song, string name)
        {
            bgm.Song = song;
            bgm.Name = name;
            bgm.Play();
        }

        public static void playSFX(byte[] song, string name)
        {
            sfx.Song = song;
            sfx.Name = name;
            sfx.Play();
        }

        public static int getTick()
        {
            return StateHandler.Count;
        }

        public static string getBackground()
        {
            return StateHandler.checkUpdateBackground();
        }
    }
}
