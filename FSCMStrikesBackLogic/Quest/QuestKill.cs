using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;


namespace FSCMStrikesBackLogic
{
 
    class QuestKill : QuestAbstract
    {

        private int enemyID;

        public QuestKill()
        {
            this.next = null;
            this.QuestType = Globals.QUEST_KILL;
            this.progress = 0;
            this.required = 1;
            this.enemyID = 0;
        }//end DVC

        public QuestKill(int toKill, int quantity, QuestInterface passedNext)
        {

            this.next = passedNext;
            this.QuestType = Globals.QUEST_EXPLORE;
            this.progress = 0;
            this.required = quantity;
            this.enemyID = toKill;

            this.messages = new string[2][];

            this.messages[1] = new string[6];
            this.messages[1][0] = "They're all dead, are they?";
            this.messages[1][1] = "Good; quite good.";
            this.messages[1][2] = "Yes, have your reward already.";
            this.messages[1][3] = "I'll be sure to get a hold of you";
            this.messages[1][4] = "the next time that I would like";
            this.messages[1][5] = "to have something. . .shall we say, " + (char)34 + "removed" + (char)34 + ".";

            this.messages[0] = new string[4];

            this.messages[0][0] = "You there!";
            this.messages[0][1] = "Would you kindly murder";
            this.messages[0][2] = required + " " + enemyID + "s";
            this.messages[0][3] = "for me?";

            displayMessage(0, 120, 450, 700, 700);
        }//end QuestKill(toKill, quantity, passNext)

        public QuestKill(int toKill, int quantity, QuestInterface passedNext, string[][] passedMessages)
        {
            this.next = passedNext;
            this.QuestType = Globals.QUEST_KILL;
            this.progress = 0;
            this.required = quantity;
            this.enemyID = toKill;
            this.messages = passedMessages;

            displayMessage(0, 120, 450, 700, 700);
        }
        
        internal override void Complete() 
        {
            displayMessage(1, 500, 500, 700, 700);
        }

        public override void QuestUpdate(int[] updates)
        {
            if(next != null)
                next.QuestUpdate(updates);
            if (updates[0] == Globals.QUEST_KILL)
            {
                if (updates[1] == enemyID)
                {
                    progress += updates[2];
                    if (progress >= required)
                        Complete();
                }//end if(killed the right one)

            }//end if(update == kill)
            
        }//end UpdateQuest



        public override string Describe()
        {
            string description = "";
            if (next != null)
                description = next.Describe();
            description += "You must kill " + (this.required - this.progress) + " more " + this.enemyID + "s.\n";
            return description;
        }

    }//end QuestKill class
}//end logic namespace