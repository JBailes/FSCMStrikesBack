using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic
{
    class SubStateMenuAbstract : SubStateMessageBox
    {
        protected int count = 0;
        protected Color[] colors;
        protected string[] menu;
        protected int mX;
        protected int mY;
        protected int height;
        protected int width;
        protected bool absolute = true;

        public SubStateMenuAbstract(StateAbstract parent)
            : base(parent)
        {
        }

        public override void Input(int input)
        {
            if (input == Globals.KEY_UP || input == Globals.KEY_DOWN)
            {
                MediaHandler.playSFX(FSCMStrikesBackLogic.Properties.Resources.menuMove, "menuMove");

                StateHandler.SetDelay(8);

                colors[count] = Color.DarkGray;

                if (input == Globals.KEY_UP)
                {
                    if (count == 0)
                        count = menu.Length-1;
                    else
                        count--;
                }
                else if (input == Globals.KEY_DOWN)
                    count = (count + 1) % menu.Length;

                colors[count] = Color.White;

                int tempVal = (int)(Globals.hmod * height);

                tempVal /= Globals.FONT_HEIGHT;

                tempVal -= 1;

                Color[] tempColor = null;
                string[] tempMenu = null;
                int prefCount = tempVal / 2;

                if (tempVal >= menu.Length || absolute) // The total amount of options is less than the size of the menu box
                {
                    tempColor = colors;
                    tempMenu = menu;
                }
                else
                {
                    int realCount;
                    tempMenu = new string[tempVal];

                    if (prefCount > count)
                    {
                        realCount = count;
                        for (int i = 0; i < tempVal; i++)
                        {
                            tempMenu[i] = menu[i];
                        }
                    }
                    else if (prefCount >= menu.Length - count)
                    {
                        realCount = count - (menu.Length - tempVal);
                        // Menu from menu-tval to menu)
                        for (int i = 0; i < tempVal; i++)
                            tempMenu[i] = menu[(menu.Length - tempVal) + i];
                    }
                    else
                    {
                        realCount = tempVal / 2;
                        for (int i = 0; i < tempVal; i++)
                            tempMenu[i] = menu[(count-prefCount) + i];
                    }

                    tempColor = new Color[tempVal];

                    for (int i = 0; i < tempVal; i++)
                        tempColor[i] = Color.DarkGray;

                    tempColor[realCount] = Color.White;
                }

                messageBoxes[0] = new MessageBox(mX, mY, width, height, tempMenu, tempColor, true, messageBoxes[0].Scaling(), messageBoxes[0].IsChildMessage());
            }
            else if (input == Globals.KEY_CANCEL)
            {
                StateHandler.AddDelay();
                MediaHandler.playSFX(FSCMStrikesBackLogic.Properties.Resources.menuBack, "menuBack");

                StateHandler.State = Parent;
            }
        }

        public override void Update()
        {
        }

        public override bool focusTarget()
        {
            return true;
        }

        public override float X
        {
            get { return Parent.X; }
            set { Parent.X = value; }
        }

        public override float Y
        {
            get { return Parent.Y; }
            set { Parent.Y = value; }
        }

        public override float Z
        {
            get { return Parent.Z; }
            set { Parent.Z = value; }
        }

        public override float RotationX
        {
            get { return Parent.RotationX; }
            set { Parent.RotationX = value; }
        }

        public override float RotationY
        {
            get { return Parent.RotationY; }
            set { Parent.RotationY = value; }
        }

        public override float RotationZ
        {
            get { return Parent.RotationZ; }
            set { Parent.RotationZ = value; }
        }

        public override float TargetX
        {
            get
            {
                if (Parent.CameraTarget == null)
                    return 5;
                else
                    return Parent.CameraTarget.X;
            }
        }

        public override float TargetY
        {
            get
            {
                if (Parent.CameraTarget == null)
                    return 5;
                else
                    return Parent.CameraTarget.Y;
            }
        }

        public override float TargetZ
        {
            get
            {
                if (Parent.CameraTarget == null)
                    return 5;
                else
                    return Parent.CameraTarget.Z;
            }
        }

        internal override Actor CameraTarget
        {
            get { return Parent.CameraTarget; }
            set { Parent.CameraTarget = value; }
        }

        public override void ParentInput(int input)
        {
            if (input == Globals.MESSAGE_CONFIRMED)
            {
                StateHandler.State = parent;
                parent.ParentInput(Globals.MENU_ITEM_USED);
                parent.ParentInput(Globals.MESSAGE_CONFIRMED);
            }
        }
    }
}
