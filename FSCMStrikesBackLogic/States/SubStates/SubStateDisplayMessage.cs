using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class SubStateDisplayMessage : SubStateMessageBox
    {
        protected Color[] colors;
        protected int[] size;
        protected int mX;
        protected int mY;
        protected int height;
        protected int width;

        public SubStateDisplayMessage(string[] toDisplay, int Height, int Width, int X, int Y, StateAbstract parent) : base(parent)
        {
            mX = X;
            mY = Y;
            height = Height;
            width = Width;
            messageBoxes = new MessageBox[1];
            size = new int[toDisplay.Length];
            colors = new Color[toDisplay.Length];

            for (int i = 0; i < toDisplay.Length; i++)
            {
                size[i] = 16;
                colors[i] = Color.White;
            }

            messageBoxes[0] = new MessageBox(mX, mY, width, height, toDisplay, colors, true);
        }

        public SubStateDisplayMessage(MessageBoxInterface message, StateAbstract parent) : base(parent)
        {
            messageBoxes[0] = message;
        }

        public override void Input(int input)
        {
            if (input == Globals.KEY_ACCEPT)
            {
                StateHandler.AddDelay();
                StateHandler.State = Parent;
            }

            parent.Input(input);
        }

        public override void Update()
        {
        }

        internal override Actor CameraTarget
        {
            get { return Parent.CameraTarget; }
            set { }
        }
    }
}
