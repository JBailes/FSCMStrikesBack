using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSCMInterfaces;

namespace FSCMStrikesBackDungeonGenerator
{
    public class Vector2d
    {
        public int x { get; set; }
        public int y { get; set; }
        public Vector2d(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        private Vector2d() { }
    }

    public static class DungeonGenerator
    {
        static Random rnd;

        public static MazeStructure generate(MazeCreationInterface mz)
        {
            int[,] map = GenerateDungeon(mz.Level,mz.Difficulty,7);

            for (int j = 0; j < map.GetLength(0); j++)
                for (int k = 0; k < map.GetLength(1); k++)
                    map[j, k] = (map[j, k]==0)?Globals.TILE_PASSABLE:Globals.TILE_UNPASSABLE;
            
            Vector2d[] portals = InitializePortals(map);
            
            int questTargetXData = portals[1].x;
            int questTargetYData = portals[1].y;

            int startTargetXData = portals[0].x;
            int startTargetYData = portals[0].y;

            int questTypeData = 0;

            map[questTargetXData, questTargetYData] = Globals.TILE_EXIT;

            MazeStructure structure = new MazeStructure(map, questTypeData, questTargetXData, questTargetYData, startTargetXData, startTargetYData);
            
            return structure;
        }

        private static Vector2d[] InitializePortals(int[,] maze){
            Vector2d[] portals = new Vector2d[2];
            int sideA = rnd.Next(3);
            int xIter = rnd.Next(maze.GetLength(0) - 4)+3;
            int yIter = rnd.Next(maze.GetLength(1) - 4)+3;

            while (maze[xIter, yIter] != 0)
            {
                xIter = rnd.Next(maze.GetLength(0) - 4)+3;
                yIter = rnd.Next(maze.GetLength(1) - 4)+3;
            }

            portals[0] = new Vector2d(xIter, yIter);
            xIter = rnd.Next(maze.GetLength(0) - 4)+3;
            yIter = rnd.Next(maze.GetLength(1) - 4)+3;

            while (maze[xIter, yIter] != 0)
            {
                xIter = rnd.Next(maze.GetLength(0) - 4) +3;
                yIter = rnd.Next(maze.GetLength(1) - 4) +3;
            }

            portals[1] = new Vector2d(xIter, yIter);
            return portals;
        }


        private static int[,] GenerateDungeon(int level, int difficulty, int mode)
        {
            int directionMode, sizeMode, distance = 2;
            if ((1 & mode) != 0)
            {
                sizeMode = 1;
            }
            else
            {
                sizeMode = 0;
            }
            if ((6 & mode) != 0)
            {
                directionMode = 2;
            }
            else if ((4 & mode) != 0)
            {
                directionMode = 1;
            }
            else if ((2 & mode) != 0)
            {
                directionMode = 0;
            }
            else
            {
                throw new Exception("Invalid dungeon generation bitflag");
            }

            int width = 13 * ((level) + (difficulty));
            int height = 13 * ((level) + (difficulty));

            int[,] map = GenerateDungeon(width, height, sizeMode, directionMode, distance);
            int[,] outlinemap = new int[map.GetLength(0), map.GetLength(1)];

            for (int x = 0; x < map.GetLength(0); x++)
                for (int y = 0; y < map.GetLength(1); y++)
                    outlinemap[x, y] = map[x, y];

            for (int i = 0; i < outlinemap.GetLength(1); i++)
            {
                outlinemap[0, i] = 1;
                outlinemap[outlinemap.GetLength(0) - 1, i] = 1;
            }
            for (int i = 0; i < map.GetLength(0); i++)
            {
                outlinemap[i, 0] = 1;
                outlinemap[i, outlinemap.GetLength(1) - 1] = 1;
            }
            return outlinemap;
        }

        private static int[,] GenerateDungeon(int width, int height, int sizeMode, int directionMode, int distance)
        {
            return GenerateStandardDungeon(width, height, directionMode, distance);
            /*switch (sizeMode)
            {
                case 1:
                    return GenerateStandardDungeon(width, height, directionMode, distance);
                case 0:
                    return GenerateWideDungeon(width, height, directionMode, distance);
                default:
                    throw new Exception("Invalid SizeMode Bitflag");
            }*/
        }

        /*

            # maze is a m x n array
            def canBeTraversed(maze):
              m = len(maze)
              n = len(maze[0])

              colored = [ [ False for i in range(0,n) ] for j in range(0,m) ]

              open = [(0,0),]

              while len(open) != 0:
                (x,y) = open.pop()
                if x == m-1 and y == n-1:
                  return True
                elif x < m and y < n and maze[x][y] != 0 not colored[x][y]:
                  colored[x][y] = True
                  open.extend([(x-1,y), (x,y-1), (x+1,y), (x,y+1)])

              return False

        */

