using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class SubStateFeatureNotImplemented: SubStateMenuAbstract
    {

        public SubStateFeatureNotImplemented(StateAbstract parent)
            : base(parent)
        {
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[1];
            menu = new string[1];

            menu[0] = "This feature is currently not working.";
            

            for (int i = 0; i < colors.Length; i++)
                colors[i] = Color.White;

            mX = 30;
            mY = 30;
            width = 960;
            height = 690;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }

        public override void Input(int input)
        {

            if (input == Globals.KEY_CANCEL || input == Globals.KEY_ACCEPT)
            {
                base.Input(input);
                StateHandler.AddDelay();
                StateHandler.State = Parent;
            }
        }

    }
}