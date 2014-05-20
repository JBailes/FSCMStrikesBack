using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMStrikesBackLogic
{
    class NPCTest : NPC
    {
        public NPCTest()
        {
            this.name = "Test dummy";
            this.model = ModelFactory.loadModel("MonsterSlime");
            this.X = 4;
            this.Y = 4;
            this.Z = -26;
            this.level = 1;
            this.maxHealth = 50;
            this.health = this.maxHealth;
            this.attack = 5;
            this.defense = 10;
            this.magic = 10;
        }//end DVC

        protected override void die()
        {
            string[] messages = new string[1];
            messages[0] = "You have defeated the test NPC!";
            SubStateAbstract message = new SubStateDisplayMessage(messages, 50, 405, 400, 400, StateHandler.State);
            StateHandler.State = message;
        }

    }
}
