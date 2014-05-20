using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;
using FSCMStrikesBackLogic.States.SubStates;

namespace FSCMStrikesBackLogic.States
{
    class SubStateDifficultySelect : SubStateMenuAbstract
    {
        public SubStateDifficultySelect(StateAbstract theparent)
            : base(theparent)
        {
            int i;
            parent = theparent;
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];

            colors = new Color[6];
            menu = new string[6];

            menu[0] = "Child";
            menu[1] = "Youth";
            menu[2] = "Standard";
            menu[3] = "Challenging";
            menu[4] = "Expert";
            menu[5] = "Insane";

            for (i = 1; i < colors.Length; i++)
                colors[i] = Color.DarkGray;
            colors[0] = Color.White;

            mX = 100;
            mY = 45;
            width = 900;
            height = 630;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true, true);
        }

        public override void Input(int input)
        {
            base.Input(input);
            StateHandler.AddDelay();
            if (input == Globals.KEY_CANCEL)
            {
                StateHandler.AddDelay();
                StateHandler.State = parent;
            }
            else if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                switch (count)
                {
                    case 0:
                        StateHandler.Difficulty = Globals.DIFFICULTY_VERY_EASY;
                        break;
                    case 1:
                        StateHandler.Difficulty = Globals.DIFFICULTY_EASY;
                        break;
                    case 2:
                        StateHandler.Difficulty = Globals.DIFFICULTY_NORMAL;
                        break;
                    case 3:
                        StateHandler.Difficulty = Globals.DIFFICULTY_HARD;
                        break;
                    case 4:
                        StateHandler.Difficulty = Globals.DIFFICULTY_VERY_HARD;
                        break;
                    case 5:
                        StateHandler.Difficulty = Globals.DIFFICULTY_INSANE;
                        break;
                }
                StateHandler.State = parent;
            }
        }
    }

}
