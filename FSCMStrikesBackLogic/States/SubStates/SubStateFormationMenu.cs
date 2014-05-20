using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic
{
    class SubStateFormationMenu : SubStateMenuAbstract
    {
        public SubStateFormationMenu (SubStateAbstract theparent)
            : base(theparent)
        {
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[4];
            menu = new string[4];

            menu[0] = "The Intern";
            menu[1] = "Defense";
            menu[2] = "Caster";
            menu[3] = "Offense";

            for (int i = 1; i < colors.Length; i++)
                colors[i] = Color.DarkGray;
            colors[0] = Color.White;

            mX = 30;
            mY = 30;
            width = 960;
            height = 690;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }//end EVC

        public override void Input(int input)
        {
            base.Input(input);
            StateHandler.AddDelay();
            if (input == Globals.KEY_ACCEPT)
            {
                FormationHandler.Formation = count;
                StateHandler.State = parent;
            }
            else if (input == Globals.KEY_CANCEL)
                StateHandler.State = parent;
            else
                StateHandler.State = new SubStateDisplayFormation(this, count);
        }//end input
    }
}
