using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic
{
    static class ItemFactory
    {
        internal static void combatGenerate(int specials, int level, int mobquality, bool boss, string name)
        {
            int quality;
            ItemAbstract test = null;

            int chance = Globals.Random(0, 100);
            int min;

            switch (mobquality)
            {
                case Globals.MOB_WEAK:
                    min = 70;
                    if (Globals.Random(0, 100) > 50)
                        quality = Globals.ITEM_QUALITY_COMMON;
                    else
                        quality = Globals.ITEM_QUALITY_TRASH;
                    break;
                case Globals.MOB_NORMAL:
                    min = 60;
                    if (Globals.Random(0, 100) > 50)
                        quality = Globals.ITEM_QUALITY_UNCOMMON;
                    else
                        quality = Globals.ITEM_QUALITY_COMMON;
                    break;
                case Globals.MOB_HARD:
                    min = 50;
                    if (Globals.Random(0, 100) > 90)
                        quality = Globals.ITEM_QUALITY_RARE;
                    else if (Globals.Random(0, 100) > 50)
                        quality = Globals.ITEM_QUALITY_UNCOMMON;
                    else
                        quality = Globals.ITEM_QUALITY_COMMON;
                    break;
                case Globals.MOB_VERY_HARD:
                    min = 40;
                    if (Globals.Random(0, 100) > 50)
                        quality = Globals.ITEM_QUALITY_RARE;
                    else
                        quality = Globals.ITEM_QUALITY_UNCOMMON;
                    break;
                case Globals.MOB_INSANE:
                    min = 30;
                    if (Globals.Random(0, 100) > 50)
                        quality = Globals.ITEM_QUALITY_EPIC;
                    else
                        quality = Globals.ITEM_QUALITY_MASTERWORK;
                    break;
                case Globals.MOB_BOSS:
                    min = 20;
                    quality = Globals.ITEM_QUALITY_LEGENDARY;
                    break;
                case Globals.MOB_SPECIAL: default: // Default means it's GREATER than MOB_SPECIAL.
                    min = 0;
                    quality = Globals.ITEM_QUALITY_MYTHICAL;
                    break;
            }

            if (boss)
            {
                min = 0;
                level += 2;
            }

            if (chance < min)
                return;

            test = generateItem(specials, level, quality, "");

            string[] temp = new string[1];
            temp[0] = "You have acquired a " + test.Name;

            SubStateDisplayMessage message = new SubStateDisplayMessage(temp, 50, 400, 350, 350, StateHandler.State);
            StateHandler.State = message;
        }

        internal static ItemAbstract generateItem(int specials, int level, int quality, string name)
        {
            ItemAbstract newItem;

            int chance = Globals.Random(1, 100);

            
            if (chance < 0)
            {
                newItem = CreateConsumable(0, specials, level, quality, name);
                ItemHandler.itemList.Add((ConsumableAbstract)newItem);
            }
            else if (chance < 0)
            {
                int wearflags = Globals.Random(1, 100);

                wearflags += quality * 10;

                if (wearflags < 45)
                {
                    // No flags, it sucks.
                }
                else if (wearflags < 50)
                    wearflags = Globals.WEARFLAG_FEET;
                else if (wearflags < 55)
                    wearflags = Globals.WEARFLAG_CHEST;
                else if (wearflags < 60)
                    wearflags = Globals.WEARFLAG_HEAD;
                else if (wearflags < 65)
                    wearflags = Globals.WEARFLAG_LEGS;
                else if (wearflags < 70)
                    wearflags = Globals.WEARFLAG_WEAPON;
                else if (wearflags < 75)
                    wearflags = Globals.WEARFLAG_LEGS + Globals.WEARFLAG_FEET;
                else if (wearflags < 80)
                {
                    wearflags = Globals.WEARFLAG_HEAD;
                    level += 1;
                }
                else if (wearflags < 85)
                {
                    wearflags = Globals.WEARFLAG_CHEST;
                    level += 1;
                }
                else if (wearflags < 90)
                {
                    wearflags = Globals.WEARFLAG_WEAPON;
                    level += 1;
                }
                else if (wearflags < 93)
                {
                    wearflags = Globals.WEARFLAG_WEAPON;
                    level += 2;
                }
                else if (wearflags == 93)
                {
                    level += 1;
                    quality += 1;
                    // No flags
                }
                else if (wearflags == 94)
                {
                    level += 1;
                    quality += 1;
                    wearflags = Globals.WEARFLAG_FEET;
                }
                else if (wearflags == 95)
                {
                    level += 1;
                    quality += 1;
                    wearflags = Globals.WEARFLAG_LEGS;
                }
                else if (wearflags == 96)
                {
                    level += 1;
                    quality += 1;
                    wearflags = Globals.WEARFLAG_HEAD;
                }
                else if (wearflags == 97)
                {
                    level += 1;
                    quality += 1;
                    wearflags = Globals.WEARFLAG_CHEST;
                }
                else if (wearflags == 98)
                {
                    level += 1;
                    quality += 1;
                    wearflags = Globals.WEARFLAG_CHEST + Globals.WEARFLAG_FEET + Globals.WEARFLAG_LEGS + Globals.WEARFLAG_HEAD;
                }
                else if (wearflags == 99)
                {
                    level += 1;
                    quality += 1;
                    wearflags = Globals.WEARFLAG_WEAPON;
                }
                else
                {
                    chance = Globals.Random(1, 100);
                    if (chance < 34)
                    {
                        quality *= 3;
                        level *= 2;
                    }
                    else if (chance < 67)
                    {
                        wearflags = Globals.WEARFLAG_CHEST + Globals.WEARFLAG_FEET + Globals.WEARFLAG_LEGS + Globals.WEARFLAG_HEAD;
                        level *= 2;
                    }
                    else
                    {
                        wearflags = Globals.WEARFLAG_WEAPON;
                        level *= 2;
                        quality *= 2;
                    }
                }

                newItem = CreateEquip(wearflags, specials, level, quality, name);
                ItemHandler.equipList.Add((EquipmentAbstract)newItem);
            }
            else
            {
                int wearflags = 0;
                chance = Globals.Random(0, 100);

                if (chance > 80)
                {
                    level++;
                    quality++;
                    wearflags = Globals.RUNEFLAG_HEAD;
                }

                newItem = CreateRune(wearflags, specials, level, quality, name);
                ItemHandler.runeList.Add((RuneAbstract)newItem);
            }
            return newItem;
        }

        internal static EquipmentAbstract CreateEquip(int wearflags, int specials, int level, int quality, string name)
        {
            int difficulty = StateHandler.Difficulty;
            EquipmentAbstract eqTemp = new EquipmentAbstract();
            eqTemp.Wearflags = wearflags;

            int basePoints = (int)((float)(level*5) * (((float)(difficulty + 1)) * 0.25));
            basePoints += level * 5;

            basePoints *= (int)(((float)quality + 1) * 0.25);

            int fields = 0;

            if (Globals.IS_SET(wearflags, Globals.WEARFLAG_WEAPON))
            {
                fields += 6;
                basePoints += basePoints / 2;
            }

            if (Globals.IS_SET(wearflags, Globals.WEARFLAG_CHEST))
            {
                fields += 3;
                basePoints += basePoints / 3;
            }

            if (Globals.IS_SET(wearflags, Globals.WEARFLAG_HEAD))
            {
                fields += 2;
                basePoints += basePoints / 4;
            }

            if (Globals.IS_SET(wearflags, Globals.WEARFLAG_LEGS))
            {
                fields += 2;
                basePoints += basePoints / 4;
            }

            if (Globals.IS_SET(wearflags, Globals.WEARFLAG_FEET))
            {
                fields += 2;
                basePoints += basePoints / 5;
            }

            if (Globals.IS_SET(specials, Globals.ELEMENT_FIRE))
                fields += 2;

            if (Globals.IS_SET(specials, Globals.ELEMENT_WATER))
                fields += 2;

            if (Globals.IS_SET(specials, Globals.ELEMENT_NATURE))
                fields += 2;

            if (fields == 0)
                specials = Globals.ELEMENT_PHYSICAL;

            if (Globals.IS_SET(specials, Globals.ELEMENT_PHYSICAL))
                fields += 5;

            basePoints /= fields;

            if (basePoints < 1)
                basePoints = 1;

            if (Globals.IS_SET(specials, Globals.ELEMENT_FIRE))
            {
                eqTemp.Hpmod += basePoints*5;
                eqTemp.Attackmod += basePoints;
            }
            if (Globals.IS_SET(specials, Globals.ELEMENT_WATER))
            {
                eqTemp.Magicmod += basePoints;
                eqTemp.Magicdefensemod += basePoints;
            }
            if (Globals.IS_SET(specials, Globals.ELEMENT_NATURE))
            {
                eqTemp.Defensemod += basePoints;
                eqTemp.Magicdefensemod += basePoints;
            }
            if (Globals.IS_SET(specials, Globals.ELEMENT_PHYSICAL))
            {
                eqTemp.Hpmod += basePoints*5;
                eqTemp.Attackmod += basePoints;
                eqTemp.Defensemod += basePoints;
                eqTemp.Magicmod += basePoints;
                eqTemp.Magicdefensemod += basePoints;
            }

            if (Globals.IS_SET(wearflags, Globals.WEARFLAG_WEAPON))
            {
                if (Globals.IS_SET(specials, Globals.ELEMENT_PHYSICAL))
                    eqTemp.Attackmod += basePoints * 6;
                else if (Globals.IS_SET(specials, Globals.ELEMENT_WATER))
                    eqTemp.Magicmod += basePoints * 6;
                else
                {
                    eqTemp.Attackmod += basePoints * 3;
                    eqTemp.Magicmod += basePoints * 3;
                }
            }

            if (Globals.IS_SET(wearflags, Globals.WEARFLAG_CHEST))
            {
                eqTemp.Defensemod += basePoints * 2;
                eqTemp.Magicdefensemod += basePoints;
            }

            if (Globals.IS_SET(wearflags, Globals.WEARFLAG_HEAD))
            {
                eqTemp.Magicdefensemod += basePoints;
                eqTemp.Magicmod += basePoints;
            }

            if (Globals.IS_SET(wearflags, Globals.WEARFLAG_LEGS))
            {
                eqTemp.Defensemod += basePoints;
                eqTemp.Hpmod += basePoints*5;
            }

            if (Globals.IS_SET(wearflags, Globals.WEARFLAG_FEET))
            {
                eqTemp.Hpmod += basePoints*5;
                eqTemp.Magicdefensemod += basePoints;
            }

            if (name != null && name.Length > 2)
                eqTemp.Name = name;
            else
            {
                if (Globals.IS_SET(wearflags, Globals.WEARFLAG_WEAPON))
                {
                    if (Globals.IS_SET(specials, Globals.ELEMENT_PHYSICAL))
                        eqTemp.Name = "Sword";
                    else if (Globals.IS_SET(specials, Globals.ELEMENT_WATER))
                        eqTemp.Name = "Staff";
                    else
                        eqTemp.Name = "Bow";
                }
                else if (Globals.IS_SET(wearflags, Globals.WEARFLAG_CHEST + Globals.WEARFLAG_FEET + Globals.WEARFLAG_HEAD + Globals.WEARFLAG_LEGS))
                    eqTemp.Name = "Full Platemail";
                else if (Globals.IS_SET(wearflags, Globals.WEARFLAG_LEGS + Globals.WEARFLAG_FEET))
                    eqTemp.Name = "Greaves";
                else if (Globals.IS_SET(wearflags, Globals.WEARFLAG_CHEST))
                    eqTemp.Name = "Chainmail";
                else if (Globals.IS_SET(wearflags, Globals.WEARFLAG_HEAD))
                    eqTemp.Name = "Helmet";
                else if (Globals.IS_SET(wearflags, Globals.WEARFLAG_LEGS))
                    eqTemp.Name = "Legguards";
                else if (Globals.IS_SET(wearflags, Globals.WEARFLAG_FEET))
                    eqTemp.Name = "Boots";
                else
                    eqTemp.Name = "Ring";

                if (Globals.IS_SET(specials, Globals.ELEMENT_WATER + Globals.ELEMENT_FIRE + Globals.ELEMENT_WATER + Globals.ELEMENT_PHYSICAL))
                    eqTemp.Name = "Planar " + eqTemp.Name;
                else if (Globals.IS_SET(specials, Globals.ELEMENT_FIRE + Globals.ELEMENT_NATURE + Globals.ELEMENT_FIRE))
                    eqTemp.Name = "Elemental " + eqTemp.Name;
                else if (Globals.IS_SET(specials, Globals.ELEMENT_FIRE))
                    eqTemp.Name = "Fiery " + eqTemp.Name;
                else if (Globals.IS_SET(specials, Globals.ELEMENT_WATER))
                    eqTemp.Name = "Watery " + eqTemp.Name;
                else if (Globals.IS_SET(specials, Globals.ELEMENT_NATURE))
                    eqTemp.Name = "Wild " + eqTemp.Name;
                else if (Globals.IS_SET(specials, Globals.ELEMENT_PHYSICAL))
                    eqTemp.Name = "Steel " + eqTemp.Name;
                else
                    eqTemp.Name = "Indifferent " + eqTemp.Name;
            }

            return eqTemp;
        }

        internal static ConsumableAbstract CreateConsumable(int type, int specials, int level, int quality, string name)
        {
            int difficulty = StateHandler.Difficulty;
            ConsumableAbstract CTemp = new ConsumableAbstract();

            CTemp.Name = name;

            int itemLevel = level;

            itemLevel /= 15;

            itemLevel += (difficulty-3);

            itemLevel += (quality-3);

            if (itemLevel < 1)
                itemLevel = 1;

            CTemp.Power = itemLevel;

            if (type > 0)
            {
                CTemp.Type = type;
            }
            else
            {
                int chance = Globals.Random(0, 100);

                if (chance < 10)
                    CTemp.Type = Globals.TYPE_CONSUMABLE_FIRE;
                else if (chance < 20)
                    CTemp.Type = Globals.TYPE_CONSUMABLE_NATURE;
                else if (chance < 30)
                    CTemp.Type = Globals.TYPE_CONSUMABLE_WATER;
                else if (chance < 40)
                    CTemp.Type = Globals.TYPE_CONSUMABLE_PHYSICAL;
                else if (chance < 50)
                    CTemp.Type = Globals.TYPE_CONSUMABLE_PHYSICAL + Globals.TYPE_CONSUMABLE_FIRE;
                else
                    CTemp.Type = Globals.TYPE_CONSUMABLE_POTION;
            }

            return CTemp;
        }

        internal static RuneAbstract CreateRune(int wearflags, int specials, int level, int quality, string name)
        {
            int difficulty = StateHandler.Difficulty;
            float mod;

            mod = (difficulty + 1) * 0.25f;

            mod = (quality + 1) * 0.25f;

            int runeLevel = (int)(level * mod) / 10;

            if (runeLevel < 1)
                runeLevel = 1;

            int max = 2 + ((quality + Globals.Random(0, 3)) / 3);

            if (quality < 1 || level < 1)
            {
                max = 1;
                runeLevel = 1;
            }

            SpellAbstract[] spells = new SpellAbstract[max];

            int element;

            if (!Globals.IS_SET(specials, Globals.ELEMENT_FIRE) &&
                !Globals.IS_SET(specials, Globals.ELEMENT_WATER) &&
                !Globals.IS_SET(specials, Globals.ELEMENT_NATURE))
            {
                int chance = Globals.Random(0, 100);
                if (chance < 34)
                    element = Globals.ELEMENT_FIRE;
                else if (chance < 67)
                    element = Globals.ELEMENT_NATURE;
                else
                    element = Globals.ELEMENT_WATER;
            }

            if (Globals.IS_SET(specials, Globals.ELEMENT_FIRE))
                element = Globals.ELEMENT_FIRE;
            else if (Globals.IS_SET(specials, Globals.ELEMENT_NATURE))
                element = Globals.ELEMENT_NATURE;
            else if (Globals.IS_SET(specials, Globals.ELEMENT_WATER))
                element = Globals.ELEMENT_WATER;
            else
            {
                int chance = Globals.Random(0,100);
                if (chance < 34)
                    element = Globals.ELEMENT_FIRE;
                else if (chance < 67)
                    element = Globals.ELEMENT_NATURE;
                else
                    element = Globals.ELEMENT_WATER;
            }

            for (int i = 0; i < spells.Length; i++)
            {
                switch(element)
                {
                    case Globals.ELEMENT_NATURE:
                        spells[i] = new SpellNature(i+ runeLevel);
                        break;
                    case Globals.ELEMENT_FIRE:
                        spells[i] = new SpellFire(i + runeLevel);
                        break;
                    case Globals.ELEMENT_WATER: default:
                        spells[i] = new SpellWater(i + runeLevel);
                        break;
                }
            }

            int[] cost = new int[max];

            int curCost = runeLevel * 50 + 500;

            for (int i = 0; i < max; i++)
            {
                if (i > 0)
                    cost[i] = cost[i-1]*2 + i * curCost;
                else
                    cost[i] = curCost;
            }

            RuneAbstract runeTemp = new RuneAbstract(cost, spells);

            runeTemp.Wearflags = wearflags;

            if (name != null && name.Length > 2)
                runeTemp.Name = name;
            else
            {
                switch (element)
                {
                    case Globals.ELEMENT_NATURE:
                        runeTemp.Name = "Nature Rune " + runeLevel;
                        break;
                    case Globals.ELEMENT_FIRE:
                        runeTemp.Name = "Fire Rune " + runeLevel;
                        break;
                    case Globals.ELEMENT_WATER: default:
                        runeTemp.Name = "Water Rune " + runeLevel;
                        break;
                }
            }

            return runeTemp;
        }

        internal static ItemAbstract CreateItem(int wearflags, int specials, int level, int difficulty, int quality, string name)
        {
            ItemAbstract newItem = new ItemAbstract();

            return newItem;
        }
    }
}
