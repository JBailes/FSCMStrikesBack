using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FSCMInterfaces;
using FSCMStrikesBackLogic;
using FSCMStrikesBackLogic.States;

namespace FSCMStrikesBackLogic
{
    class SubStateTitleScreenMenu : SubStateMenuAbstract
    {
        public SubStateTitleScreenMenu(StateAbstract parent) : base(parent)
        {
            StateHandler.SetDelay(0);
            messageBoxes = new MessageBox[1];
            colors = new Color[4];
            menu = new string[4];

            menu[0] = "New Game";
            menu[1] = "Continue";
            menu[2] = "Options";
            menu[3] = "Credits";

            colors[0] = Color.White;
            colors[1] = Color.DarkGray;
            colors[2] = Color.DarkGray;
            colors[3] = Color.DarkGray;

            mX = 400;
            mY = 550;
            width = 200;
            height = 120;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true);
        }

        public override void Input(int input)
        {
 
            if (input == Globals.KEY_ACCEPT)
            {
                if (count == 0)
                {
                    MapFactory.mapLoad("test");
                    StateInGame.locX = 4;
                    StateInGame.locY = 4;
                    StateInGame.change = true;
                    StateHandler.State = new StateInGame();
                }
                else if (count == 1)
                    StateHandler.State = new SubStateFeatureNotImplemented(this);
                else if (count == 2)
                    StateHandler.State = new SubStateOptionsMenu(this);
                else if (count == 3)
                    StateHandler.State = new StateCredits();
            }
            else if (input == Globals.KEY_CANCEL)//used to prevent the user from exiting the main menu
            {
                StateHandler.AddDelay();
                MediaHandler.playSFX(FSCMStrikesBackLogic.Properties.Resources.menuBack, "menuBack");
            }
            else
                base.Input(input);
        }
    }
}