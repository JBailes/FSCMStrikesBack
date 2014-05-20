using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic.States.SubStates
{
    class SubStateCharSelectMenuEquip : SubStateMenuAbstract
    {
        public SubStateCharSelectMenuEquip(SubStateAbstract theparent)
            : base(theparent)
        {
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

            mX = 100;
            mY = 45;
            width = 860;
            height = 590;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }//end EVC

        public override void Input(int input)
        {
            base.Input(input);
            StateHandler.AddDelay();
            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                StateHandler.State = new SubStateSlotMenuEquip(this, count);
            }
        }//end input
    }
}
