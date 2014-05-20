using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;
using FSCMStrikesBackLogic.States;
using FSCMStrikesBackLogic.States.SubStates;

namespace FSCMStrikesBackLogic
{
    class StateCombat : StateAbstract
    {
        Prop background = new Prop();
        static internal Monster[] MonsterList;
        static internal int strategy;
        List<Character> TurnList = new List<Character>();
        Character current;
        int curIndex = 0;
        bool won = false;
        bool lost = false;
        bool takenTurn = false;
        bool approvedTurn = false;

        internal StateCombat()
        {
            MonsterList = new Monster[1];
            
            MonsterList[0] = MonsterFactory.randomMonster(1, Globals.ELEMENT_NONE, Globals.MOB_WEAK, false);

            initialize();
        }

        internal StateCombat(Monster monster)
        {
            MonsterList = new Monster[1];

            MonsterList[0] = monster;

            initialize();
        }

        internal StateCombat(Monster[] monsters)
        {
            MonsterList = monsters;
            initialize();
        }

        public void initialize()
        {
            MediaHandler.playBGM(FSCMStrikesBackLogic.Properties.Resources.Five_Armies, "Five_Armies");

            background.model = ModelFactory.loadModel("SuperBattleCave");
            background.Scale = 3.0f;

            TurnList.Add(StateHandler.GetPC(0));
            TurnList.Add(StateHandler.GetPC(1));
            TurnList.Add(StateHandler.GetPC(2));
            for(int i=0; i<MonsterList.Length; i++)
                TurnList.Add(MonsterList[i]);

            current = StateHandler.GetPC(0);

            cameraTarget = PCBuilder.getPC(0);

            strategy = 0;

            x = 75;
            y = 50;
            z = 10;
        }

        public override List<Actor> GetSceneList()
        {
            List<Actor> temp = new List<Actor>();

            temp.Add(background);
            for (int i = 0; i < MonsterList.Length; i++)
                temp.Add(MonsterList[i]);
            temp.Add(StateHandler.GetPC(0));
            temp.Add(StateHandler.GetPC(1));
            temp.Add(StateHandler.GetPC(2));


            return temp;
        }

        public override bool focusTarget()
        {
            return false;
        }

        public override void Update()
        {
            if (fresh)
            {
                fresh = false;
                StateHandler.State = new SubStateCombatMenu(this);
            }
        }

        public override MessageBoxInterface[] GetMessageBoxes
        {
            get 
            {
                MessageBoxInterface[] combatInfo = new MessageBoxInterface[3];
                Color[] colors = new Color[MonsterList.Length];
                string[] status = new string[MonsterList.Length];

                for (int i = 0; i < MonsterList.Length; i++)
                {
                    status[i] = MonsterList[i].Name + " " + MonsterList[i].Health + @"/" + MonsterList[i].MaxHealth;

                    if (MonsterList[i] == current)
                        colors[i] = Color.White;
                    else
                        colors[i] = Color.DarkGray;
                }

                combatInfo[0] = new MessageBox(50, 600, 300, 100, status, colors, true);//700 to 600

                status = new string[3];
                colors = new Color[3];

                for (int i = 0; i < 3; i++ )
                {
                    status[i] = StateHandler.GetPC(i).Name + " " + StateHandler.GetPC(i).Health + @"/" + StateHandler.GetPC(i).MaxHealth;

                    if (StateHandler.GetPC(i) == current)
                        colors[i] = Color.White;
                    else
                        colors[i] = Color.DarkGray;
                }

                combatInfo[1] = new MessageBox(700, 600, 300, 100, status, colors, true);//700 to 600 on y 600 to 700 on x

                status = new string[1];
                colors = new Color[1];

                colors[0] = Color.White;
                status[0] = "Strategy: " + strategy;

                combatInfo[2] = new MessageBox(800, 50, 150, 50, status, colors, true);

                return combatInfo;
            }
            set { }
        }

        internal override bool AlternateState()
        {
            return true;
        }

