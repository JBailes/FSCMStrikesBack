using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackDungeonGenerator
{
    public class MazeStructure : MazeStructureInterface
    {
        private int[,] mazeData;
        private int questTypeData;
        private int questTargetXData;
        private int questTargetYData;
        private int startTargetXData;
        private int startTargetYData;

        public int[,] maze() // Maze
        {
            return mazeData;
        }
        public int questType()
        {
            return questTypeData;
        }

        public int questTargetX() // Boss Location
        {
            return questTargetXData;
        }
        public int questTargetY()
        {
            return questTargetYData;
        }

        public int startTargetX() // Start Location
        {
            return startTargetXData;
        }
        public int startTargetY()
        {
            return startTargetYData;
        }

        private MazeStructure() { }
        public MazeStructure(int[,] maze, int questTypeData, int questTargetXData, int questTargetYData, int startTargetXData, int startTargetYData)
        {//                          map, questTypeData, questTargetXData, questTargetYData, startTargetXData, startTargetYData
            this.mazeData = maze;
            this.questTypeData = questTypeData;
            this.questTargetYData = questTargetYData;
            this.questTargetXData = questTargetXData;
            this.startTargetXData = startTargetXData;
            this.startTargetYData = startTargetYData;
        }
    }
}
