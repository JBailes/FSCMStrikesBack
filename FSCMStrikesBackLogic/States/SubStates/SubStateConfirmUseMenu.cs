using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic.States.SubStates
{
    class SubStateConfirmUseMenu : SubStateMenuAbstract
    {
        int itemSlot;
        int person;

        public SubStateConfirmUseMenu(SubStateAbstract theparent, int theSlot, int thePerson)
            : base(theparent)
        {
            itemSlot = theSlot;
            person = thePerson;

            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[2];
            menu = new string[2];

            menu[0] = "Yes";
            menu[1] = "No";

            colors[0] = Color.White;
            colors[1] = Color.DarkGray;

            mX = 240;
            mY = 75;
            width = 27;
            height = 50;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }//end EVC

        public override void Input(int input)
        {
            base.Input(input);
            StateHandler.AddDelay();

            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                if(count == 0)
                {
                    ItemHandler.itemList[itemSlot].use(StateHandler.GetPC(person));
                    ItemHandler.itemList.RemoveAt(itemSlot);
                }
            }
            else if (input == Globals.KEY_CANCEL)
            {
                StateHandler.AddDelay();
                StateHandler.State = Parent.Parent;
            }
            
        }//end input

        public override void ParentInput(int input)
        {
            if (input == Globals.MESSAGE_CONFIRMED)
            {
                parent.Parent = new SubStateItemMenu(parent.Parent.Parent);
                StateHandler.State = Parent.Parent;
            }
        }
    }
}
