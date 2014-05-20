using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class QuestCombatTESTING : QuestAbstract
    {
        private int goalY;
        private int goalX;

        public QuestCombatTESTING()
        {
            this.next = null;
            this.QuestType = Globals.QUEST_EXPLORE;
            this.progress = 0;
            this.required = 1;
            this.goalX = 0;
            this.goalY = 0;
        }//end DVC

        public QuestCombatTESTING(int x, int y, QuestInterface passed, int diff)
        {

            this.next = passed;
            this.QuestType = Globals.QUEST_EXPLORE;
            this.progress = 0;
            this.required = 1;
            this.goalX = x;
            this.goalY = y;

            this.messages = new string[2][];
            this.messages[1] = new string[8];
            this.messages[1][0] = "             Congratulations!";
            this.messages[1][1] = "";
            this.messages[1][2] = "         You have beaten the ambush";
            this.messages[1][3] = "             and thwarted the";
            this.messages[1][4] = "      FLYING SPAGHETTI CODE MONSTER";
            this.messages[1][5] = "";
            this.messages[1][6] = "";
            this.messages[1][7] = "Press [R] to generate a new maze to escape!";

            this.messages[0] = new string[4];
            this.messages[0][0] = "          You've been ambushed!";
            this.messages[0][1] = "     Fight your way out before the";
            this.messages[0][2] = "     FLYING SPAGHETTI CODE MONSTER";
            this.messages[0][3] = " catches you and crashes your computer!";

            Monster monster = MonsterFactory.randomMonster(StateHandler.Level, 0, Globals.MOB_WEAK, true);

            monster.Boss = true;

            StateHandler.State = new StateCombat(monster);

            StateHandler.Level++;

            MapFactory.GenerateNewMaze();
            StateInGame.locX = MapFactory.startX;
            StateInGame.locY = MapFactory.startY;
            StateInGame.change = true;

            SubStateAbstract quest = new SubStateDisplayMessage(this.messages[0], 120, 450, 300, 300, StateHandler.State);
            StateHandler.State = quest;
        }//end EVC

        internal override void Complete()
        {

            SubStateAbstract quest = new SubStateDisplayMessage(this.messages[1], 150, 500, 300, 300, StateHandler.State);
            StateHandler.State = quest;
        }

        public override void QuestUpdate(int[] updates)
        {
            if (next != null)
                next.QuestUpdate(updates);
            /*
            string[] test = new string[2];
            test[0] = "X: " + updates[1] + " Y: " + updates[2];
            test[1] = "Goal: X: " + goalX + " Y: " + goalY;
            SubStateAbstract quest = new SubStateDisplayMessage(test, 150, 500, 300, 300, StateHandler.State);
            StateHandler.State = quest;
            */
            if (updates[0] == Globals.QUEST_EXPLORE)
            {
                if (updates[1] == goalX && updates[2] == goalY)
                {
                    Complete();
                }//end if(at goal)

            }//end if(updates[0] == explore)

        }//end UpdateQuest



        public override string Describe()
        {
            string description = "";
            if (next != null)
                description = next.Describe();
            description += "You must travel to " + this.goalX + "," + this.goalY + ".\n";
            return description;
        }

    }
}
