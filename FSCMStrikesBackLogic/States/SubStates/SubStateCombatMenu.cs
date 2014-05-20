using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FSCMInterfaces;
using FSCMStrikesBackLogic.States;

namespace FSCMStrikesBackLogic
{
    internal class SubStateCombatMenu : SubStateMenuAbstract
    {
        public SubStateCombatMenu(StateAbstract parent) : base(parent)
        {
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[4];
            menu = new string[4];

            menu[0] = "Attack";
            menu[1] = "Magic";
            menu[2] = "Items";
            menu[3] = "Defend";

            colors[0] = Color.White;
            colors[1] = Color.DarkGray;
            colors[2] = Color.DarkGray;
            colors[3] = Color.DarkGray;

            mX = 450;
            mY = 600;
            width = 185;
            height = 125;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true);
        }

        public override void Input(int input)
        {
            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                if (count == 0)
                {
                    parent.ParentInput(Globals.MENU_ATTACK);
                }
                else if (count == 1)
                {
                    parent.ParentInput(Globals.MENU_MAGIC);
                }
                else if (count == 2)
                {
                    StateHandler.State = new SubStateItemMenuCombat(this);
                    parent.ParentInput(Globals.MENU_ITEM);
                }
                else if (count == 3)
                {
                    parent.ParentInput(Globals.MENU_DEFEND);
                }
            }
            if (input == Globals.KEY_UP || input == Globals.KEY_DOWN)
            {
                base.Input(input);
            }
        }

        public override void ParentInput(int input)
        {
            Parent.ParentInput(input);

            if (input == Globals.MESSAGE_CONFIRMED)
            {
                StateHandler.State = this;
            }
        }
    }
}
