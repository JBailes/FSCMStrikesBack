using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic
{
    class StateTitleScreen : StateAbstract
    {
        int count = 0;

        public override void Update()
        {
            if (fresh)
            {
                fresh = false;

                MediaHandler.Background = "FSCMTitleScreen.jpg";
                MediaHandler.playBGM(FSCMStrikesBackLogic.Properties.Resources.welcome, "Welcome");

                StateHandler.State = new SubStateTitleScreenMenu(this);
            }
        }

        public override void Input(int input)
        {

            StateHandler.State = new StateInGame();
        }
    }
}
