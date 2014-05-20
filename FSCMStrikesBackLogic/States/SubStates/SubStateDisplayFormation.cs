using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic
{
    class SubStateDisplayFormation : SubStateMenuAbstract
    {

        public SubStateDisplayFormation(StateAbstract parent, int formation)
            : base(parent)
        {

            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[4];
            menu = new string[4];

            menu = setFormation(formation);

            for (int i = 1; i < colors.Length; i++)
                colors[i] = Color.DarkGray;

            colors[0] = Color.White;

            mX = 130;
            mY = 40;
            width = 0;
            height = 0;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }

        private string[] setFormation(int formation)
        {
            string [] form = new string[4];
            if (formation == 0)//Intern
            {
                form[0] = FormationHandler.FormDescByValue(0);
                form[1] = ". . .";
                form[2] = "";
                form[3] = "";
            }
            else if (formation == 1)//defense
            {
                form[0] = FormationHandler.FormDescByValue(1);
                form[1] = ".";
                form[2] = ".";
                form[3] = ".";
            }
            else if (formation == 2)//caster
            {
                form[0] = FormationHandler.FormDescByValue(2);
                form[1] = " .";
                form[2] = ". .";
                form[3] = "";
            }
            else//offense
            {
                form[0] = FormationHandler.FormDescByValue(3);
                form[1] = ". .";
                form[2] = " .";
                form[3] = "";
            }

            return form;
        }

        public override void Input(int input)
        {
            parent.Input(input);
        }//end Input

    }
}
