using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic
{
    abstract public class Character : Prop
    {
        protected string name;
        protected int level = 1;
        protected int health;
        protected int maxHealth;
        protected int mp;
        protected int maxMp;
        protected int element;
        protected int attack;
        protected int defense;
        protected int magic;
        protected int magicdefense;
        protected bool defending = false;

        //TODO: Visitor

        internal void Attack(Character attackee, int attackElement, string attackName, int bonus)
        {
            int baseDam;

            defending = false;

            if (attackElement == Globals.ELEMENT_PHYSICAL)
                baseDam = getAttack();
            else
                baseDam = getMagic();

            baseDam = (baseDam / 2) + Globals.Random(0, baseDam);

            baseDam += level * 5;

            if (attackElement == Globals.ELEMENT_PHYSICAL)
                baseDam -= defense / 2;
            else
                baseDam -= magicdefense / 2;

            baseDam -= level * 5;

            if (baseDam < 1)
                baseDam = 1;

            if (this is PC)
                baseDam += (int)(baseDam * StateCombat.strategy * 0.05f);
            else
                baseDam -= (int)(baseDam * StateCombat.strategy * 0.05f);

            attackee.Damage(attackElement, baseDam+bonus, attackName, Name, false);
        }

        internal void Damage(int attackElement, int damage, string attackName, string attackerName, bool mpTarget)
        {
            if (attackElement != Globals.ELEMENT_PHYSICAL && damage > 0)
            {
                switch (attackElement)
                {
                    case Globals.ELEMENT_FIRE:
                        if (element == Globals.ELEMENT_WATER)
                        {
                            if (this is PC)
                                StateCombat.strategy -= 2;
                            else
                                StateCombat.strategy++;
                            damage *= 2;
                        }
                        else if (element == Globals.ELEMENT_NATURE)
                        {
                            if (this is PC)
                                StateCombat.strategy++;
                            else
                                StateCombat.strategy -= 2;
                            damage /= 2;
                        }
                        break;
                    case Globals.ELEMENT_NATURE:
                        if (element == Globals.ELEMENT_FIRE)
                        {
                            if (this is PC)
                                StateCombat.strategy -= 2;
                            else
                                StateCombat.strategy++;
                            damage *= 2;
                        }
                        else if (element == Globals.ELEMENT_WATER)
                        {
                            if (this is PC)
                                StateCombat.strategy++;
                            else
                                StateCombat.strategy -= 2;
                            damage /= 2;
                        }
                        break;
                    case Globals.ELEMENT_WATER:
                        if (element == Globals.ELEMENT_NATURE)
                        {
                            if (this is PC)
                                StateCombat.strategy -= 2;
                            else
                                StateCombat.strategy++;
                            damage *= 2;
                        }
                        else if (element == Globals.ELEMENT_FIRE)
                        {
                            if (this is PC)
                                StateCombat.strategy++;
                            else
                                StateCombat.strategy -= 2;
                            damage /= 2;
                        }
                        break;
                }
            }
            
            if (defending && damage > 0)
            {
                damage = damage / 2;
            }

            if (!mpTarget)
                health -= damage;
            else
                mp -= damage;

            if (defending)
            {
                defending = false;
            }

            string[] status = new string[1];

            string damageT = "hp";

            if (mpTarget)
                damageT = "mp";

            if (attackerName.Length > 2)
            {
                if (damage > 0)
                    status[0] = attackerName + " attacks " + Name + " for " + damage + " " + damageT + " by " + attackName + "!";
                else if (damage == 0)
                    status[0] = attackerName + " completely misses " + Name + " with " + attackName;
                else if (health >= maxHealth)
                {
                    health = maxHealth;
                    status[0] = Name + " is completely healed by " + attackerName + "'s " + attackName;
                }
                else
                    status[0] = attackerName + " heals " + Name + " for " + -damage + " " + damageT + " by " + attackName + "!";
            }
            else
            {
                if (damage > 0)
                    status[0] = Name + " is dealt " + damage + " points of " + damageT + " by " + attackName;
                else if (damage == 0)
                    status[0] = Name + " is completely missed by " + attackName;
                else if (health >= maxHealth)
                {
                    health = maxHealth;
                    status[0] = Name + " is completely healed by " + attackName;
                }
                else
                    status[0] = Name + " is healed for " + -damage + " points of " + damageT + " by " + attackName;
            }

            SubStateAbstract message;

                message = new SubStateConfirmMessage(status, 50, 600, 275, 450, StateHandler.State);

            StateHandler.State = message;

            if (health <= 0)
            {
                die();
                health = 0;
            }
        }

        internal int getLevel()
        {
            return level;
        }

        internal int Health
        {
            get { return health; }
            set { health = value; }
        }

        internal virtual int MaxHealth
        {
            get 
            {
                return maxHealth;
            }
            set { maxHealth = value; }
        }

        internal int Mp
        {
            get { return mp; }
            set { mp = value; }
        }

        internal virtual int MaxMp
        {
            get
            {
                return maxMp;
            }
            set { MaxMp = value; }
        }

        internal int Element
        {
            get { return element; }
            set { element = value; }
        }

        internal string Name
        {
            get { return name; }
            set { name = value; }
        }

        internal void setLevel(int toSet)
        {
            level = toSet;
        }

        internal void setAttack(int toSet)
        {
            attack = toSet;
        }

        internal void setMagic(int toSet)
        {
            magic = toSet;
        }

        internal void setDefense(int toSet)
        {
            defense = toSet;
        }

        internal void setMagicDefense(int toSet)
        {
            magicdefense = toSet;
        }

        internal virtual int getAttack()
        {
            return attack;
        }

        internal virtual int getDefense()
        {
            return defense;
        }

        internal virtual int getMagic()
        {
            return magic;
        }

        internal virtual int getMagicDefense()
        {
            return magicdefense;
        }

        internal bool IsDefending()
        {
            return defending;
        }

        internal void setDefend(bool flag)
        {
            this.defending = flag;

            if (flag)
            {
                MessageBoxInterface[] info = new MessageBoxInterface[1];
                Color[] colors = new Color[1];
                string[] status = new string[1];

                status[0] = Name + " is now defending!";
                colors[0] = Color.White;

                SubStateAbstract message = new SubStateConfirmMessage(status, 50, 400, 350, 450, StateHandler.State);
                StateHandler.State = message;
            }
        }

        protected abstract void die();
    }
}
