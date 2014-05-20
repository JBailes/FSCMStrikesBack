using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic.States.SubStates
{
    class SubStateConfirmUseMenuCombat: SubStateMenuAbstract
    {
        int itemSlot;
        int person;

        public SubStateConfirmUseMenuCombat(SubStateAbstract theparent, int theSlot, int thePerson)
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
            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                base.Input(input);
                if (count == 0)
                {
                    Character user = (Character) StateHandler.CameraTarget;
                    if (person < 3)//targetting player
                        ItemHandler.itemList[itemSlot].use(user, StateHandler.GetPC(person));
                    else//targetting monster
                    {
                        person -= 3;

                        for (int i = 0; i < person + 1 && i < StateCombat.MonsterList.Length; i++)
                            if (StateCombat.MonsterList[i].Health < 1)
                                person++;

                        ItemHandler.itemList[itemSlot].use(user, StateCombat.MonsterList[person]);
                    }
                    ItemHandler.itemList.RemoveAt(itemSlot);
                }
                else if (count == 1)
                {
                    StateHandler.AddDelay();
                    StateHandler.State = Parent;
                }

            }
            else if (input == Globals.KEY_CANCEL)
            {
                StateHandler.AddDelay();
                StateHandler.State = Parent;
            }
            else
                base.Input(input);
        }//end input
    }
}
