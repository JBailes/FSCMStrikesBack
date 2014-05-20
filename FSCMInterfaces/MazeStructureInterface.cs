using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMInterfaces
{
    public interface MazeStructureInterface
    {
        int[,] maze();
        int questType();
        int questTargetX();
        int questTargetY();
        int startTargetX();
        int startTargetY();
    }
}
