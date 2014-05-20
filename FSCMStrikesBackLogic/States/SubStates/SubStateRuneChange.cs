using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic.States.SubStates
{
    class SubStateRuneChange : SubStateMenuAbstract
    {
        private int PCid;
        private int slot;
        private int itemID;

        public SubStateRuneChange(StateAbstract parent, int thePC, int runeSlot, int theCount)
            : base(parent)
        {
            this.PCid = thePC;
            this.slot = runeSlot;
            this.itemID = theCount;

            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[4];
            menu = new string[4];

            if (itemID < ItemHandler.runeList.Count)
            {
                RuneAbstract run = ItemHandler.runeList[itemID];
                string flag = generateFlag(run.Wearflags);
                menu[0] = run.Name;
                menu[1] = "Level " + run.Level.ToString();
                menu[2] = "Slot: " + flag;
                menu[3] = "";
                
                SpellAbstract[] sp = run.getSpells();
                if (sp != null)
                    foreach (SpellAbstract s in sp)
                        menu[3] += s.Name + "\n";
            }
            else
            {
                for (int i = 0; i < menu.Length; i++)
                    menu[i] = "";
            }


            for (int i = 0; i < colors.Length; i++)
                colors[i] = Color.DarkGray;

            colors[0] = Color.White;

            mX = 380;
            mY = 90;
            width = 140;
            height = 170;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }

        private string generateFlag(int flag)
        {
            string flagSlot = "";
            switch (flag)
            {
                case 1:
                    flagSlot = "Right";
                    break;
                case 2:
                    flagSlot = "Left";
                    break;
                case 1 << 2:
                    flagSlot = "Head";
                    break;
            }

            return flagSlot;
        }

        public override void Input(int input)
        {
            parent.Input(input);
        }//end Input

    }
}
