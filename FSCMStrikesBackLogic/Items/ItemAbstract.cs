using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMStrikesBackLogic
{
    public class ItemAbstract
    {
        protected int power;
        int wearflags;
        protected string name;

        internal string Name
        {
            get { return name; }
            set { name = value; }
        }

        internal int Wearflags
        {
            get { return wearflags; }
            set { wearflags = value; }
        }

        internal int Power
        {
            get { return power; }
            set { power = value; }
        }
    }
}
