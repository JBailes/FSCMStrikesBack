using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic
{
    public class MessageBox : MessageBoxInterface
    {
        int y, x, width, height;
        string[] toDisplay;
        bool background;
        Color[] color;
        bool scaling;
        bool IsChild;

        public MessageBox(int setX, int setY, int setWidth, int setHeight, string[] setDisplay, Color[] setColor, bool setBackground)
        {
            x = setX;
            y = setY;
            width = setWidth;
            height = setHeight;
            toDisplay = setDisplay;
            background = setBackground;
            color = setColor;
        }

        public MessageBox(int setX, int setY, int setWidth, int setHeight, string[] setDisplay, Color[] setColor, bool setBackground, bool scale)
        {
            x = setX;
            y = setY;
            width = setWidth;
            height = setHeight;
            toDisplay = setDisplay;
            background = setBackground;
            color = setColor;
            scaling = scale;
        }

        public MessageBox(int setX, int setY, int setWidth, int setHeight, string[] setDisplay, Color[] setColor, bool setBackground, bool scale, bool child)
        {
            x = setX;
            y = setY;
            width = setWidth;
            height = setHeight;
            toDisplay = setDisplay;
            background = setBackground;
            color = setColor;
            scaling = scale;
            IsChild = child;
        }

        public int X()
        {
            return x;
        }

        public int Y()
        {
            return y;
        }

        public int Width()
        {
            return width;
        }

        public int Height()
        {
            return height;
        }

        public string[] stringToDisplay()
        {
            return toDisplay;
        }

        public bool boxBackground()
        {
            return background;
        }

        public Color[] Color()
        {
            return color;
        }

        public bool Scaling()
        {
            return scaling;
        }

        public bool IsChildMessage()
        {
            return IsChild;
        }
    }
}
