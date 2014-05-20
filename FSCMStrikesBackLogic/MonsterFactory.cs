using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    internal class MonsterFactory
    {
        internal static Monster randomMonster(int level, int element, int specials, bool boss)
        {
            int choice = Globals.Random(1, 60);
            choice /= 10;

            if (specials == Globals.MOB_WEAK)
            {
                int chance = Globals.Random(1, 100);

                if (level > 5)
                    specials = Globals.MOB_INSANE;
                else if (level > 4)
                    specials = Globals.MOB_VERY_HARD;
                else if (level > 3)
                    specials = Globals.MOB_HARD;
                else if (level > 2)
                    specials = Globals.MOB_NORMAL;
                else
                    specials = Globals.MOB_WEAK;

                if (chance < 33)
                    specials--;
                else if (chance > 66)
                    specials++;

                if (boss)
                    specials++;

                if (specials < Globals.MOB_WEAK)
                    specials = Globals.MOB_WEAK;
                if (specials > Globals.MOB_SPECIAL)
                    specials = Globals.MOB_SPECIAL;
            }

            switch (choice)
            {
                case 0:
                    //return generateMonster("Eyeball", level, element, specials);
                    return generateMonster("MutatedRat", level, element, specials, boss);
                case 1:
                    //return generateMonster("MutatedCroc", level, element, specials);
                    return generateMonster("MutatedRat", level, element, specials, boss);
                case 2:
                    return generateMonster("MutatedRat", level, element, specials, boss);
                case 3:
                    //return generateMonster("MutatedTurtle", level, element, specials);
                    return generateMonster("Drone", level, element, specials, boss);
                case 4:
                    return generateMonster("Drone", level, element, specials, boss);
                default:
                    return generateMonster("SlimeMonster", level, element, specials, boss);
            }
        }

        private static Monster generateMonster(string name, int level, int element, int specials, bool boss)
        {
            Monster monster = new Monster();

            monster.Quality = specials;

            switch(name)
            {
                case "Eyeball":
                    monster.model = ModelFactory.loadModel("Eyeball");
                    monster.Name = "Eyeball";
                    monster.MaxHealth = 100 * level;
                    monster.Health = monster.MaxHealth;
                    monster.Element = Globals.ELEMENT_FIRE;
                    monster.setLevel(level);
                    monster.setAttack(level * 2);
                    monster.setDefense(level * 2);
                    monster.setMagic(level * 2);
                    monster.setMagicDefense(level * 2);
                    monster.Type = Globals.MONSTER_EYEBALL;
                    monster.SetBehavior(new BehaviorBasicFire());
                    break;
                case "MutatedCroc":
                case "Mutated Croc":
                case "MutatedCrocodile":
                case "Mutated Crocodile":
                    monster.model = ModelFactory.loadModel("MutatedCrocodile");
                    monster.Name = "Mutated Crocodile";
                    monster.MaxHealth = 100 * level;
                    monster.Health = monster.MaxHealth;
                    monster.Element = Globals.ELEMENT_WATER;
                    monster.setLevel(level);
                    monster.setAttack(level * 2);
                    monster.setDefense(level * 2);
                    monster.setMagic(level * 2);
                    monster.setMagicDefense(level * 2);
                    monster.Type = Globals.MONSTER_MUTATED_CROCODILE;
                    monster.SetBehavior(new BehaviorBasicWater());
                    break;
                case "MutatedRat": 
                case "Mutated Rat":
                    monster.Name = "Daisy";
                    monster.model = ModelFactory.loadModel("mutantRat34blend");                    
                    monster.MaxHealth = 100 * level;
                    monster.Health = monster.MaxHealth;
                    monster.Element = Globals.ELEMENT_NATURE;
                    monster.setLevel( level );
                    monster.setAttack(level * 2);
                    monster.setDefense(level * 2);
                    monster.setMagic(level * 2);
                    monster.setMagicDefense(level * 2);
                    monster.Type = Globals.MONSTER_MUTATED_RAT;
                    monster.SetBehavior(new BehaviorBasicNature());
                    break;
                case "MutatedTurtle": 
                case "Mutated Turtle":
                    monster.model = ModelFactory.loadModel("MutatedTurtle");
                    monster.Name = "Mutated Turtle";
                    monster.MaxHealth = 100 * level;
                    monster.Health = monster.MaxHealth;
                    monster.Element = Globals.ELEMENT_WATER;
                    monster.setLevel(level);
                    monster.setAttack(level * 2);
                    monster.setDefense(level * 2);
                    monster.setMagic(level * 2);
                    monster.setMagicDefense(level * 2);
                    monster.Type = Globals.MONSTER_MUTATED_TURTLE;
                    monster.SetBehavior(new BehaviorBasicWater());
                    break;
                case "Drone":
                case "SecurityDrone":
                    monster.model = ModelFactory.loadModel("securityDrone");
                    monster.Name = "Security Drone";
                    monster.MaxHealth = 100 * level;
                    monster.Health = monster.MaxHealth;
                    monster.Element = Globals.ELEMENT_PHYSICAL;
                    monster.setLevel(level);
                    monster.setAttack(level * 2);
                    monster.setDefense(level * 2);
                    monster.setMagic(level * 2);
                    monster.setMagicDefense(level * 2);
                    monster.Type = Globals.MONSTER_SECURITY_DRONE;
                    monster.SetBehavior(new BehaviorAttack());
                    break;
                case "SlimeMonster": 
                case "MonsterSlime":
                default:
                    monster.model = ModelFactory.loadModel("MonsterSlime");
                    monster.Name = "Slime Monster";
                    monster.MaxHealth = 100 * level;
                    monster.Health = monster.MaxHealth;
                    monster.Element = Globals.ELEMENT_WATER;
                    monster.setLevel( level );
                    monster.setAttack(level * 2);
                    monster.setDefense(level * 2);
                    monster.setMagic(level * 2);
                    monster.setMagicDefense(level * 2);
                    monster.Type = Globals.MONSTER_SLIMEMONSTER;
                    monster.SetBehavior(new BehaviorBasicWater());
                    break;
            }

            monster.Quality = specials;

            switch (specials)
            {
                case Globals.MOB_WEAK:
                    monster.Scale *= 0.75f;
                    monster.MaxHealth = monster.MaxHealth / 2;
                    monster.Health = monster.MaxHealth;
                    monster.setAttack(monster.getAttack() / 2);
                    monster.setDefense(monster.getDefense() / 2);
                    monster.setMagic(monster.getMagic() / 2);
                    monster.setMagicDefense(monster.getMagicDefense() / 2);
                    break;
                case Globals.MOB_NORMAL:
                    monster.Scale *= 1.25f;
                    break;
                case Globals.MOB_HARD:
                    monster.Scale *= 1.5f;
                    monster.MaxHealth = monster.MaxHealth * 2;
                    monster.Health = monster.MaxHealth;
                    monster.setAttack(monster.getAttack() * 2);
                    monster.setDefense(monster.getDefense() * 2);
                    monster.setMagic(monster.getMagic() * 2);
                    monster.setMagicDefense(monster.getMagicDefense() * 2);
                    break;
                case Globals.MOB_INSANE:
                    monster.Scale *= 2.5f;
                    monster.MaxHealth = monster.MaxHealth * 3;
                    monster.Health = monster.MaxHealth;
                    monster.setAttack(monster.getAttack() * 3);
                    monster.setDefense(monster.getDefense() * 3);
                    monster.setMagic(monster.getMagic() * 3);
                    monster.setMagicDefense(monster.getMagicDefense() * 3);
                    break;
                case Globals.MOB_BOSS:
                    monster.Scale *= 4.0f;
                    monster.MaxHealth = monster.MaxHealth * 10;
                    monster.Health = monster.MaxHealth;
                    monster.setAttack(monster.getAttack() * 3);
                    monster.setDefense(monster.getDefense() * 3);
                    monster.setMagic(monster.getMagic() * 3);
                    monster.setMagicDefense(monster.getMagicDefense() * 3);
                    break;
                case Globals.MOB_SPECIAL:
                    monster.Name = "The Stumonster";
                    monster.Scale *= 6.0f;
                    monster.MaxHealth = monster.MaxHealth * 20;
                    monster.Health = monster.MaxHealth;
                    monster.setAttack(monster.getAttack() * 4);
                    monster.setDefense(monster.getDefense() * 4);
                    monster.setMagic(monster.getMagic() * 4);
                    monster.setMagicDefense(monster.getMagicDefense() * 4);
                    break;
            }

            switch (StateHandler.Difficulty)
            {
                case Globals.DIFFICULTY_VERY_EASY:
                    monster.Scale *= 0.75f;
                    monster.MaxHealth = monster.MaxHealth / 2;
                    monster.Health = monster.MaxHealth;
                    monster.setAttack(monster.getAttack() / 2);
                    monster.setDefense(monster.getDefense() / 2);
                    monster.setMagic(monster.getMagic() / 2);
                    monster.setMagicDefense(monster.getMagicDefense() / 2);
                    break;
                case Globals.DIFFICULTY_EASY:
                    monster.Scale *= 0.85f;
                    monster.MaxHealth = monster.MaxHealth * 3 / 4;
                    monster.Health = monster.MaxHealth;
                    monster.setAttack(monster.getAttack() * 3 / 4);
                    monster.setDefense(monster.getDefense() * 3 / 4);
                    monster.setMagic(monster.getMagic() * 3 / 4);
                    monster.setMagicDefense(monster.getMagicDefense() * 3 / 4);
                    break;
                case Globals.DIFFICULTY_NORMAL:
                    break;
                case Globals.DIFFICULTY_HARD:
                    monster.Scale *= 1.15f;
                    monster.MaxHealth = monster.MaxHealth * 5 / 4;
                    monster.Health = monster.MaxHealth;
                    monster.setAttack(monster.getAttack() * 5 / 4);
                    monster.setDefense(monster.getDefense() * 5 / 4);
                    monster.setMagic(monster.getMagic() * 5 / 4);
                    monster.setMagicDefense(monster.getMagicDefense() * 5 / 4);
                    break;
                case Globals.DIFFICULTY_VERY_HARD:
                    monster.Scale *= 1.25f;
                    monster.MaxHealth = monster.MaxHealth * 3 / 2;
                    monster.Health = monster.MaxHealth;
                    monster.setAttack(monster.getAttack() * 3 / 2);
                    monster.setDefense(monster.getDefense() * 3 / 2);
                    monster.setMagic(monster.getMagic() * 3 / 2);
                    monster.setMagicDefense(monster.getMagicDefense() * 3 / 2);
                    break;
                case Globals.DIFFICULTY_INSANE:
                    monster.Scale *= 1.5f;
                    monster.MaxHealth = monster.MaxHealth * 2;
                    monster.Health = monster.MaxHealth;
                    monster.setAttack(monster.getAttack() * 2);
                    monster.setDefense(monster.getDefense() * 2);
                    monster.setMagic(monster.getMagic() * 2);
                    monster.setMagicDefense(monster.getMagicDefense() * 2);
                    break;
            }

            if (boss)
            {
                monster.Boss = true;
                monster.Scale *= 1.5f;
                monster.MaxHealth = monster.MaxHealth * 2;
                monster.Health = monster.MaxHealth;
                monster.setAttack(monster.getAttack() * 2);
                monster.setDefense(monster.getDefense() * 2);
                monster.setMagic(monster.getMagic() * 2);
                monster.setMagicDefense(monster.getMagicDefense() * 2);
            }

            return monster;
        }
    }
}
