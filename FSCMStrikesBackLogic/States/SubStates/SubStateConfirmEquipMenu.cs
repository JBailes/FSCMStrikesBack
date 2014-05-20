using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic.States.SubStates
{
    class SubStateConfirmEquipMenu : SubStateMenuAbstract
    {
        private int PCid;
        private int slot;
        private int itemID;
        private int itemType;

        public SubStateConfirmEquipMenu(SubStateAbstract theparent, int xCoord, int yCoord, int thePC, int itemSlot, int itemLocation, int type)
            : base(theparent)
        {
            PCid = thePC;
            slot = itemSlot;
            itemID = itemLocation;
            itemType = type;
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[2];
            menu = new string[2];

            menu[0] = "Yes";
            menu[1] = "No";

            colors[0] = Color.White;
            colors[1] = Color.DarkGray;

            mX = xCoord;
            mY = yCoord;
            width = 27;
            height = 50;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }//end EVC

        public override void Input(int input)
        {
            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                if(count == 0)
                {
                    equipItem();
                }
                    StateHandler.State = Parent.Parent;
            }
            else if (input == Globals.KEY_CANCEL)
            {
                StateHandler.AddDelay();
                StateHandler.State = Parent;
            }
            else
                base.Input(input);
        }//end input

        private void equipItem()
        {
            if (itemType == Globals.ITEM_TYPE_EQUIP)
            {
                if (itemID == ItemHandler.equipList.Count)
                {
                    unnequipItem();
                    parent = new SubStateListMenuEquip(parent.Parent, PCid, slot);
                    return;
                }
                if (StateHandler.GetPC(PCid).equipped[slot] != null)
                {
                    ItemHandler.equipList.Add(StateHandler.GetPC(PCid).equipped[slot]);
                }
                StateHandler.GetPC(PCid).equipped[slot] = ItemHandler.equipList[itemID];
                ItemHandler.equipList.RemoveAt(itemID);
                parent.Parent = new SubStateSlotMenuEquip((SubStateAbstract)parent.Parent.Parent, PCid);
            }
            else if (itemType == Globals.ITEM_TYPE_RUNE)
            {
                if (itemID == ItemHandler.runeList.Count)
                {
                    unnequipRune();
                    parent = new SubStateListMenuRune(parent.Parent, PCid, slot);
                    return;
                }
                if (StateHandler.GetPC(PCid).runes[slot] != null)
                {
                    ItemHandler.runeList.Add(StateHandler.GetPC(PCid).runes[slot]);
                }
                StateHandler.GetPC(PCid).runes[slot] = ItemHandler.runeList[itemID];
                ItemHandler.runeList.RemoveAt(itemID);
                parent.Parent = new SubStateSlotMenuRune((SubStateAbstract)parent.Parent.Parent, PCid);
            }
        }//end equipItem

        private void unnequipItem()
        {
            if (StateHandler.GetPC(PCid).equipped[slot] == null)
                return;
            ItemHandler.equipList.Add(StateHandler.GetPC(PCid).equipped[slot]);
            StateHandler.GetPC(PCid).equipped[slot] = null;
            parent.Parent = new SubStateSlotMenuEquip((SubStateAbstract)parent.Parent.Parent, PCid);
            parent = new SubStateListMenuEquip(parent.Parent, PCid, slot);
        }

        private void unnequipRune()
        {
            if (StateHandler.GetPC(PCid).runes[slot] == null)
                return;
            ItemHandler.runeList.Add(StateHandler.GetPC(PCid).runes[slot]);
            StateHandler.GetPC(PCid).runes[slot] = null;
            parent.Parent = new SubStateSlotMenuRune((SubStateAbstract)parent.Parent.Parent, PCid);
            parent = new SubStateListMenuRune(parent.Parent, PCid, slot);
        }
    }
}
