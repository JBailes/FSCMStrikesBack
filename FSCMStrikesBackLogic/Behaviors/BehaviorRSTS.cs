using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class BehaviorRSTS
    {
        public static Character acquireTarget()
        {
            int choice = Globals.Random(0, 100);

            choice /= 33;

            while (PCBuilder.getPC(choice).Health < 1)
            {
                choice++;
                if (choice > 2)
                    choice = 0;
            }

            return PCBuilder.getPC(choice);
        }
    }
}
