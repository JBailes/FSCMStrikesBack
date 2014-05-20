using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class SpellFire : SpellAbstract
    {
        internal SpellFire(int pow)
            : base(pow)
        {
        }

        internal override void Cast(Character attacker, Character target)
        {
            attacker.Attack(target, Globals.ELEMENT_FIRE, Name, Power * 15);

            if (attacker is PC)
                attacker.Element = Globals.ELEMENT_FIRE;
        }

        internal override string Name
        {
            get { return "Fire " + Power; }
        }
    }
}
