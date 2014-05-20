using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
namespace FSCMStrikesBackDungeonGenerator
{
    public class StandardMazeSettings : MazeCreationInterface
    {
        public int Level { get; set; }
        public int Difficulty { get; set; }
        public int SpecialFlags {get;set;}

        public StandardMazeSettings(int level, int difficulty, int special)
        {
            this.Level = level;
            this.Difficulty = difficulty;
            this.SpecialFlags = special;
        }
        public StandardMazeSettings()
        {
            this.Level = 2;
            this.Difficulty = 2;
            this.SpecialFlags = 7;
        }
    }
}
