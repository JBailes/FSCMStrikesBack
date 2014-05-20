using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic.States.SubStates
{
    class SubStateAttackSelect: SubStateMenuAbstract
    {
        Character[] targets;
        Character attacker;

        public SubStateAttackSelect(StateAbstract theparent, Character theAttacker)
            : base(theparent)
        {
            attacker = theAttacker;
            int i = 0, alive = 0;

            for (i = 0; i < StateCombat.MonsterList.Length; i++)
                if (StateCombat.MonsterList[i].Health > 0)
                    alive++;

            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[alive];
            menu = new string[colors.Length];
            targets = new Character[colors.Length];

            int unavailable = 0;
            for (i = 0; i < StateCombat.MonsterList.Length; i++)
            {
                if (StateCombat.MonsterList[i].Health < 1)
                    unavailable++;
                else
                    targets[i - unavailable] = StateCombat.MonsterList[i];
            }

            for (i = 0; i < menu.Length; i++)
                menu[i] = targets[i].Name;

            for (i = 1; i < colors.Length; i++)
                colors[i] = Color.DarkGray;
            colors[0] = Color.White;

            mX = 450;
            mY = 450;
            width = 125;
            height = 100;


            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }//end EVC

        public override void Input(int input)
        {
            StateHandler.AddDelay();
            base.Input(input);
            if (input == Globals.KEY_ACCEPT)
            {
                attacker.Attack(targets[count], Globals.ELEMENT_PHYSICAL, "physical attack", 0);
            }
            else
                CameraTarget = StateCombat.MonsterList[count];

        }//end input
    }
}
