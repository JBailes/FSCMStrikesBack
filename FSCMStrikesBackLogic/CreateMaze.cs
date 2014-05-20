using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class CreateMaze : MazeCreationInterface
    {
        int level;
        int difficulty;
        int specialflags;

        public CreateMaze(int lvl, int diff, int special)
        {
            level = lvl;
            difficulty = diff;
            specialflags = special;
        }

        public CreateMaze()
        {
            level = PCBuilder.getPC(0).getLevel();
            difficulty = StateHandler.Difficulty;
            specialflags = 0;
        }

        public int Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public int SpecialFlags
        {
            get { return specialflags; }
            set { specialflags = value; }
        }
    }
}
