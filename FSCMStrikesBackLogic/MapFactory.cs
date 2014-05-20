using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    static class MapFactory
    {
        public static int[,] map;
        public static float startX;
        public static float startY;

        internal static List<Actor> mapLoad(string toLoad)
        {
            switch (toLoad)
            {
                case "test": default:
                    int[,] temp = { {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 },
                                    {0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 },
                                    {0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 },
                                    {0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0 },
                                    {0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0 },
                                    {0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                                    {0, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0 },
                                    {0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
                                    {0, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                                    {0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
                                    {0, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0 },
                                    {0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                                    {0, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0 },
                                    {0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0 },
                                    {0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 },
                                    {0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 },
                                    {0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 10, 1, 0 },
                                    {0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }};

                    map = temp;
                    break;
            }

            return generateModels();
        }

        internal static List<Actor> GenerateNewMaze()
        {
            int mazeFlags = 7;
            MazeStructureInterface tempmap = FSCMStrikesBackDungeonGenerator.DungeonGenerator.generate(new CreateMaze(StateHandler.Level, StateHandler.Difficulty, mazeFlags));

            int[,] temp = tempmap.maze();

            map = new int[temp.GetLength(0)+2, temp.GetLength(1)+2];

            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || i == temp.GetLength(0) - 1 || j == temp.GetLength(1) - 1)
                        map[i, j] = Globals.TILE_UNPASSABLE;
                    else
                        map[i, j] = temp[(i - 1), (j - 1)];
                }
            }

            StateHandler.Quest = new QuestExplore((tempmap.questTargetX()+1), (tempmap.questTargetY()+1), null, tempmap.questType());

            map[tempmap.startTargetX(), tempmap.startTargetY()] = Globals.TILE_PASSABLE;

            startX = (float)((tempmap.startTargetX()*4)-2);
            startY = (float)((tempmap.startTargetY()*4)-2);

            return generateModels();
        }

        internal static List<Actor> GetCurrentMaze()
        {
            return generateModels();
        }

        internal static void updateTile(int x, int y, int tile)
        {
            map[x,y] = tile;
            generateModels();
        }

        private static List<Actor> generateModels()
        {
            List<Actor> actorList = null;

            if (map != null)
            {
                actorList = new List<Actor>();

                Actor temp;

                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        // Tile 1 - Stone, top bottom connect
                        // Tile 3 - Stone, left right connect
                        
                        // Tile 2 - Stone, corner
                        // Tile 4 - Stone, Top right?
                        // Tile 5 - Stone, corner, bottom right
                        // Tile 7 - Stone, corner
                        // Tile 8 - Stone, corner?

                        // Tile 6 - Unusable? No connections
                        temp = new Actor();
                        if (map[i, j] == FSCMInterfaces.Globals.TILE_UNPASSABLE)
                        {
                            temp.model = ModelFactory.loadModel("tile9");
                            temp.X = (j) * 4;
                            temp.Y = (i) * 4;
                            temp.Z = -26;
                            temp.Scale = 2.0f;
                            actorList.Add(temp);
                            temp = new Actor();
                            temp.model = ModelFactory.loadModel("TileDirt");
                        }
                        else if (map[i, j] == FSCMInterfaces.Globals.TILE_GRASS_CORNERL)
                        {
                            temp.model = ModelFactory.loadModel("grassWallCornerL");
                            temp.X = (j) * 4;
                            temp.Y = (i) * 4;
                            temp.Z = -26;
                            temp.Scale = 2.0f;
                            actorList.Add(temp);
                            temp = new Actor();
                            temp.model = ModelFactory.loadModel("TileDirt");
                        }
                        else if (map[i, j] == FSCMInterfaces.Globals.TILE_GRASS_CORNERR)
                        {
                            temp.model = ModelFactory.loadModel("grassWallCornerR");
                            temp.X = (j) * 4;
                            temp.Y = (i) * 4;
                            temp.Z = -26;
                            temp.Scale = 2.0f;
                            actorList.Add(temp);
                            temp = new Actor();
                            temp.model = ModelFactory.loadModel("TileDirt");
                        }
                        else if (map[i, j] == FSCMInterfaces.Globals.TILE_GRASS_CUBE)
                        {
                            temp.model = ModelFactory.loadModel("tile1");
                            temp.X = (j) * 4;
                            temp.Y = (i) * 4;
                            temp.Z = -26;
                            temp.Scale = 2.0f;
                            actorList.Add(temp);
                            temp = new Actor();
                            temp.model = ModelFactory.loadModel("TileDirt");
                        }
                        else if (map[i, j] == FSCMInterfaces.Globals.TILE_GRASS_ENDL)
                        {
                            temp.model = ModelFactory.loadModel("grassWallEndL");
                            temp.X = (j) * 4;
                            temp.Y = (i) * 4;
                            temp.Z = -26;
                            temp.Scale = 2.0f;
                            actorList.Add(temp);
                            temp = new Actor();
                            temp.model = ModelFactory.loadModel("TileDirt");
                        }
                        else if (map[i, j] == FSCMInterfaces.Globals.TILE_GRASS_ENDR)
                        {
                            temp.model = ModelFactory.loadModel("grassWallEndR");
                            temp.X = (j) * 4;
                            temp.Y = (i) * 4;
                            temp.Z = -26;
                            temp.Scale = 2.0f;
                            actorList.Add(temp);
                            temp = new Actor();
                            temp.model = ModelFactory.loadModel("TileDirt");
                        }
                        else if (map[i, j] == FSCMInterfaces.Globals.TILE_GRASS_WALL1)
                        {
                            temp.model = ModelFactory.loadModel("grassWall");
                            temp.X = (j) * 4;
                            temp.Y = (i) * 4;
                            temp.Z = -26;
                            temp.Scale = 2.0f;
                            actorList.Add(temp);
                            temp = new Actor();
                            temp.model = ModelFactory.loadModel("TileDirt");
                        }
                        else if (map[i, j] == FSCMInterfaces.Globals.TILE_GRASS_WALL2)
                        {
                            temp.model = ModelFactory.loadModel("grassWall2");
                            temp.X = (j) * 4;
                            temp.Y = (i) * 4;
                            temp.Z = -26;
                            temp.Scale = 2.0f;
                            actorList.Add(temp);
                            temp = new Actor();
                            temp.model = ModelFactory.loadModel("TileDirt");
                        }
                        else if (map[i, j] == FSCMInterfaces.Globals.TILE_EXIT)
                            temp.model = ModelFactory.loadModel("TileGrass");
                        else if (map[i, j] == FSCMInterfaces.Globals.TILE_PASSABLE)
                            temp.model = ModelFactory.loadModel("TileDirt");
                        else
                            temp.model = ModelFactory.loadModel("TileGrass");
                        temp.Scale = 2.0f;
                        temp.X = (j) * 4;
                        temp.Y = (i) * 4;
                        temp.Z = -30;
                        actorList.Add(temp);
                    }
                }
            }

            return actorList;
        }
    }
}
