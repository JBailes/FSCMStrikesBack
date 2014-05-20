using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class SpellNature : SpellAbstract
    {
        internal SpellNature(int pow)
            : base(pow)
        {
        }

        internal override void Cast(Character attacker, Character target)
        {
            attacker.Attack(target, Globals.ELEMENT_NATURE, Name, Power * 15);

            if (attacker is PC)
                attacker.Element = Globals.ELEMENT_NATURE;
        }

        internal override string Name
        {
            get { return "Nature " + Power; }
        }
    }
}
