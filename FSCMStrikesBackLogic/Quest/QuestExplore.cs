using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class QuestExplore : QuestAbstract
    {
        private int goalY;
        private int goalX;
        private int difficulty;

        public QuestExplore()
        {
            this.next = null;
            this.QuestType = Globals.QUEST_EXPLORE;
            this.progress = 0;
            this.required = 1;
            this.goalX = 0;
            this.goalY = 0;
        }//end DVC

        public QuestExplore(int x, int y, QuestInterface passed, int diff)
        {

            this.next = passed;
            this.QuestType = Globals.QUEST_EXPLORE;
            this.progress = 0;
            this.required = 1;
            this.goalX = x;
            this.goalY = y;
            this.difficulty = diff;

            this.messages = new string[2][];
            this.messages[1] = new string[5];
            this.messages[1][0] = "           Boss Battle!";
            this.messages[1][1] = "";
            this.messages[1][2] = "      You have encountered the boss";
            this.messages[1][3] = "    guarding this level of the maze for the";
            this.messages[1][4] = "      FLYING SPAGHETTI CODE MONSTER";
          
            this.messages[0] = new string[4];
            this.messages[0][0] = "             You're trapped!";
            this.messages[0][1] = "      Find your way out before the";
            this.messages[0][2] = "     FLYING SPAGHETTI CODE MONSTER";
            this.messages[0][3] = " catches you and crashes your computer!";

            SubStateAbstract quest = new SubStateDisplayMessage(this.messages[0], 120, 450, 300, 300, StateHandler.State);
            StateHandler.State = quest;
        }//end EVC
        
        internal override void Complete() 
        {

            Monster monster = MonsterFactory.randomMonster(StateHandler.Level, 0, Globals.MOB_WEAK, true);

            monster.Boss = true;

            StateHandler.State = new StateCombat(monster);

            StateHandler.Level++;

            MapFactory.GenerateNewMaze();
            StateInGame.locX = MapFactory.startX;
            StateInGame.locY = MapFactory.startY;
            StateInGame.change = true;

            SubStateAbstract quest = new SubStateDisplayMessage(this.messages[1], 120, 450, 400, 400, StateHandler.State);
            StateHandler.State = quest;
        }

        public override void QuestUpdate(int[] updates)
        {
            if(next != null)
                next.QuestUpdate(updates);
            if (updates[0] == Globals.QUEST_EXPLORE)
            {
                if (MapFactory.map[updates[2], updates[1]] == Globals.TILE_EXIT)
                {
                        Complete();
                }//end if(at goal)
            }//end if(update == explore)
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
