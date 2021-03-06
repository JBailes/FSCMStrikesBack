﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic
{
    class BehaviorFlameStorm : BehaviorAbstract
    {
        public override void action(Monster parent)
        {
            MessageBoxInterface[] messageBoxes = new MessageBoxInterface[1];
            Color[] colors = new Color[1];
            colors[0] = Color.Crimson;

            int mX = 400;
            int mY = 100;
            int height = 100;
            int width = 345;

            string[] attackMessage = new string[1];
            attackMessage[0] = "FLAME STORM!";

            SubStateConfirmMessage temp = new SubStateConfirmMessage(attackMessage, height, width, mX, mY, StateHandler.State);
            StateHandler.State = temp;

            parent.Attack(BehaviorRSTS.acquireTarget(), Globals.ELEMENT_FIRE, "flame storm", 50);
        }
    }
}