using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMStrikesBackLogic
{
    public class EquipmentAbstract : ItemAbstract
    {
        private int hpmod;
        private int mpmod;
        private int attackmod;
        private int defensemod;
        private int magicmod;
        private int magicdefensemod;
        private int wearflags;

        internal int Hpmod
        {
            get { return hpmod; }
            set { hpmod = value; }
        }

        internal int Mpmod
        {
            get { return mpmod; }
            set { mpmod = value; }
        }

        internal int Attackmod
        {
            get { return attackmod; }
            set { attackmod = value; }
        }

        internal int Defensemod
        {
            get { return defensemod; }
            set { defensemod = value; }
        }

        internal int Magicmod
        {
            get { return magicmod; }
            set { magicmod = value; }
        }

        internal int Magicdefensemod
        {
            get { return magicdefensemod; }
            set { magicdefensemod = value; }
        }
    }
}
