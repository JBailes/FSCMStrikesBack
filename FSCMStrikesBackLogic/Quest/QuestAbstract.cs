using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    abstract class QuestAbstract : QuestInterface
    {
        protected int QuestType;
        protected int progress;
        protected int required;
        protected string[][] messages;

        public QuestInterface next
        {
            get { return null;  }
            set { }
        }
        
        internal virtual void Complete() 
        {
            
        }

        public virtual void QuestUpdate(int[] updates)
        {

        }

        public virtual string Describe()
        {
            return "";
        }

        protected void displayMessage(int i, int height, int width, int x, int y)
        {
            SubStateAbstract message = new SubStateDisplayMessage(messages[i], height, width, x, y, StateHandler.State);
            StateHandler.State = message;
        }

    }//end QuestAbstract

}//end Logic namespace
