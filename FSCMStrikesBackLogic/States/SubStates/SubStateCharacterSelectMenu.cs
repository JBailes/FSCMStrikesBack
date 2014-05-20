using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic.States.SubStates
{
    class SubStateCharacterSelectMenu : SubStateMenuAbstract
    {
        public SubStateCharacterSelectMenu(SubStateAbstract theparent, int xCoord, int yCoord)
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

            mX = xCoord;
            mY = yCoord;
            width = 960;
            height = 680;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }//end EVC

        public override void Input(int input)
        {
            base.Input(input);
            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                StateHandler.State = new SubStateConfirmMenu(this, 310, 90);
            }
            else if (input == Globals.KEY_CANCEL)
            {
                StateHandler.AddDelay();
                StateHandler.State = Parent;
            }
            
        }//end input
    }
}
