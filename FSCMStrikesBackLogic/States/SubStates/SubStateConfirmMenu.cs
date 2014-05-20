using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic.States.SubStates
{
    class SubStateConfirmMenu : SubStateMenuAbstract
    {

        public SubStateConfirmMenu(SubStateAbstract theparent, int xCoord, int yCoord)
            : base(theparent)
        {
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[2];
            menu = new string[2];

            menu[0] = "Yes";
            menu[1] = "No";

            colors[0] = Color.White;
            colors[1] = Color.DarkGray;

            mX = xCoord;
            mY = yCoord;
            width = 27;
            height = 50;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }//end EVC

        public override void Input(int input)
        {
            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                if (count == 0)
                {
                    //yes
                }
                else
                {
                    //no
                }
                StateHandler.State = Parent.Parent;
            }
            else if (input == Globals.KEY_CANCEL)
            {
                StateHandler.AddDelay();
                StateHandler.State = Parent;
            }
            else
                base.Input(input);
        }//end input

    }
}