        public override void ParentInput(int input)
        {
            if (!won && !lost)
            {
                if (current != MonsterList[0])
                {
                    switch (input)
                    {
                        case Globals.MENU_ATTACK:
                            StateHandler.State = new SubStateAttackSelect(StateHandler.State, current);
                            MediaHandler.playSFX(FSCMStrikesBackLogic.Properties.Resources.attack, "attack");
                            break;
                        case Globals.MENU_DEFEND:
                            current.setDefend(true);
                            MediaHandler.playSFX(FSCMStrikesBackLogic.Properties.Resources.defend, "defend");
                            break;
                        case Globals.MENU_ITEM:
                            MediaHandler.playSFX(FSCMStrikesBackLogic.Properties.Resources.itemSelect, "selectItem");
                            break;
                        case Globals.MENU_MAGIC:
                            StateHandler.State = new SubStateRuneSelect(StateHandler.State, current);
                            MediaHandler.playSFX(FSCMStrikesBackLogic.Properties.Resources.magic, "magic");
                            break;
                        case Globals.MENU_ITEM_USED:
                            break;
                    }
                }

                if (input == Globals.MESSAGE_CONFIRMED)
                {
                    nextTurn();

                    if (!(current is PC))
                    {
                        foreach (Monster m in MonsterList)
                            m.act();
                        nextTurn();
                    }
                }
            }
            else if (won)
                StateHandler.changeState(new StateInGame());
            else if (input == Globals.MESSAGE_CONFIRMED)
                StateHandler.changeState( new StateTitleScreen() );

            bool allDefeated = true;
            foreach (Monster m in MonsterList)
                if (m.Health > 0)
                    allDefeated = false;

            if (allDefeated)
                Victory();

            if (allDefeated && input == Globals.MESSAGE_CONFIRMED)
            {
                if (!won)
                    Victory();
                else
                    StateHandler.State = new StateInGame();
            }
        }

        private void nextTurn()
        {
            curIndex++;

            if (current == MonsterList[0])
            {
                curIndex = 0;
            }

            if (curIndex > 2)
            {
                current = MonsterList[0];
                return;
            }

            current = StateHandler.GetPC(curIndex);

            if (current.Health < 1)
            {
                bool gameOver = true;
                for(int i = 0; i < 3; i++)
                {
                    if (PCBuilder.getPC(i).Health > 0)
                        gameOver = false;
                }
                if (gameOver)
                {
                    StateHandler.AddDelay();
                    Defeat();
                }
                else
                    nextTurn();
            }
            else
                cameraTarget = current;
        }

        private void Victory()
        {

            won = true;
            MessageBoxInterface[] messageBoxes = new MessageBoxInterface[1];
            Color[] colors = new Color[2];
            colors[0] = Color.White;
            colors[1] = Color.White;

            int mX = 400;
            int mY = 100;
            int height = 100;
            int width = 345;

            int exp = getExp();

            string[] attackMessage = new string[2];
            attackMessage[0] = "Victory!!";
            attackMessage[1] = "You have earned " + exp + " Exp!";

            for (int i = 0; i < 3; i++)
                StateHandler.GetPC(i).addExp(exp);

            SubStateDisplayMessage temp = new SubStateDisplayMessage(attackMessage, height, width, mX, mY, StateHandler.State);
            StateHandler.State = temp;

            ItemFactory.combatGenerate(MonsterList[0].Element, StateHandler.Level, MonsterList[0].Quality, MonsterList[0].Boss, "");
        }

        private int getExp()
        {
            int totalExp = 0;

            foreach (Monster m in MonsterList)
            {
                int baseExp = 100 + ((m.getLevel() - 1) * 75);

                baseExp += (baseExp / 10) * StateHandler.Difficulty;

                int exp = (int)(baseExp * ((m.Quality * 0.50) + 1));

                if (m.Quality >= Globals.MOB_BOSS)
                    exp *= 2;

                if (m.Quality >= Globals.MOB_SPECIAL)
                    exp *= 2;

                if (m.Boss)
                    exp *= 3;

                totalExp += exp;
            }

            return totalExp;
        }

        private void Defeat()
        {
            lost = true;
            StateAbstract title = new StateTitleScreen();

            MessageBoxInterface[] messageBoxes = new MessageBoxInterface[1];
            Color[] colors = new Color[2];
            colors[0] = Color.White;
            colors[1] = Color.White;

            int mX = 400;
            int mY = 100;
            int height = 100;
            int width = 345;

            string[] attackMessage = new string[2];
            attackMessage[0] = "Game Over!!";
            attackMessage[1] = "The Flying Spaghetti Code Monster has triumphed!";

            SubStateDisplayMessage temp = new SubStateDisplayMessage(attackMessage, height, width, mX, mY, StateHandler.State);
            StateHandler.State = temp;
        } 
    }
}