        private static int[,] GenerateWideDungeon(int width, int height, int directionMode, int distance)
        {
            int[,] baseMap = GenerateStandardDungeon(width / 2, height / 2, directionMode, distance);
            int[,] resultMap = new int[2 * baseMap.GetLength(0), 2 * baseMap.GetLength(1)];

            for (int y = 0; y < baseMap.GetLength(1); y++)
            {
                for (int x = 0; x < baseMap.GetLength(0); x++)
                {
                    resultMap[2 * x, 2 * y] = baseMap[x, y];
                    resultMap[2 * x + 1, 2 * y] = baseMap[x, y];
                    resultMap[2 * x, 2 * y + 1] = baseMap[x, y];
                    resultMap[2 * x + 1, 2 * y + 1] = baseMap[x, y];
                }
            }

            return resultMap;
        }

        private static int[,] GenerateStandardDungeon(int width, int height, int directionMode, int distance)
        {
            rnd = new Random(DateTime.Now.Millisecond);
            // Possibly Replace with Seed


            int[,] maze = new int[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                    maze[i, j] = 1;
            }

            int c = rnd.Next(height);
            while (c % 2 == 0)
                c = rnd.Next(height);

            int r = rnd.Next(width);
            while (r % 2 == 0)
                r = rnd.Next(width);

            maze[r, c] = 0;

            RecursiveGeneration(r, c, maze, directionMode, distance);

            return maze;
        }

        /*
         *  r = X || width
         *  c = Y || height
         */
        static void RecursiveGeneration(int x, int y, int[,] maze, int directionMode, int distance)
        {
            int[] RandomDirections = GenerateRandomDirections(directionMode);
            for (int i = 0; i < RandomDirections.Length; i++)
            {
                switch (RandomDirections[i])
                {
                    case 1: // Left
                        if (!isValidCell(maze,x,y,RandomDirections[i],distance))
                            continue;
                        if (maze[x - distance, y] != 0)
                        {
                            SetCells(maze, x, y, RandomDirections[i], distance);
                            RecursiveGeneration(x - 2, y, maze, directionMode, distance);
                        }
                        break;
                    case 2: // Right
                        if (!isValidCell(maze, x, y, RandomDirections[i], distance))
                            continue;
                        if (maze[x + distance, y] != 0)
                        {
                            SetCells(maze, x, y, RandomDirections[i], distance);
                            RecursiveGeneration(x + 2, y, maze, directionMode, distance);
                        }
                        break;
                    case 3: // Up
                        if (!isValidCell(maze, x, y, RandomDirections[i], distance))
                            continue;
                        if (maze[x, y - 2] != 0)
                        {
                            SetCells(maze, x, y, RandomDirections[i], distance);
                            RecursiveGeneration(x, y - 2, maze, directionMode, distance);
                        }
                        break;
                    case 4: // Down
                        if (!isValidCell(maze, x, y, RandomDirections[i], distance))
                            continue;
                        if (maze[x, y + 2] != 0)
                        {
                            SetCells(maze, x, y, RandomDirections[i], distance);
                            RecursiveGeneration(x, y + 2, maze, directionMode, distance);
                        }
                        break;
                    case 5: // Up-Left
                        if (!isValidCell(maze, x, y, RandomDirections[i], distance))
                            continue;
                        if (maze[x - 2, y - 2] != 0 && maze[x - 1, y - 1] != 0)
                        {
                            SetCells(maze, x, y, RandomDirections[i], distance);
                            /*maze[x - 2, y - 2] = 0;
                            maze[x - 2, y - 1] = 0;
                            maze[x - 1, y - 1] = 0;
                            maze[x - 1, y - 2] = 0;*/
                            RecursiveGeneration(x - 2, y - 2, maze, directionMode, distance);
                        }
                        break;
                    case 6: // Up-Right
                        if (!isValidCell(maze, x, y, RandomDirections[i], distance))
                            continue;
                        if (maze[x + 2, y - 2] != 0 && maze[x + 1, y - 1] != 0)
                        {
                            SetCells(maze, x, y, RandomDirections[i], distance);
                            /*maze[x + 2, y - 2] = 0;
                            maze[x + 2, y - 1] = 0;
                            maze[x + 1, y - 1] = 0;
                            maze[x + 1, y - 2] = 0;*/
                            RecursiveGeneration(x + 2, y - 2, maze, directionMode, distance);
                        }
                        break;
                    case 7: // Down-Left
                        if (!isValidCell(maze, x, y, RandomDirections[i], distance))
                            continue;
                        if (maze[x - 2, y + 2] == 0 && maze[x - 1, y + 1] != 0)
                        {
                            SetCells(maze, x, y, RandomDirections[i], distance);
                            /*maze[x - 2, y + 2] = 0;
                            maze[x - 2, y + 1] = 0;
                            maze[x - 1, y + 1] = 0;
                            maze[x - 1, y + 2] = 0;*/
                            RecursiveGeneration(x - 2, y + 2, maze, directionMode, distance);
                        }
                        break;
                    case 8: // Down-Right
                        if (!isValidCell(maze, x, y, RandomDirections[i], distance))
                            continue;
                        if (maze[x + 2, y + 2] == 0 && maze[x + 1, y + 1] != 0)
                        {
                            SetCells(maze, x, y, RandomDirections[i], distance);
                            /*maze[x + 2, y + 2] = 0;
                            maze[x + 2, y + 1] = 0;
                            maze[x + 1, y + 1] = 0;
                            maze[x + 1, y + 2] = 0;*/
                            RecursiveGeneration(x + 2, y + 2, maze, directionMode, distance);
                        }
                        break;
                }
            }
        }

