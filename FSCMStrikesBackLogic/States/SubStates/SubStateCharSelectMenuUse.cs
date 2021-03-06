﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic.States.SubStates
{
    class SubStateCharSelectMenuUse : SubStateMenuAbstract
    {
        int itemID;

        public SubStateCharSelectMenuUse(SubStateAbstract theparent, int itemSlot)
            : base(theparent)
        {
            itemID = itemSlot;
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[3];
            menu = new string[3];

            menu[0] = StateHandler.GetPC(0).Name;
            menu[1] = StateHandler.GetPC(1).Name;
            menu[2] = StateHandler.GetPC(2).Name;

            colors[0] = Color.White;
            colors[1] = Color.DarkGray;
            colors[2] = Color.DarkGray;

            mX = 170;
            mY = 60;
            width = 760;
            height = 490;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }//end EVC


        public override void Input(int input)
        {
            StateHandler.AddDelay();
            base.Input(input);
            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                StateHandler.State = new SubStateConfirmUseMenu(this, itemID, count);
            }
            
        }//end input
    }
}
