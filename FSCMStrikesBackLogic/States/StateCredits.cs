using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic
{
    class StateCredits : StateAbstract
    {
        MessageBoxInterface[] messageBoxes;
        int count;
        string[][] credits;

        public StateCredits()
        {
            MediaHandler.playBGM(FSCMStrikesBackLogic.Properties.Resources.creditbgm, "creditbgm");
            messageBoxes = new MessageBoxInterface[1];
            this.credits = new string[14][];
            this.credits[0] = new string[3];
            this.credits[0][0] = "             The";
            this.credits[0][1] = "FLYING SPAGHETTI CODE MONSTER";
            this.credits[0][2] = "        Strikes Back!";
            this.credits[1] = new string[2];
            this.credits[1][0] = "       By:";
            this.credits[1][1] = "Team Honey Badger";
            this.credits[2] = new string[3];
            this.credits[2][0] = "Project Lead:";
            this.credits[2][1] = "";
            this.credits[2][2] = "Jared Bailes";
            this.credits[3] = new string[6];
            this.credits[3][0] = "      Programming:";
            this.credits[3][1] = "";
            this.credits[3][2] = "      Jared Bailes";
            this.credits[3][3] = "John "+ (char) 34 +"The Intern" + (char) 34 + " Rowley";
            this.credits[3][4] = "     Jason Swannack";
            this.credits[3][5] = "      Mick Warren";
            this.credits[4] = new string[4];
            this.credits[4][0] = "  3D Art:";
            this.credits[4][1] = "";
            this.credits[4][2] = "David Mason";
            this.credits[4][3] = "Mick Warren";
            this.credits[5] = new string[5];
            this.credits[5][0] = "   2D Art:";
            this.credits[5][1] = "";
            this.credits[5][2] = "Jared Bailes";
            this.credits[5][3] = "Robert Sevin";
            this.credits[5][4] = "Mick Warren";
            this.credits[6] = new string[3];
            this.credits[6][0] = "    Sound:";
            this.credits[6][1] = "";
            this.credits[6][2] = "Jason Swannack";
            this.credits[7] = new string[4];
            this.credits[7][0] = "    Story:";
            this.credits[7][1] = "";
            this.credits[7][2] = " Robert Sevin";
            this.credits[7][3] = "Jason Swannack";
            this.credits[8] = new string[1];
            this.credits[8][0] = "    Special Thanks:";
            this.credits[9] = new string[3];
            this.credits[9][0] = "    Special Thanks:";
            this.credits[9][1] = "";
            this.credits[9][2] = "     Tom Capaul";
            this.credits[10] = new string[4];
            this.credits[10][0] = "    Special Thanks:";
            this.credits[10][1] = "";
            this.credits[10][2] = "    SoundJay.com";
            this.credits[10][3] = "    Kevin Macleod";
            this.credits[11] = new string[1];
            this.credits[11][0] = " Thanks";
            this.credits[12] = new string[2];
            this.credits[12][0] = " Thanks";
            this.credits[12][1] = "  For";
            this.credits[13] = new string[3];
            this.credits[13][0] = " Thanks";
            this.credits[13][1] = "  For";
            this.credits[13][2] = "Playing!";
        }

        public override void Update()
        {
            int mX, mY, width, height;
            count++;
            if (fresh)
            {
                fresh = false;
                MediaHandler.Background = "teamlogo.jpg";
            }

            Color[] colors;

            if (count < 260)
            {//title

                colors = new Color[3];

                colors[0] = Color.White;
                colors[1] = Color.White;
                colors[2] = Color.White;

                mX = 400;
                mY = 100;
                height = 100;
                width = 345;

                messageBoxes[0] = new MessageBox(mX, mY, width, height, credits[0], colors, true);
            }

            else if(count < 520)
            {//team

                mX = 250;
                mY = 250;
                height = 80;
                width = 210;

                colors = new Color[2];
                colors[0] = Color.White;
                colors[1] = Color.White;

                messageBoxes[0] = new MessageBox(mX, mY, width, height, credits[1], colors, true);
            }

            else if (count < 780)
            {//lead

                mX = 500;
                mY = 250;
                height = 100;
                width = 165;

                colors = new Color[3];
                colors[0] = Color.White;
                colors[1] = Color.White;
                colors[2] = Color.White;

                messageBoxes[0] = new MessageBox(mX, mY, width, height, credits[2], colors, true);
            }

            else if (count < 1040)
            {//programmers

                mX = 300;
                mY = 450;
                height = 175;
                width = 290;

                colors = new Color[6];
                colors[0] = Color.White;
                colors[1] = Color.White;
                colors[2] = Color.White;
                colors[3] = Color.White;
                colors[4] = Color.White;
                colors[5] = Color.White;

                messageBoxes[0] = new MessageBox(mX, mY, width, height, credits[3], colors, true);
            }

            else if (count < 1300)
            {//3D Art

                mX = 110;
                mY = 211;
                height = 120;
                width = 150;

                colors = new Color[4];
                colors[0] = Color.White;
                colors[1] = Color.White;
                colors[2] = Color.White;
                colors[3] = Color.White;

                messageBoxes[0] = new MessageBox(mX, mY, width, height, credits[4], colors, true);
            }

            else if (count < 1560)
            {//2D Art

                mX = 454;
                mY = 316;
                height = 140;
                width = 150;

                colors = new Color[5];
                colors[0] = Color.White;
                colors[1] = Color.White;
                colors[2] = Color.White;
                colors[3] = Color.White;
                colors[4] = Color.White;

                messageBoxes[0] = new MessageBox(mX, mY, width, height, credits[5], colors, true);
            }

            else if (count < 1820)
            {//Sound

                mX = 303;
                mY = 434;
                height = 90;
                width = 180;

                colors = new Color[3];
                colors[0] = Color.White;
                colors[1] = Color.White;
                colors[2] = Color.White;

                messageBoxes[0] = new MessageBox(mX, mY, width, height, credits[6], colors, true);
            }

            else if (count < 2080)
            {//Story

                mX = 601;
                mY = 430;
                height = 130;
                width = 170;

                colors = new Color[4];
                colors[0] = Color.White;
                colors[1] = Color.White;
                colors[2] = Color.White;
                colors[3] = Color.White;

                messageBoxes[0] = new MessageBox(mX, mY, width, height, credits[7], colors, true);
            }

            else if (count < 2140)
            {//Thanks1

                mX = 450;
                mY = 450;
                height = 120;
                width = 270;

                colors = new Color[1];
                colors[0] = Color.White;

                messageBoxes[0] = new MessageBox(mX, mY, width, height, credits[8], colors, true);
            }

            else if (count < 2400)
            {//Thanks2

                mX = 450;
                mY = 450;
                height = 120;
                width = 270;

                colors = new Color[3];
                colors[0] = Color.White;
                colors[1] = Color.White;
                colors[2] = Color.White;

                messageBoxes[0] = new MessageBox(mX, mY, width, height, credits[9], colors, true);
            }

            else if (count < 2680)
            {//Thanks3

                mX = 450;
                mY = 450;
                height = 120;
                width = 270;

                colors = new Color[4];
                colors[0] = Color.White;
                colors[1] = Color.White;
                colors[2] = Color.White;
                colors[3] = Color.White;

                messageBoxes[0] = new MessageBox(mX, mY, width, height, credits[10], colors, true);
                
            }
            else if (count < 2730)
            {//thanks for playing1
                mX = 500;
                mY = 500;
                height = 110;
                width = 110;

                colors = new Color[1];
                colors[0] = Color.White;

                messageBoxes[0] = new MessageBox(mX, mY, width, height, credits[11], colors, true);
            }
            else if (count < 2780)
            {//thanks for playing2
                mX = 500;
                mY = 500;
                height = 110;
                width = 110;

                colors = new Color[2];
                colors[0] = Color.White;
                colors[1] = Color.White;

                messageBoxes[0] = new MessageBox(mX, mY, width, height, credits[12], colors, true);
            }
            else if (count < 2940)
            {

                mX = 500;
                mY = 500;
                height = 110;
                width = 110;

                colors = new Color[3];
                colors[0] = Color.White;
                colors[1] = Color.White;
                colors[2] = Color.White;

                messageBoxes[0] = new MessageBox(mX, mY, width, height, credits[13], colors, true);
            }

            else
                StateHandler.State = new StateTitleScreen();

        }//end update
 
        public override MessageBoxInterface[] GetMessageBoxes
        {
            get
            {
                return messageBoxes;
            }

            set
            {
                messageBoxes = value;
            }
        }

        public override void Input(int input)
        {
            if (input != Globals.KEY_ACCEPT && input != Globals.KEY_EXIT)
            {
                StateHandler.AddDelay();
                StateHandler.State = new StateTitleScreen();
            }
        }

    }
}