        static int[] GenerateRandomDirections(int mode)
        {
            int min, max;
            if (mode == 0)
            {
                min = 0;
                max = 3;
            }
            else if (mode == 1)
            {
                min = 4;
                max = 7;
            }
            else if (mode == 2)
            {
                min = 0;
                max = 7;
            }
            else
            {
                throw new Exception("Invalid Direction Mode");
            }

            List<int> Randoms = new List<int>();
            for (int i = min; i < max; i++)
            {
                Randoms.Add(i);
            }
            ShuffleList<int>(Randoms);
            return Randoms.ToArray<int>();
        }

        // Implementation of Fisher-Yates Shuffle
        public static void ShuffleList<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        static bool isValidCell(int[,] maze, int x, int y, int direction, int distance)
        {
            if (direction == 1)
            {
                if (x - 2 < 0)
                    return false;
            }
            else if (direction == 2)
            {
                if (x + 2 >= maze.GetLength(0))
                    return false;
            }
            else if (direction == 3)
            {
                if (y - 2 < 0)
                    return false;
            }
            else if (direction == 4)
            {
                if (y + 2 >= maze.GetLength(1))
                    return false;
            }
            else if (direction == 5)
            {
                if (x - 2 < 0 || y - 2 < 0)
                    return false;
            }
            else if (direction == 6)
            {
                if (x + 2 >= maze.GetLength(0) || y - 2 < 0)
                    return false;
            }
            else if (direction == 7)
            {
                if (x - 2 < 0 || y + 2 >= maze.GetLength(1))
                    return false;
            }
            else if (direction == 8)
            {
                if (x + 2 >= maze.GetLength(0) || y + 2 >= maze.GetLength(1))
                    return false;
            }

            return true;
        }


        static void SetCells(int[,] maze, int x, int y, int direction, int distance)
        {
            for (int i = 1; i <= distance; i++)
            {
                if (direction == 1)
                {
                    maze[x - i, y] = 0;
                }
                else if (direction == 2)
                {
                    maze[x + i, y] = 0;
                }
                else if (direction == 3)
                {
                    maze[x, y - i] = 0;
                }
                else if (direction == 4)
                {
                    maze[x, y + i] = 0;
                }
                else if (direction == 5)
                {
                    maze[x - i, y - i] = 0;
                    maze[x - i, y - i + 1] = 0;
                    maze[x - i + 1, y - i + 1] = 0;
                    maze[x - i + 1, y - i] = 0;
                }
                else if (direction == 6)
                {
                    maze[x + i, y - i] = 0;
                    maze[x + i, y - i + 1] = 0;
                    maze[x + i - 1, y - i + 1] = 0;
                    maze[x + i - 1, y - i] = 0;
                }
                else if (direction == 7)
                {
                    maze[x - i, y + i] = 0;
                    maze[x - i, y + i - 1] = 0;
                    maze[x - i + 1, y + i - 1] = 0;
                    maze[x - i + 1, y + i] = 0;
                }
                else if (direction == 8)
                {
                    maze[x - i, y - i] = 0;
                    maze[x - i, y - i - 1] = 0;
                    maze[x - i - 1, y - i] = 0;
                    maze[x - i - 1, y - i - 1] = 0;
                }
                else
                {
                    //throw new Exception("Invalid Direction");
                }
            }
        }
    }
}