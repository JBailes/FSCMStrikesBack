using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMStrikesBackLogic
{
    public class RuneAbstract : ItemAbstract
    {
        int flags;
        int exp;
        int level;
        int[] levelCost;
        SpellAbstract[] spells;

        internal RuneAbstract(int[] LevelCost, SpellAbstract[] Spells)
        {
            levelCost = LevelCost;
            spells = Spells;
        }

        internal void cast(int spell)
        {
            if (spell >= spells.Length)
                return;

            spells[spell].Cast(null, null);
        }

        internal void GainExp(int exp)
        {
            if (level >= spells.Length-1)
                return;

            exp += exp;
            if (levelCost[level] > exp)
            {
                exp -= levelCost[level];
                level++;
            }
        }

        internal int Level
        {
            get { return level; }
            private set { level = value; }
        }

        internal int LevelCost
        {
            get { return levelCost[level]; }
            // There is no set. NO SET!
        }

        internal SpellAbstract[] getSpells() { return spells; }

    }
}
