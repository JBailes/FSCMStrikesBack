using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;
using FSCMStrikesBackLogic.States.SubStates;

namespace FSCMStrikesBackLogic
{
    class SubStateItemMenu : SubStateMenuAbstract
    {
        public SubStateItemMenu(StateAbstract theparent) : base(theparent)
        {
            absolute = false;
            parent = theparent;
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];

            colors = new Color[ItemHandler.itemList.Count];
            menu = new string[ItemHandler.itemList.Count];

            int i = 0;
            foreach(ConsumableAbstract item in ItemHandler.itemList)
            {
                colors[i] = Color.DarkGray;
                menu[i] = item.getName();
                i++;
            }

            if (ItemHandler.itemList.Count > 0)
                colors[0] = Color.White;

            mX = 100;
            mY = 45;
            width = 860;
            height = 590;

            int tempVal = (int)(Globals.hmod * height);

            tempVal /= Globals.FONT_HEIGHT;

            tempVal -= 1;

            if (tempVal > menu.Length)
                tempVal = menu.Length;

            string[] tempMenu = new string[tempVal];

            for (i = 0; i < tempVal; i++)
                tempMenu[i] = menu[i];

            messageBoxes[0] = new MessageBox(mX, mY, width, height, tempMenu, colors, true, true, true);
        }

        public override void Input(int input)
        {
            base.Input(input);
            StateHandler.AddDelay();

            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.State = new SubStateCharSelectMenuUse(this, count);
            }

        }
    }
}
