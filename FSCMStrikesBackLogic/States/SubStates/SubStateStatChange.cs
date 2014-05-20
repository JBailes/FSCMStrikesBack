using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic.States.SubStates
{
    class SubStateStatChange : SubStateMenuAbstract
    {
        private int PCid;
        private int slot;
        private int itemID;

        public SubStateStatChange(StateAbstract parent, int thePC, int itemSlot, int theCount)
            : base(parent)
        {
            this.PCid = thePC;
            this.slot = itemSlot;
            this.itemID = theCount;

            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[10];
            menu = new string[10];

            PC temp = StateHandler.GetPC(PCid);

            if (itemExists() && equipped())
            {
                EquipmentAbstract equip = ItemHandler.equipList[itemID];
                EquipmentAbstract curr = temp.GetEquipment(slot);
                string wflag = getFlags(equip.Wearflags);

                menu[0] = temp.Name;
                menu[1] = temp.getTitle();
                menu[2] = "Health: " + (temp.Health - curr.Hpmod + equip.Hpmod) + "/" + (temp.MaxHealth - curr.Hpmod + equip.Hpmod) + " (" + calcDiff(curr.Hpmod, equip.Hpmod) + ")";
                menu[3] = "MP: " + (temp.Mp - curr.Mpmod + equip.Mpmod) + "/" + (temp.MaxMp - curr.Mpmod + equip.Mpmod) + " (" + calcDiff(curr.Mpmod, equip.Mpmod) + ")";
                menu[4] = "Attack: " + (temp.getAttack() - curr.Attackmod + equip.Attackmod) + " (" + calcDiff(curr.Attackmod, equip.Attackmod) + ")";
                menu[5] = "Defense: " + (temp.getDefense() - curr.Defensemod + equip.Defensemod) + " (" + calcDiff(curr.Defensemod, equip.Defensemod) + ")";
                menu[6] = "Magic: " + (temp.getMagic() - curr.Magicmod + equip.Magicmod) + " (" + calcDiff(curr.Magicmod, equip.Magicmod) + ")";
                menu[7] = "Magic Defense: " + (temp.getMagicDefense() - curr.Magicdefensemod + equip.Magicdefensemod) + " (" + calcDiff(curr.Magicdefensemod, equip.Magicdefensemod) + ")";
                menu[8] = "Slot: " + wflag;
                menu[9] = ItemHandler.equipList[itemID].Name;
            }
            else if (!itemExists() && equipped())
            {
                EquipmentAbstract curr = StateHandler.GetPC(PCid).equipped[slot];
                menu[0] = temp.Name;
                menu[1] = temp.getTitle();
                menu[2] = "Health: " + (temp.Health - curr.Hpmod) + "/" + (temp.MaxHealth - curr.Hpmod) + " (" + calcDiff(curr.Hpmod, 0) + ")";
                menu[3] = "MP: " + (temp.Mp - curr.Mpmod) + "/" + (temp.MaxMp - curr.Mpmod) + " (" + calcDiff(curr.Mpmod, 0) + ")";
                menu[4] = "Attack: " + (temp.getAttack() - curr.Attackmod) + " (" + calcDiff(curr.Attackmod, 0) + ")";
                menu[5] = "Defense: " + (temp.getDefense() - curr.Defensemod) + " (" + calcDiff(curr.Defensemod, 0) + ")";
                menu[6] = "Magic: " + (temp.getMagic() -  curr.Magicmod) + " (" + calcDiff(curr.Magicmod, 0) + ")";
                menu[7] = "Magic Defense: " + (temp.getMagicDefense() - curr.Magicdefensemod) +" (" + calcDiff(curr.Magicdefensemod, 0) + ")";
                menu[8] = "";
                menu[9] = "";
            }
            else if (itemExists() && !equipped())
            {
                EquipmentAbstract equip = ItemHandler.equipList[itemID];
                string wflag = getFlags(equip.Wearflags);
                menu[0] = temp.Name;
                menu[1] = temp.getTitle();
                menu[2] = "Health: " + (temp.Health + equip.Hpmod) + "/" + (temp.MaxHealth + equip.Hpmod) + " (" + calcDiff(0, equip.Hpmod) + ")";
                menu[3] = "MP: " + (temp.Mp + equip.Mpmod) +"/" + (temp.MaxMp + equip.Mpmod) + " (" + calcDiff(0, equip.Mpmod) + ")";
                menu[4] = "Attack: " + (temp.getAttack() + equip.Attackmod) + " (" + calcDiff(0, equip.Attackmod) + ")";
                menu[5] = "Defense: " + (temp.getDefense() + equip.Defensemod) + " (" + calcDiff(0, equip.Defensemod) + ")";
                menu[6] = "Magic: " + (temp.getMagic() + equip.Magicmod) + " (" + calcDiff(0, equip.Magicmod) + ")";
                menu[7] = "Magic Defense: " + (temp.getMagicDefense() + equip.Magicdefensemod) + " (" + calcDiff(0, equip.Magicdefensemod) + ")";
                menu[8] = "Slot: " + wflag;
                menu[9] = ItemHandler.equipList[itemID].Name;
            }
            else//!itemExists() && !equipped()
            {
                menu[0] = temp.Name;
                menu[1] = temp.getTitle();
                menu[2] = "Health: " + temp.Health + "/" + temp.MaxHealth;
                menu[3] = "MP: " + temp.Mp + "/" + temp.MaxMp;
                menu[4] = "Attack: " + temp.getAttack();
                menu[5] = "Defense: " + temp.getDefense();
                menu[6] = "Magic: " + temp.getMagic();
                menu[7] = "Magic Defense: " + temp.getMagicDefense();
                menu[8] = "";
                menu[9] = "";
            }

            for (int i = 0; i < colors.Length; i++)
                colors[i] = Color.DarkGray;

            colors[0] = Color.White;

            mX = 380;
            mY = 90;
            width = 140;
            height = 200;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }

        private string calcDiff(int before, int after)
        {
            int diff = after - before;
            if (diff < 1)
                return diff.ToString();
            return "+" + diff;
        }

        private bool itemExists()
        {
            return itemID < ItemHandler.equipList.Count;
        }

        private string getFlags(int flag)
        {
            string flagSlot = "";
            switch (flag)
            {
                case 1:
                    flagSlot = "Weapon";
                    break;
                case 1 << 1:
                    flagSlot = "Chest";
                    break;
                case 1 << 2:
                    flagSlot = "Head";
                    break;
                case 1 << 3:
                    flagSlot = "Legs";
                    break;
                case 1 << 4:
                    flagSlot = "Feet";
                    break;
            }
            return flagSlot;
        }

        private bool equipped()
        {
            if (StateHandler.GetPC(PCid).equipped[slot] == null)
                return false;
            return true;
        }

        public override void Input(int input)
        {
            parent.Input(input);
        }//end Input

    }
}
