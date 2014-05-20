using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic.States.SubStates
{
    class SubStateSlotMenuRune : SubStateMenuAbstract
    {
        int PCid;

        public SubStateSlotMenuRune(SubStateAbstract theparent, int thePC)
            : base(theparent)
        {
            PCid = thePC;
            absolute = false;
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[2];
            menu = new string[2];

            for (int i = 0; i < 2; i++)
            {
                if (StateHandler.GetPC(thePC).GetRune(i) == null)
                    menu[i] = "Open";
                else
                    menu[i] = StateHandler.GetPC(thePC).GetRune(i).Name;
                colors[i] = Color.DarkGray;
            }

            colors[0] = Color.White;

            mX = 170;
            mY = 60;
            width = 760;
            height = 490;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }//end EVC

        public override void Input(int input)
        {
            
            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                StateHandler.State = new SubStateListMenuRune(this, PCid, count);
            }

            StateHandler.AddDelay();
            base.Input(input);
        }//end input
    }
}
