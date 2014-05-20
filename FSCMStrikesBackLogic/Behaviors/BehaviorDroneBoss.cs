using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class BehaviorDroneBoss : BehaviorAbstract
    {
        static bool charged = false;
        public override void action(Monster parent)
        {
            if (!charged)
            {
                MessageBoxInterface[] messageBoxes = new MessageBoxInterface[1];
                Color[] colors = new Color[1];
                colors[0] = Color.White;

                int mX = 400;
                int mY = 100;
                int height = 100;
                int width = 345;

                string[] attackMessage = new string[1];
                attackMessage[0] = "IMA CHARGIN MAH LASERS!";

                charged = true;

                SubStateConfirmMessage temp = new SubStateConfirmMessage(attackMessage, height, width, mX, mY, StateHandler.State);
                StateHandler.State = temp;
            }
            else if (charged)
            {
                charged = false;
                MessageBoxInterface[] messageBoxes = new MessageBoxInterface[1];
                Color[] colors = new Color[1];
                colors[0] = Color.White;

                int mX = 400;
                int mY = 100;
                int height = 100;
                int width = 345;

                string[] attackMessage = new string[1];
                attackMessage[0] = "IMA FIRIN MAH LASERS!";

                SubStateConfirmMessage temp = new SubStateConfirmMessage(attackMessage, height, width, mX, mY, StateHandler.State);
                StateHandler.State = temp;

                int choice = Globals.Random(0, 3);

                int bonus = 1000;

                if (PCBuilder.getPC(choice).IsDefending())
                    bonus = 0;

                parent.Attack(BehaviorRSTS.acquireTarget(), Globals.ELEMENT_FIRE, "LASERS", bonus);
            }
        }
    }
}
