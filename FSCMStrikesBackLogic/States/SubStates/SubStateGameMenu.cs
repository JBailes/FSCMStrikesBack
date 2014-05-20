using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;
using FSCMStrikesBackLogic.States;
using FSCMStrikesBackLogic.States.SubStates;

namespace FSCMStrikesBackLogic
{
    class SubStateGameMenu : SubStateMenuAbstract
    {
        public SubStateGameMenu(StateAbstract parent) : base(parent)
        {
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[8];
            menu = new string[colors.Length];

            menu[0] = "Items";
            menu[1] = "Equip";
            menu[2] = "Rune";
            menu[3] = "Status";
            menu[4] = "Formation";
            menu[5] = "Party Order";
            menu[6] = "Return to Title";
            menu[7] = "Exit";

            for (int i = 1; i < colors.Length; i++)
                colors[i] = Color.DarkGray;
            colors[0] = Color.White;
            
            mX = 30;
            mY = 30;
            width = 960;
            height = 690;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }

        public override void Input(int input)
        {
            if (input == Globals.KEY_ACCEPT)
            {
                switch (count)
                {
                    case 0:
                        StateHandler.AddDelay();
                        StateHandler.State = new SubStateItemMenu(this);
                        break;
                    case 1:
                        StateHandler.AddDelay();
                        StateHandler.State = new SubStateCharSelectMenuEquip(this);
                        break;
                    case 2:
                        StateHandler.AddDelay();
                        StateHandler.State = new SubStateCharSelectMenuRune(this);
                        break;
                    case 3:
                        StateHandler.AddDelay();
                        StateHandler.State = new SubStateStatusMenu(this);
                        break;
                    case 4:
                        StateHandler.AddDelay();
                        StateHandler.State = new SubStateFormationMenu(this);
                        break;
                    case 5:
                        StateHandler.AddDelay();
                        StateHandler.State = new SubStateOrderChangeOne(this);
                        break;
                    case 6:
                        StateHandler.AddDelay();                        
                        //StateHandler.State = new StateTitleScreen();//Does not work. You should check it out and see if you know how to fix it.
                        StateHandler.State = new SubStateFeatureNotImplemented(this);
                        break;
                    case 7:
                        StateHandler.AddDelay();
                        StateHandler.State = new SubStateConfirmExit(this, 75, 200);
                        break;
                }
            }
            else if (input == Globals.KEY_MENU)
                input = Globals.KEY_CANCEL;
            else
                base.Input(input);
        }
    }
}