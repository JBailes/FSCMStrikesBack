using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic.States.SubStates
{
    class SubStateCharSelectMenuUseCombat : SubStateMenuAbstract
    {
        int itemID;

        public SubStateCharSelectMenuUseCombat(SubStateAbstract theparent, int itemSlot)
            : base(theparent)
        {
            int i = 0, alive = 0;
            for (i = 0; i < StateCombat.MonsterList.Length; i++)
                if (StateCombat.MonsterList[i].Health > 0)
                    alive++;
            itemID = itemSlot;
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[3 + alive];
            menu = new string[colors.Length];

            menu[0] = StateHandler.GetPC(0).Name;
            menu[1] = StateHandler.GetPC(1).Name;
            menu[2] = StateHandler.GetPC(2).Name;
            
            int unavailable = 0;
            for (i = 0; i < StateCombat.MonsterList.Length; i++)
            {
                if (StateCombat.MonsterList[i].Health < 1)
                    unavailable++;
                else
                    menu[3 + i - unavailable] = StateCombat.MonsterList[i].Name;
            }

            colors[0] = Color.White;
            for (i = 1; i < colors.Length; i++)
                colors[i] = Color.DarkGray;

            mX = 170;
            mY = 60;
            width = 760;
            height = 490;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }//end EVC


        public override void Input(int input)
        {
            StateHandler.AddDelay();
            base.Input(input);

            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                StateHandler.State = new SubStateConfirmUseMenuCombat(this, itemID, count);
            }
            
        }//end input
    }
}
