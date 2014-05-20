using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class SubStateConfirmMessage : SubStateDisplayMessage
    {
        public SubStateConfirmMessage(string[] toDisplay, int Height, int Width, int X, int Y, StateAbstract parent)
            : base(toDisplay, Height, Width, X, Y, parent)
        {
        }

        public override void Input(int input)
        {
            if (StateHandler.GetDelay() > 0)
                return;

            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();

                if (parent != null)
                    Parent.ParentInput(Globals.MESSAGE_CONFIRMED);
            }
        }

        public override void ParentInput(int input)
        {
            if (input == Globals.KEY_ACCEPT || input == Globals.MESSAGE_CONFIRMED)
            {
                StateHandler.AddDelay();
                StateHandler.State = this;
            }

            Parent.ParentInput(input);
        }

        internal override Actor CameraTarget
        {
            get { return Parent.CameraTarget; }
            set { Parent.CameraTarget = value; }
        }
    }
}
