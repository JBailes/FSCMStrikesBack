using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic
{
    class BehaviorSmart : BehaviorAbstract
    {
        public override void action(Monster parent)
        {

            BehaviorAbstract att = null;
            switch (Globals.Random(1, 10))
            {
                case 0:
                    att = new BehaviorAttack();
                    break;
                case 1:
                    att = new BehaviorDefend();
                    break;
                case 2:
                    att = new BehaviorBasicFire();
                    break;
                case 3:
                    att = new BehaviorEmbers();
                    break;
                case 4:
                    att = new BehaviorFlameStorm();
                    break;
                case 5:
                    att = new BehaviorBasicWater();
                    break;
                case 6:
                    att = new BehaviorHurricane();
                    break;
                case 7:
                    att = new BehaviorBasicNature();
                    break;
                case 8:
                    att = new BehaviorNature();
                    break;
                case 9:
                    att = new BehaviorSuperNature();
                    break;
            }

            att.action(parent);

        }
    }
}
