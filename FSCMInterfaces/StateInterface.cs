using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMInterfaces
{
    public interface StateInterface
    {
        void Update();
        void Input(int input);
        void Input(float input, int target);
        void ParentInput(int input);
        MessageBoxInterface[] GetMessageBoxes{ get; set; }

        bool focusTarget();
        float X { get; set; }
        float Y { get; set; }
        float Z { get; set; }
        float RotationX { get; set; }
        float RotationY { get; set; }
        float RotationZ { get; set; }
        float TargetX { get; }
        float TargetY { get; }
        float TargetZ { get; }
    }
}
