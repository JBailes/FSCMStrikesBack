using FSCMStrikesBackLogic.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FSCMInterfaces;
using FSCMStrikesBackLogic.States.SubStates;

namespace FSCMStrikesBackLogic
{
    class SubStateListMenuEquip : SubStateMenuAbstract
    {
        private int PCid;
        private int slot;
        public SubStateListMenuEquip(StateAbstract parent, int thePC, int itemSlot)
            : base(parent)
        {
            PCid = thePC;
            slot = itemSlot;
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            int adjustedLen = ItemHandler.equipList.Count + 1;
            colors = new Color[adjustedLen];
            menu = new string[adjustedLen];

            int i = 0;
            foreach (ItemAbstract item in ItemHandler.equipList)
            {
                colors[i] = Color.DarkGray;
                menu[i] = item.Name;
                i++;
            }

            menu[i] = "Unequip";
            colors[i] = Color.DarkGray;

            colors[0] = Color.White;

            mX = 240;
            mY = 75;
            width = 660;
            height = 390;

            int tempVal = (int)(Globals.hmod * height);

            tempVal /= Globals.FONT_HEIGHT;

            tempVal -= 1;

            if (tempVal > adjustedLen)
                tempVal = adjustedLen;

            string[] tempMenu = new string[tempVal];

            for (i = 0; i < tempVal; i++)
                tempMenu[i] = menu[i];

            messageBoxes[0] = new MessageBox(mX, mY, width, height, tempMenu, colors, true, true, true);

            StateHandler.State = new SubStateStatChange(this, PCid, slot, 0);//DOES NOT WORK
        }

        private bool direction(int input)
        {
            if (input == Globals.KEY_DOWN
            || input == Globals.KEY_UP)
                return true;
            return false;
        }
        
        private bool equipSlotTaken(int passedFlag)
        {
            foreach (EquipmentAbstract e in StateHandler.GetPC(PCid).equipped)
            {
                if (e != null)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int flag = 1 << i;
                        if (Globals.IS_SET(e.Wearflags, flag))
                            if (Globals.IS_SET(passedFlag, flag))
                                return true;
                    }
                }
            }
            return false;
        }

        public override void Input(int input)
        {
            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                if (count < ItemHandler.equipList.Count && equipSlotTaken(ItemHandler.equipList[count].Wearflags))
                {
                    MediaHandler.playSFX(FSCMStrikesBackLogic.Properties.Resources.menuBack, "error");
                    return;
                }
                StateHandler.State = new SubStateConfirmEquipMenu(this, 310, 90, PCid, slot, count, Globals.ITEM_TYPE_EQUIP);
            }
            else
            {
                base.Input(input);
                if (direction(input))
                {
                    StateHandler.State = new SubStateStatChange(this, PCid, slot, count);
                }
            }
        }//end input
    }
}
