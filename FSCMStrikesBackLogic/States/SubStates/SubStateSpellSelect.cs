using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;
using FSCMStrikesBackLogic.States.SubStates;

namespace FSCMStrikesBackLogic.States
{
    class SubStateSpellSelect : SubStateMenuAbstract
    {
        SpellAbstract[] spells;
        PC curr;

        public SubStateSpellSelect(StateAbstract theparent, SpellAbstract[] theSpells, PC thePC)
            : base(theparent)
        {
            spells = theSpells;
            curr = thePC;

            parent = theparent;
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];

            int i;
            colors = new Color[spells.Length];
            menu = new string[spells.Length];
            
            for (i = 0; i < spells.Length && spells[i] != null; i++)
                menu[i] = spells[i].Name;

            for (; i < spells.Length; i++)
                menu[i] = "";

            if (colors.Length > 0)
                colors[0] = Color.White;

            for (i = 1; i < colors.Length; i++)
                colors[i] = Color.DarkGray;

            mX = 190;
            mY = 75;
            width = 780;
            height = 570;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true, true);
        }

        public override void Input(int input)
        {
            base.Input(input);
            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                StateHandler.State = new SubStateCharSelectSpell(this, spells[count], curr);
            }
        }
    }

}
