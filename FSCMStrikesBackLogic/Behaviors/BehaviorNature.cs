using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic
{
    class BehaviorNature : BehaviorAbstract
    {
        public override void action(Monster parent)
        {
            MessageBoxInterface[] messageBoxes = new MessageBoxInterface[1];
            Color[] colors = new Color[1];
            colors[0] = Color.White;

            int mX = 400;
            int mY = 100;
            int height = 100;
            int width = 345;

            string[] attackMessage = new string[1];
            attackMessage[0] = "Nature attack 2.0?";

            SubStateConfirmMessage temp = new SubStateConfirmMessage(attackMessage, height, width, mX, mY, StateHandler.State);
            StateHandler.State = temp;

            parent.Attack(BehaviorRSTS.acquireTarget(), Globals.ELEMENT_NATURE, "nature", 20);
        }
    }
}