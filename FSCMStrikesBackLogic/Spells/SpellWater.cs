using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class SpellWater : SpellAbstract
    {
        internal SpellWater(int pow)
            : base(pow)
        {
        }

        internal override void Cast(Character attacker, Character target)
        {
            attacker.Attack(target, Globals.ELEMENT_WATER, Name, Power * 15);

            if (attacker is PC)
                attacker.Element = Globals.ELEMENT_WATER;
        }

        internal override string Name
        {
            get { return "Water " + Power; }
        }
    }
}
