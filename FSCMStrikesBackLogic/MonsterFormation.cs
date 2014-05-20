using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMStrikesBackLogic
{
    static class MonsterFormation
    {
        internal static float getX(int monster)
        {
            switch (monster)
            {
                case 0:
                    return 10;
                case 1:
                    return 30;
                case 2:
                    return 10;
                default:
                    return 30;
            }
        }

        internal static float getY(int monster)
        {
            switch (monster)
            {
                case 0:
                    return -10;
                case 1:
                    return -10;
                case 2:
                    return -30;
                default:
                    return -30;
            }
        }

        internal static float getZ(int monster)
        {
            return 7;
        }
    }
}
