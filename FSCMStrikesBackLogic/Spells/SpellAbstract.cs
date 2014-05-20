using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMStrikesBackLogic
{
    class SpellAbstract
    {
        private string name;
        private int cost;
        private int power;

        internal SpellAbstract(int pow)
        {
            power = pow;
        }

        internal int Power
        {
            get { return power; }
            set { power = value; }
        }

        internal virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        internal int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        internal virtual void Cast(Character attacker, Character target)
        {
        }
    }
}
