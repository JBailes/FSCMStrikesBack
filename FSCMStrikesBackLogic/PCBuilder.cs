using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMStrikesBackLogic
{

    // I'm not even certain that this is a builder anymore.
    // Factory? Builder? Who knows! After this many refactorings, it is what it is.
    static class PCBuilder
    {
        static string[] name = {"Bob", "Jane", "John"};
        static List<PC> pcList = new List<PC>();

        internal static PC getPC(string name)
        {
            foreach (PC pc in pcList)
            {
                if (pc.Name == name)
                    return pc;
            }

            PC temp = new PC();

            temp.Z = -22;
            temp.setLevel(1);
            temp.MaxHealth = 100;
            temp.Health = temp.MaxHealth;
            temp.setAttack(10);
            temp.setMagic(10);
            temp.setDefense(10);
            temp.setMagicDefense(10);
            temp.Scale = 1.0f;

            if (name == "Jane")
            {
                temp.Name = "Jane";
                temp.setTitle("The Honey Badger Woman");
                temp.model = ModelFactory.loadModel("bodyArcher");
                temp.setCombatLoc(40, 15, 15);
            }
            else if (name == "Bob")
            {
                temp.Name = "Bob";
                temp.setTitle("The Robert");
                temp.model = ModelFactory.loadModel("warior5");
                temp.setCombatLoc(5, 15, 20);
            }
            else if (name == "John")
            {
                temp.Name = "John";
                temp.setTitle("The Intern");
                temp.model = ModelFactory.loadModel("wizzard6");
                temp.setCombatLoc(30, 15, 10);
            }
            else
                return getPC("John");


            pcList.Add(temp);

            return temp;
        }

        internal static PC getPC(int id)
        {
            if (id >= name.Length)
                id = name.Length - 1;

            return getPC(name[id]);
        }

        internal static int getPcID(string target)
        {
            if (name[0] == target)
                return 0;

            if (name[1] == target)
                return 1;

            return 2;
        }
    }
}
