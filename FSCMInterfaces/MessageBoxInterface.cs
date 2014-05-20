using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FSCMInterfaces
{
    public interface MessageBoxInterface
    {
        string[] stringToDisplay();
        Color[] Color();
        int X();
        int Y();
        int Height();
        int Width();
        bool boxBackground();
        bool Scaling();
        bool IsChildMessage();
    }
}
