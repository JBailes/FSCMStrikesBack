using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    static class FormationHandler
    {
        static int formation;
        static string[] formName = {  "The Intern", "Defense", "Caster", "Offense" };
        static string[] descName = {  "The Intern has no bonuses or penalties, it is good at nothing.",
                                      "Defense has a 20% bonus towards def and mdef, and a 20% penalty towards attack and magic.",
                                      "Caster has a 40% bonus towards magic, and a 20% penalty towards def and mdef.",
                                      "Offense has a 40% bonus towards attack, and a 20% penalty towards def and mdef." };

        static internal float getAttBonus()
        {
            if (formation == 3)
                return 1.4f;
            else if (formation == 1)
                return 0.8f;
            else 
                return 1.0f;
        }

        static internal float getMagBonus()
        {
            if (formation == 2)
                return 1.4f;
            else if (formation == 1)
                return 0.8f;
            else
                return 1.0f;
        }

        static internal float getDefBonus()
        {
            if (formation == 1)
                return 1.2f;
            else if (formation != 0)
                return 0.8f;
            else
                return 1.0f;
        }

        static internal float getMagDefBonus()
        {
            if (formation == 1)
                return 1.2f;
            else if (formation != 0)
                return 0.8f;
            else
                return 1.0f;
        }

        static internal int Formation
        {
            get { return formation; }
            set { formation = value; }
        }

        static internal string FormName
        {
            get { return formName[formation]; }
        }

        static internal string FormNameByValue(int val)
        {
            return formName[val];
        }

        static internal string FormDesc
        {
            get { return descName[formation]; }
        }

        static internal string FormDescByValue(int val)
        {
            return descName[val];
        }

        internal static float getX(int target)
        {
            switch (formation)
            {
                case Globals.FORMATION_INTERN:
                    switch(target)
                    {
                        case 0:
                            return 40.0f;
                        case 1:
                            return 30.0f;
                        default:
                            return 20.0f;
                    }
                case Globals.FORMATION_DEFENSE:
                    switch (target)
                    {
                        case 0:
                            return 15;
                        case 1:
                            return 10;
                        default:
                            return 20;
                    }
                case Globals.FORMATION_CASTER:
                    return 30.0f;
                case Globals.FORMATION_OFFENSE:
                    switch (target)
                    {
                        case 0:
                            return 10;
                        case 1:
                            return 20;
                        default:
                            return 15;
                    }
            }
            return 0.0f;
        }

        internal static float getY(int target)
        {
            switch (formation)
            {
                case Globals.FORMATION_INTERN:
                    return 15.0f;
                case Globals.FORMATION_DEFENSE:
                    switch (target)
                    {
                        case 0:
                            return 15;
                        default:
                            return 25;
                    }
                case Globals.FORMATION_CASTER:
                    switch (target)
                    {
                        case 0:
                            return 15.0f;
                        case 1:
                            return 25.0f;
                        default:
                            return 35.0f;
                    }
                case Globals.FORMATION_OFFENSE:
                    switch (target)
                    {
                        case 0: case 1:
                            return 15;
                        default:
                            return 25;
                    }
            }
            return 0.0f;
        }

        internal static float getZ(int target)
        {
            return 15.0f;
            /*
            switch (formation)
            {
                case Globals.FORMATION_INTERN:
                    return 15.0f;
                case Globals.FORMATION_DEFENSE:
                    switch (target)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        default:
                            break;
                    }
                    break;
                case Globals.FORMATION_CASTER:
                    switch (target)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        default:
                            break;
                    }
                    break;
                case Globals.FORMATION_OFFENSE:
                    switch (target)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        default:
                            break;
                    }
                    break;
            }
            return 0.0f;*/
        }
    }
}
