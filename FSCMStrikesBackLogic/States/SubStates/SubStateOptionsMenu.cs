using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;
using FSCMStrikesBackLogic.States.SubStates;

namespace FSCMStrikesBackLogic.States
{
    class SubStateOptionsMenu : SubStateMenuAbstract
    {
        public SubStateOptionsMenu(StateAbstract theparent)
            : base(theparent)
        {
            int i;
            parent = theparent;
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];

            colors = new Color[1];
            menu = new string[colors.Length];

            colors[0] = Color.White;
            for (i = 1; i < colors.Length; i++)
                colors[i] = Color.DarkGray;
            
            menu[0] = "Difficulty";

            for (i = 1; i < menu.Length; i++)
                menu[i] = "Option " + i;

            mX = 100;
            mY = 45;
            width = 900;
            height = 630;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true, true);
        }

        public override void Input(int input)
        {
            base.Input(input);
            if (input == Globals.KEY_CANCEL)
            {
                StateHandler.AddDelay();
                StateHandler.State = parent;
            }
            else if (input == Globals.KEY_ACCEPT)
            {
                switch (count)
                {
                    case 0:
                        StateHandler.State = new SubStateDifficultySelect(this);
                        break;
                    default:
                        StateHandler.AddDelay();
                        StateHandler.State = new SubStateFeatureNotImplemented(this);
                        break;
                }
            }
        }
    }

}
