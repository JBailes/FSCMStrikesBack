using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class StateTeamLogo : StateAbstract
    {
        int count;
        public override void Update()
        {
            count++;
            if (fresh)
            {
                fresh = false;
                MediaHandler.playSFX(FSCMStrikesBackLogic.Properties.Resources.HoneyBadgers, "HoneyBadgers");
                MediaHandler.Background = "teamlogo.jpg";
            }

            if (count > 220)
                StateHandler.State = new StateTitleScreen();
        }
    }
}
