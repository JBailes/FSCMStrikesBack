using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    public class StateEngineLogo : StateAbstract
    {
        int count;

        public override void Update()
        {
            count++;
            if (fresh)
            {
                fresh = false;
                MediaHandler.Background = "SimpleEngine2Logo.jpg";
            }

            if (count > 220)
                StateHandler.State = new StateTeamLogo();
        }
    }
}
