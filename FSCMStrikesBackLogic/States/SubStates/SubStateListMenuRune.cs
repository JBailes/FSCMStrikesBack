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
    class SubStateListMenuRune: SubStateMenuAbstract
    {
        int PCid;
        int slot;

        public SubStateListMenuRune(StateAbstract parent, int thePC, int theSlot)
            : base(parent)
        {
            PCid = thePC;
            slot = theSlot;
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            int adjustedLen = ItemHandler.runeList.Count + 1;
            colors = new Color[adjustedLen];
            menu = new string[adjustedLen];

            int i = 0;
            foreach (ItemAbstract item in ItemHandler.runeList)
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

            StateHandler.State = new SubStateRuneChange(this, PCid, slot, 0);
        }

        private bool runeSlotTaken(int passedFlag)
        {
            if (!isFlag(passedFlag))
                passedFlag = 42;
            foreach (RuneAbstract r in StateHandler.GetPC(PCid).runes)
                if (r != null && r.Wearflags == passedFlag)
                    return true;
            return false;
        }

        private bool isFlag(int passedFlag)
        {
            return passedFlag == 1
                || passedFlag == 2
                || passedFlag == 1 << 2;
        }

        private bool direction(int input)
        {
            if (input == Globals.KEY_DOWN
            || input == Globals.KEY_UP)
                return true;
            return false;
        }

        public override void Input(int input)
        {
            if (input == Globals.KEY_ACCEPT)
            {
                if (count < ItemHandler.runeList.Count && runeSlotTaken(ItemHandler.runeList[count].Wearflags))
                {
                    MediaHandler.playSFX(FSCMStrikesBackLogic.Properties.Resources.menuBack, "error");
                    return;
                }
                StateHandler.State = new SubStateConfirmEquipMenu(this, 310, 90, PCid, slot, count, Globals.ITEM_TYPE_RUNE);
            }
            else
            {
                StateHandler.AddDelay();
                base.Input(input);
                if (direction(input))
                {
                    StateHandler.State = new SubStateRuneChange(this, PCid, slot, count);
                }
            }
        }//end input


    }
}
