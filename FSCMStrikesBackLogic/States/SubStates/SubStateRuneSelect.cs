using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic.States
{
    class SubStateRuneSelect : SubStateMenuAbstract
    {
        PC curr;
        public SubStateRuneSelect(StateAbstract theparent, Character thePC)
            : base(theparent)
        {
            curr = (PC) thePC;

            parent = theparent;
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];

            int i, size = calcSize();
            colors = new Color[size];
            menu = new string[size];

            for (i = 0; i < size; i++)
                menu[i] = curr.runes[i].Name;

            for (; i < size; i++)
                menu[i] = "";

            if(colors.Length > 0)
                colors[0] = Color.White;

            for (i = 1; i < colors.Length; i++)
                colors[i] = Color.DarkGray;
            
            mX = 100;
            mY = 45;
            width = 900;
            height = 630;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true, true);
        }

        private int calcSize()
        {
            int count = 0;
            for (int i = 0; i < curr.runes.Length; i++)
                if (curr.runes[i] != null)
                    count++;
            return count;
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
                StateHandler.AddDelay();

                if (curr.runes[count] != null)
                    StateHandler.State = new SubStateSpellSelect(this, curr.runes[count].getSpells(), curr);
                else
                    StateHandler.State = parent;
            }
        }
    }

}
