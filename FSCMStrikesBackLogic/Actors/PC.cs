using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMStrikesBackLogic
{
    public class PC : Character
    {
        protected string title;
        public EquipmentAbstract[] equipped = new EquipmentAbstract[4];
        public RuneAbstract[] runes = new RuneAbstract[2];

        protected float combatX;
        protected float combatY;
        protected float combatZ;
        protected int exp;

        public EquipmentAbstract GetEquipment(int toGet)
        {
            return equipped[toGet];
        }

        public RuneAbstract GetRune(int toGet)
        {
            return runes[toGet];
        }

        protected override void die()
        {
            string[] messages = new string[1];
            messages[0] = this.name + " has died!";
            SubStateAbstract message = new SubStateConfirmMessage(messages, 50, 405, 400, 200, StateHandler.State);
            StateHandler.State = message;
        }

        internal override int getAttack()
        {
            int att = attack;
            for (int i = 0; i < equipped.Length; i++)
                if (equipped[i] != null)
                    att += equipped[i].Attackmod;

            att = (int)(att * FormationHandler.getAttBonus());

            return att;
        }

        internal override int getDefense()
        {
            int def = defense;
            for (int i = 0; i < equipped.Length; i++)
                if (equipped[i] != null)
                    def += equipped[i].Defensemod;

            def = (int)(def * FormationHandler.getDefBonus());

            return def;
        }

        internal override int getMagic()
        {
            int mag = magic;
            for (int i = 0; i < equipped.Length; i++)
                if (equipped[i] != null)
                    mag += equipped[i].Magicmod;

            mag = (int)(mag * FormationHandler.getMagBonus());

            return mag;
        }

        internal override int getMagicDefense()
        {
            int mdef = magicdefense;
            for (int i = 0; i < equipped.Length; i++)
                if (equipped[i] != null)
                    mdef += equipped[i].Magicdefensemod;

            mdef = (int)(mdef * FormationHandler.getMagDefBonus());

            return mdef;
        }

        internal override int MaxHealth
        {
            get
            {
                int max = maxHealth;
                for (int i = 0; i < equipped.Length; i++)
                    if (equipped[i] != null)
                        max += equipped[i].Hpmod;
                return max;
            }
            set { maxHealth = value; }
        }
        internal override int MaxMp
        {
            get
            {
                int max = maxMp;
                for (int i = 0; i < equipped.Length; i++)
                    if (equipped[i] != null)
                        max += equipped[i].Mpmod;
                return max;
            }
            set { MaxMp = value; }
        }

        public override float X
        {
            get
            {
                if (!StateHandler.AlternateState())
                    return base.X;
                else
                    return FormationHandler.getX(PCBuilder.getPcID(Name));
            }
        }

        public override float Y
        {
            get
            {
                if (!StateHandler.AlternateState())
                    return base.Y;
                else
                    return FormationHandler.getY(PCBuilder.getPcID(Name));
            }
        }

        public override float Z
        {
            get
            {
                if (!StateHandler.AlternateState())
                    return base.Z;
                else
                    return FormationHandler.getZ(PCBuilder.getPcID(Name));
            }
        }

        internal void addExp(int toAdd)
        {
            exp += toAdd;
            if (exp > level * 1000)
                levelUp();
        }

        internal int getExp()
        {
            return exp;
        }

        protected void levelUp()
        {
            exp -= level * 1000;
            this.level++;
            int healthChange = 20;
            this.maxHealth += healthChange;
            this.health += healthChange;
            this.attack += 2;
            this.defense += 2;
            this.magic += 2;
            //more in the future
        }

        public string getTitle() { return title; }
        public void setTitle(string titleToSet) { title = titleToSet; }

        public void setCombatLoc(int tarX, int tarY, int tarZ) { combatX = tarX; combatY = tarY; combatZ = tarZ; }
    }
}
