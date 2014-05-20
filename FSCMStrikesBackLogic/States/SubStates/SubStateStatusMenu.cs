using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class SubStateStatusMenu : SubStateMenuAbstract
    {

        public SubStateStatusMenu(StateAbstract parent)
            : base(parent)
        {
            StateHandler.AddDelay();
            messageBoxes = new MessageBox[1];
            colors = new Color[31];
            menu = new string[colors.Length];

            PC temp = null;
            for (int i = 0; i < 29; i += 10)
            {
                temp = StateHandler.GetPC(i / 10);
                menu[i] = temp.Name + " " + temp.getTitle();
                menu[i + 1] = temp.getExp() + @"/" + (temp.getLevel() * 1000);
                menu[i + 2] = "Level: " + temp.getLevel();
                menu[i + 3] = "Health: " + temp.Health + "/" + temp.MaxHealth;
                menu[i + 4] = "MP: " + temp.Mp + "/" + temp.MaxMp;
                menu[i + 5] = "Attack: " + temp.getAttack();
                menu[i + 6] = "Defense: " + temp.getDefense();
                menu[i + 7] = "Magic: " + temp.getMagic();
                menu[i + 8] = "Magic Defense: " + temp.getMagicDefense();
                menu[i + 9] = "";
            }
            menu[30] = "Formation: " + FormationHandler.FormName;

            for (int i = 0; i < colors.Length; i++)
                colors[i] = Color.White;

            mX = 30;
            mY = 30;
            width = 960;
            height = 690;

            messageBoxes[0] = new MessageBox(mX, mY, width, height, menu, colors, true, true);
        }

        public override void Input(int input)
        {
            
            if (input == Globals.KEY_CANCEL || input == Globals.KEY_ACCEPT)
            {
                base.Input(input);
                StateHandler.AddDelay();
                StateHandler.State = Parent;
            }
        }

    }
}
