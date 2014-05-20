using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMInterfaces
{
    public interface MazeCreationInterface
    {
        int Level { get; set; }
        int Difficulty { get; set; }
        int SpecialFlags { get; set; }
    }
}
