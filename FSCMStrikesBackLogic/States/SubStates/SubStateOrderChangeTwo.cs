using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic
{
    class SubStateOrderChangeTwo : SubStateMenuAbstract
    {
        private int first;
        public SubStateOrderChangeTwo(SubStateAbstract theparent, int selected)
            : base(theparent)
        {
            first = selected;
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

            mX = 90;
            mY = 90;
            width = 900;
            height = 630;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }//end EVC

        public override void Input(int input)
        {
            base.Input(input);
            StateHandler.AddDelay();
            if (input == Globals.KEY_ACCEPT)
            {
                string temp = StateHandler.GetPC(first).Name;
                StateHandler.SetPC(StateHandler.GetPC(count).Name, first);
                StateHandler.SetPC(temp, count);
                parent = new SubStateOrderChangeOne((SubStateAbstract)parent.Parent);
                StateHandler.State = parent;
            }
            else if (input == Globals.KEY_CANCEL)
                StateHandler.State = parent;
        }//end input
    }
}
