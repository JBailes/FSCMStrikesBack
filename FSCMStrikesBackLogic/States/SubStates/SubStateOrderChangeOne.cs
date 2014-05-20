using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;
using FSCMStrikesBackLogic.States.SubStates;

namespace FSCMStrikesBackLogic
{
    class SubStateOrderChangeOne : SubStateMenuAbstract
    {
        public SubStateOrderChangeOne(SubStateAbstract theparent)
            : base(theparent)
        {
            int i = 0;
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[3];
            menu = new string[colors.Length];

            for (i = 0; i < menu.Length; i++)
                menu[i] = StateHandler.GetPC(i).Name;

            for (i = 1; i < colors.Length; i++)
                colors[i] = Color.DarkGray;
            colors[0] = Color.White;

            mX = 60;
            mY = 60;
            width = 930;
            height = 660;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }//end EVC

        public override void Input(int input)
        {
            base.Input(input);
            StateHandler.AddDelay();
            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.State = new SubStateOrderChangeTwo(this, count);
            }
            else if (input == Globals.KEY_CANCEL)
                StateHandler.State = parent;
        }//end input
    }
}
