using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class ConsumableAbstract : ItemAbstract
    {
        int type;

        internal string getName()
        {
            if (name != null && name.Length > 1)
                return name;

            // Rewritten so we only make the decision ONCE, as per the lecturer!

            string temp = "";

            if (Globals.IS_SET(type, Globals.TYPE_CONSUMABLE_FIRE) && Globals.IS_SET(type, Globals.TYPE_CONSUMABLE_PHYSICAL))
                temp = "Grenade";
            else if (Globals.IS_SET(type, Globals.TYPE_CONSUMABLE_FIRE))
                temp = "Firebomb";
            else if (Globals.IS_SET(type, Globals.TYPE_CONSUMABLE_PHYSICAL))
                temp = "Shuriken";
            else if (Globals.IS_SET(type, Globals.TYPE_CONSUMABLE_WATER))
                temp = "Waterbomb";
            else if (Globals.IS_SET(type, Globals.TYPE_CONSUMABLE_NATURE))
                temp = "Naturebomb";
            else if (Globals.IS_SET(type, Globals.TYPE_CONSUMABLE_POTION))
                temp = "Potion";
            else if (Globals.IS_SET(type, Globals.TYPE_CONSUMABLE_ETHER))
                temp = "Ether";
            else
                temp = "Undefined item";

            temp += " " + power;

            name = temp;

            return name;
        }

        internal int Type
        {
            get { return type; }
            set { type = value; }
        }

        internal void use(Character target)
        {
            if (Globals.IS_SET(type, Globals.TYPE_CONSUMABLE_POTION))
                target.Damage(Globals.ELEMENT_NONE, -(power * 25), getName(), "", false);
            else if (Globals.IS_SET(type, Globals.TYPE_CONSUMABLE_ETHER))
                target.Damage(Globals.ELEMENT_NONE, -(power * 25), getName(), "", true);
            else
                target.Attack(target, type, getName(), power * 25);
        }

        internal void use(Character user, Character target)
        {
            if (Globals.IS_SET(type, Globals.TYPE_CONSUMABLE_POTION))
                target.Damage(Globals.ELEMENT_NONE, -(power * 25), user.Name, "", false);
            else if (Globals.IS_SET(type, Globals.TYPE_CONSUMABLE_ETHER))
                target.Damage(Globals.ELEMENT_NONE, -(power * 25), user.Name, "", true);
            else
                user.Attack(target, type, this.name, power * 25);
        }
    }
}