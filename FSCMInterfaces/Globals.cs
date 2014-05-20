using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMInterfaces
{
    public static class Globals
    {
        public const int TILE_UNPASSABLE = 0;
        public const int TILE_PASSABLE = 1;
        public const int TILE_EXIT = 10;
        public const int TILE_GRASS_WALL1 = 3;
        public const int TILE_GRASS_WALL2 = 4;
        public const int TILE_GRASS_CORNERL = 5;
        public const int TILE_GRASS_CORNERR = 6;
        public const int TILE_GRASS_CUBE = 7;
        public const int TILE_GRASS_ENDL = 8;
        public const int TILE_GRASS_ENDR = 9;
        public const int TILE_BOSS = 10;

        
        public const int KEY_UP = 0;
        public const int KEY_DOWN = 1;
        public const int KEY_LEFT = 2;
        public const int KEY_RIGHT = 3;
        public const int KEY_ACCEPT = 4;
        public const int KEY_CANCEL = 5;
        public const int KEY_MENU = 6;
        public const int KEY_MISC = 7;
        public const int KEY_CAMERA_RIGHT = 8;
        public const int KEY_CAMERA_LEFT = 9;
        public const int KEY_FULLSCREEN = 10;
        public const int KEY_START = 11;

        public const int MENU_ATTACK = 101;
        public const int MENU_MAGIC = 102;
        public const int MENU_ITEM = 103;
        public const int MENU_DEFEND = 104;
        public const int MENU_ITEM_USED = 105;
        public const int MESSAGE_CONFIRMED = 106;
        public const int MESSAGE_CONFIRMED_FAIL = 107;

        public const int LEFT_CONTROL_X = 0;
        public const int LEFT_CONTROL_Y = 1; 
        public const int RIGHT_CONTROL_X = 2;
        public const int RIGHT_CONTROL_Y = 3;


        // Special keys gets special values!
        public const int KEY_EXIT = -10;


        public const int BUTTON_DELAY = 15;


        public const int ELEMENT_NONE = 0;
        public const int ELEMENT_PHYSICAL = 1;
        public const int ELEMENT_FIRE = 1 << 1;
        public const int ELEMENT_WATER = 1 << 2;
        public const int ELEMENT_NATURE = 1 << 3;

        public const int MAX_ELEMENT = 4;


        public const int VECTOR_X = 0;
        public const int VECTOR_Y = 1;
        public const int VECTOR_Z = 2;

        public const int QUEST_KILL = 1;
        public const int QUEST_EXPLORE = 2;
        public const int QUEST_COLLECT = 3;

        public const int ITEM_TYPE_EQUIP = 1;
        public const int ITEM_TYPE_CONSUMABLE = 2;
        public const int ITEM_TYPE_RUNE = 3;
        public const int ITEM_TYPE_OTHER = 4;

        public const int TYPE_CONSUMABLE_POTION = 1;
        public const int TYPE_CONSUMABLE_ETHER = 1 << 1;
        public const int TYPE_CONSUMABLE_FIRE = 1 << 2;
        public const int TYPE_CONSUMABLE_WATER = 1 << 3;
        public const int TYPE_CONSUMABLE_NATURE = 1 << 4;
        public const int TYPE_CONSUMABLE_PHYSICAL = 1 << 5;


        public const int DIFFICULTY_VERY_EASY = 1;
        public const int DIFFICULTY_EASY = 2;
        public const int DIFFICULTY_NORMAL = 3;
        public const int DIFFICULTY_HARD = 4;
        public const int DIFFICULTY_VERY_HARD = 5;
        public const int DIFFICULTY_INSANE = 6;

        // Item quality TYPICALLY corresponds to difficulty.
        // It is possible to go +1 though.
        public const int ITEM_QUALITY_TRASH = 0;
        public const int ITEM_QUALITY_COMMON = 1;
        public const int ITEM_QUALITY_UNCOMMON = 2;
        public const int ITEM_QUALITY_RARE = 3;
        public const int ITEM_QUALITY_MASTERWORK = 4;
        public const int ITEM_QUALITY_EPIC = 5;
        public const int ITEM_QUALITY_LEGENDARY = 6;
        public const int ITEM_QUALITY_MYTHICAL = 7;

        public const int MOB_WEAK = 0;
        public const int MOB_NORMAL = 1;
        public const int MOB_HARD = 2;
        public const int MOB_VERY_HARD = 3;
        public const int MOB_INSANE = 4;
        public const int MOB_BOSS = 5;
        public const int MOB_SPECIAL = 6;

        public const int WEARFLAG_WEAPON = 1;
        public const int WEARFLAG_CHEST = 1 << 1;
        public const int WEARFLAG_HEAD = 1 << 2;
        public const int WEARFLAG_LEGS = 1 << 3;
        public const int WEARFLAG_FEET = 1 << 4;
        public const int WEARFLAG_NONE = 1 << 5;

        public const int RUNE_HEAD = 0;
        public const int RUNE_RIGHT = 1;
        public const int RUNE_LEFT = 2;

        // Really just wearflag_head, but swiped for double rune use.
        public const int RUNEFLAG_HEAD = 1 << 2;

        public const int MONSTER_SLIMEMONSTER = 1;
        public const int MONSTER_MUTATED_RAT = 2;
        public const int MONSTER_MUTATED_TURTLE = 3;
        public const int MONSTER_EYEBALL = 4;
        public const int MONSTER_MUTATED_CROCODILE = 5;
        public const int MONSTER_SECURITY_DRONE = 6;

        public const int FORMATION_INTERN = 0;
        public const int FORMATION_DEFENSE = 1;
        public const int FORMATION_CASTER = 2;
        public const int FORMATION_OFFENSE = 3;

        public const int FONT_HEIGHT = 25;

        public static float wmod;
        public static float hmod;

        private static Random rand = new Random(DateTime.Now.Millisecond);

        public static string monsterToString(int monsterType)
        {
            switch (monsterType)
            {
                case MONSTER_EYEBALL:
                    return "Eyeball";
                case MONSTER_MUTATED_RAT:
                    return "Mutated Rat";
                case MONSTER_MUTATED_TURTLE:
                    return "Mutated Turtle";
                case MONSTER_MUTATED_CROCODILE:
                    return "Mutated Crocodile";
                default: return "SlimeMonster";
            }
        }

        public static int Random(int min, int max)
        {
            int temp = rand.Next(max - min);

            temp += min;

            return temp;
        }

        public static int SET_BIT(int field, int toSet)
        {
            return field | toSet;
        }

        public static bool IS_SET(int field, int toCheck)
        {
            return ((field & toCheck) == toCheck);
        }

        public static int REMOVE_BIT(int field, int toRemove)
        {
            return field & ~toRemove;
        }
    }
}
