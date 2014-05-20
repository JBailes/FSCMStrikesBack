using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic.States.SubStates
{
    class SubStateCharSelectSpell: SubStateMenuAbstract
    {
        private SpellAbstract spell;
        private PC curr;
        private Character[] targets;

        public SubStateCharSelectSpell(SubStateAbstract theparent, SpellAbstract theSpell, PC thePC)
            : base(theparent)
        {
            spell = theSpell;
            curr = thePC;
            int i = 0, alive = 0;

            for (i = 0; i < StateCombat.MonsterList.Length; i++)
                if (StateCombat.MonsterList[i].Health > 0)
                    alive++;

            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[3 + alive];
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

            int index = 0;
            for(i = i - unavailable; i < targets.Length; i++, index++)
                targets[i] = StateHandler.GetPC(index);

            for (i = 0; i < menu.Length; i++)
                menu[i] = targets[i].Name;

            for (i = 1; i < colors.Length; i++)
                colors[i] = Color.DarkGray;
            colors[0] = Color.White;

            mX = 250;
            mY = 100;
            width = 690;
            height = 510;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }//end EVC

        public override void Input(int input)
        {
            StateHandler.AddDelay();
            base.Input(input);

            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                spell.Cast(curr, targets[count]);
            }
            else if (input == Globals.KEY_CANCEL)
            {
                StateHandler.AddDelay();
                StateHandler.State = Parent;
            }
        }//end input
    }
}
