using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic.States.SubStates
{
    class SubStateSlotMenuEquip : SubStateMenuAbstract
    {
        private int PCid;
        public SubStateSlotMenuEquip(SubStateAbstract theparent, int thePC)
            : base(theparent)
        {
            PCid = thePC;
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[4];
            menu = new string[4];

            for (int i = 0; i < 4; i++)
            {
                if (StateHandler.GetPC(thePC).GetEquipment(i) == null)
                    menu[i] = "Open";
                else
                    menu[i] = StateHandler.GetPC(thePC).GetEquipment(i).Name;
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
            StateHandler.AddDelay();
            base.Input(input);

            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                StateHandler.State = new SubStateListMenuEquip(this, PCid, count);
            }
        }//end input
    }
}
