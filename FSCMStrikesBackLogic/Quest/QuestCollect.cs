using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class QuestCollect : QuestAbstract
    {
        private int itemID;

        public QuestCollect()
        {
            this.next = null;
            this.QuestType = Globals.QUEST_COLLECT;
            this.progress = 0;
            this.required = 1;
            this.itemID = 0;
        }//end DVC

        public QuestCollect(int toCollect, int quantity, QuestInterface passedNext)
        {

            this.next = passedNext;
            this.QuestType = Globals.QUEST_COLLECT;
            this.progress = 0;
            this.required = quantity;
            this.itemID = toCollect;

            this.messages = new string[2][];
            this.messages[1] = new string[4];
            this.messages[1][0] = "Ah, excellent!";
            this.messages[1][1] = "Just what I needed.";
            this.messages[1][2] = "I'll be sure to recommend you";
            this.messages[1][3] = "to my friends.";

            this.messages[0] = new string[4];
            this.messages[0][0] = "Desperate times call for desperate";
            this.messages[0][1] = "measures, my friend. And I am in dire";
            this.messages[0][2] = "need of " + quantity + " " + itemID + "s.";
            this.messages[0][3] = "Think ya can do that for me?";

            displayMessage(0, 120, 450, 700, 700);
        }//end QuestCollect(toCollect, quantity, passedNext)

        public QuestCollect(int toCollect, int quantity, QuestInterface passedNext, string[][] passedMessages)
        {
            this.next = passedNext;
            this.QuestType = Globals.QUEST_COLLECT;
            this.progress = 0;
            this.required = quantity;
            this.itemID = toCollect;
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
            if (updates[0] == Globals.QUEST_COLLECT)
            {
                if (updates[1] == itemID)
                {
                    progress += updates[2];
                    if (progress >= required)
                        Complete();
                }//end if(collected the right thing)

            }//end if(update == collect)
            
        }//end UpdateQuest



        public override string Describe()
        {
            string description = "";
            if (next != null)
                description = next.Describe();
            description += "You must obtain " + (this.required - this.progress) + " more " + this.itemID + "s.\n";
            return description;
        }
    }
}
