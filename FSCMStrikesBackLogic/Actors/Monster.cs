using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMStrikesBackLogic
{
    class Monster : Character
    {
        protected int type;
        protected BehaviorAbstract behavior;
        protected int quality;
        bool boss;
        internal int ID;

        internal int Type
        {
            get { return type; }
            set { type = value; }
        }

        protected override void die()
        {

        }

        internal void SetBehavior(BehaviorAbstract behave)
        {
            behavior = behave;
        }

        internal void act()
        {
            if (behavior == null)
                behavior = new BehaviorDefend();
            behavior.action(this);
        }

        public int Quality
        {
            get { return quality; }
            set { quality = value; }
        }

        internal bool Boss
        {
            get { return boss; }
            set { boss = value; }
        }

        public override float X
        {
            get
            {
                return MonsterFormation.getX(ID);
            }
            set
            {
            }
        }

        public override float Y
        {
            get
            {
                return MonsterFormation.getY(ID);
            }
            set
            {
            }
        }

        public override float Z
        {
            get
            {
                return MonsterFormation.getZ(ID);
            }
            set
            {
            }
        }
    }
}
