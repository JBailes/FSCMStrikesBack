using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class StateInGame : StateAbstract
    {
        internal static float locX;
        internal static float locY;
        internal static bool change = false;
        public Actor mainActor;
        static float stepsTaken;
        static int combatTarget;
        static bool newGame = true;

        private List<Actor> actorList = null;

        public StateInGame()
        {
            combatTarget = Globals.Random(8, 10);
        }

        public override void Update()
        {
            if (fresh)
            {
                fresh = false;
                actorList = MapFactory.GetCurrentMaze();
                MediaHandler.playBGM(FSCMStrikesBackLogic.Properties.Resources.mazebgm, "mazebgm");
                MediaHandler.Background = "default.png";
                mainActor = PCBuilder.getPC("John");
                actorList.Add(mainActor);
                StateHandler.CameraTarget = mainActor;
                if (newGame)
                {
                    StateHandler.Level = 1;
                    StateHandler.Quest = (new QuestExplore(17, 17, null, 2));

                    PCBuilder.getPC(0).equipped[0] = ItemFactory.CreateEquip(Globals.WEARFLAG_WEAPON, Globals.ELEMENT_NATURE, 1, Globals.ITEM_QUALITY_TRASH, "");
                    PCBuilder.getPC(0).equipped[1] = ItemFactory.CreateEquip(Globals.WEARFLAG_CHEST, Globals.ELEMENT_NATURE, 1, Globals.ITEM_QUALITY_TRASH, "");
                    PCBuilder.getPC(0).equipped[2] = ItemFactory.CreateEquip(Globals.WEARFLAG_HEAD, Globals.ELEMENT_NATURE, 1, Globals.ITEM_QUALITY_TRASH, "");
                    PCBuilder.getPC(0).equipped[3] = ItemFactory.CreateEquip(Globals.WEARFLAG_LEGS + Globals.WEARFLAG_FEET, Globals.ELEMENT_NATURE, 1, Globals.ITEM_QUALITY_TRASH, "");
                    PCBuilder.getPC(0).runes[0] = ItemFactory.CreateRune(0, Globals.ELEMENT_NATURE, -1, -1, "");
                    PCBuilder.getPC(0).Health = PCBuilder.getPC(0).MaxHealth;

                    PCBuilder.getPC(1).equipped[0] = ItemFactory.CreateEquip(Globals.WEARFLAG_WEAPON, Globals.ELEMENT_FIRE, 1, Globals.ITEM_QUALITY_TRASH, "");
                    PCBuilder.getPC(1).equipped[1] = ItemFactory.CreateEquip(Globals.WEARFLAG_CHEST, Globals.ELEMENT_FIRE, 1, Globals.ITEM_QUALITY_TRASH, "");
                    PCBuilder.getPC(1).equipped[2] = ItemFactory.CreateEquip(Globals.WEARFLAG_HEAD, Globals.ELEMENT_FIRE, 1, Globals.ITEM_QUALITY_TRASH, "");
                    PCBuilder.getPC(1).equipped[3] = ItemFactory.CreateEquip(Globals.WEARFLAG_LEGS + Globals.WEARFLAG_FEET, Globals.ELEMENT_FIRE, 1, Globals.ITEM_QUALITY_TRASH, "");
                    PCBuilder.getPC(1).runes[0] = ItemFactory.CreateRune(0, Globals.ELEMENT_FIRE, -1, -1, "");
                    PCBuilder.getPC(1).Health = PCBuilder.getPC(1).MaxHealth;

                    PCBuilder.getPC(2).equipped[0] = ItemFactory.CreateEquip(Globals.WEARFLAG_WEAPON, Globals.ELEMENT_PHYSICAL, 3, Globals.ITEM_QUALITY_LEGENDARY, "The Smile");
                    PCBuilder.getPC(2).equipped[1] = ItemFactory.CreateEquip(Globals.WEARFLAG_HEAD, Globals.ELEMENT_PHYSICAL, 3, Globals.ITEM_QUALITY_LEGENDARY, "The Glasses");
                    PCBuilder.getPC(2).equipped[2] = ItemFactory.CreateEquip(0, Globals.ELEMENT_PHYSICAL, 4, Globals.ITEM_QUALITY_MYTHICAL, "The Beard");
                    PCBuilder.getPC(2).equipped[3] = ItemFactory.CreateEquip(Globals.WEARFLAG_CHEST | Globals.WEARFLAG_LEGS | Globals.WEARFLAG_FEET, Globals.ELEMENT_PHYSICAL, 3, Globals.ITEM_QUALITY_LEGENDARY, "The Trenchcoat");
                    PCBuilder.getPC(2).runes[0] = ItemFactory.CreateRune(0, Globals.ELEMENT_WATER, -1, -1, "");
                    PCBuilder.getPC(2).Health = PCBuilder.getPC(2).MaxHealth;

                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_POTION, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_POTION, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_POTION, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_POTION, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_POTION, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_POTION, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_POTION, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_POTION, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_POTION, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_POTION, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_POTION, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_POTION, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_FIRE + Globals.TYPE_CONSUMABLE_PHYSICAL, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_FIRE, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_WATER, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_NATURE, 0, 1, Globals.ITEM_QUALITY_TRASH, null));
                    ItemHandler.itemList.Add(ItemFactory.CreateConsumable(Globals.TYPE_CONSUMABLE_PHYSICAL, 0, 1, Globals.ITEM_QUALITY_TRASH, null));

                    newGame = false;
                }
            }

            if (change)
            {
                change = false;
                mainActor.X = locX;
                mainActor.Y = locY;
            }
        }

        public override void Input(int input)
        {
            switch (input)
            {
                case Globals.KEY_DOWN:
                    if (mainActor != null)
                        mainActor.MoveY(-0.3f);
                    break;
                case Globals.KEY_UP:
                    if (mainActor != null)
                        mainActor.MoveY(0.3f);
                    break;
                case Globals.KEY_LEFT:
                    if (mainActor != null)
                        mainActor.MoveX(-0.3f);
                    break;
                case Globals.KEY_RIGHT:
                    if (mainActor != null)
                        mainActor.MoveX(0.3f);
                    break;
                case Globals.KEY_ACCEPT:
                    break;
                case Globals.KEY_CANCEL:
                    break;
                case Globals.KEY_MENU:
                    StateHandler.State = new SubStateGameMenu(this);
                    break;
                case Globals.KEY_MISC:
                    break;
                // These are meant for rotations around the character.
                case Globals.KEY_CAMERA_LEFT:
                    Camera.Rotate(-1.0f);
                    break;
                case Globals.KEY_CAMERA_RIGHT:
                    Camera.Rotate(1.0f);
                    break;
                case Globals.KEY_START:
                    StateHandler.Paused = !StateHandler.Paused;
                    if (StateHandler.Paused)
                        MediaHandler.Pause();
                    else
                        MediaHandler.Unpause();
                    StateHandler.AddDelay();
                    break;
            }
        }

        public override void Input(float input, int target)
        {
            switch (target)
            {
                case Globals.LEFT_CONTROL_X:
                    mainActor.MoveX(input);
                    break;
                case Globals.LEFT_CONTROL_Y:
                    mainActor.MoveY(input);
                    break;
                case Globals.RIGHT_CONTROL_X:
                    Camera.RotateY(input);
                    break;
                case Globals.RIGHT_CONTROL_Y:
                    Camera.cameraZoom(input);
                    break;
            }
        }

        public override List<Actor> GetSceneList()
        {
            List<Actor> temp = actorList;

            return temp;
        }

        static internal void checkCombat(float move)
        {
            if (move < 0)
                move *= -1;

            stepsTaken += move;

            if (stepsTaken > combatTarget*4)
            {
                stepsTaken = 0;
                generateCombatChance();
                Monster[] monsterList = new Monster[Globals.Random(1, 4)];
                for (int i = 0; i < monsterList.Length; i++)
                {
                    monsterList[i] = MonsterFactory.randomMonster(StateHandler.Level, 0, Globals.MOB_WEAK, true);
                    monsterList[i].ID = i;
                }
                // Enter combat here
                StateHandler.State = new StateCombat(monsterList);
                    //.generateMonster("", StateHandler.Level, 0, Globals.MOB_WEAK, false));
            }
        }

        static private void generateCombatChance()
        {
            int min = 5 + (3-StateHandler.Difficulty);
            int max = 15 + (3-StateHandler.Difficulty);

            int targetSteps = max - combatTarget + min;

            targetSteps += Globals.Random(0, 4);
            targetSteps -= 2;

            if (targetSteps < min)
                targetSteps = min;

            if (targetSteps > max)
                targetSteps = max;

            combatTarget = targetSteps;
        }
    }
}
