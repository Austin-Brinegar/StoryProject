using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    static class Utility
    {
        public static void ColorText(String s, ConsoleColor c)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(s);
            Console.ForegroundColor = ConsoleColor.White;
        }

        //returns weapon at specified index
        public static Weapon WeaponList(int i)
        {
            List<Weapon> weaponList = new List<Weapon>
            {
                new Weapon("Fists", 0),
                new Weapon("Dagger", 2),
                new Weapon("Club", 5),
                new Weapon("Sword", 10),
                new Weapon("Mace", 12),
                new Weapon("Greatsword", 20),
                new Weapon("Maul", 25)
            };

            return weaponList[i];
        }

        public static Armor ArmorList(int i)
        {
            List<Armor> armorList = new List<Armor>
            {
                new Armor("Clothes", 0),
                new Armor("Leather", 1),
                new Armor("Wood", 2.5),
                new Armor("Iron", 5),
                new Armor("Steel", 6),
                new Armor("Enchanted Metal", 10),
                new Armor("Dragonscale Mail", 12.5)
            };

            return armorList[i];
        }

        public static Item ItemList(int i)
        {
            List<Item> itemList = new List<Item>
            {
                new HealthPotion(10),
                new HealthPotion(20),
                new HealthPotion(30),
                new ThrowingKnife(10),
                new ThrowingKnife(20),
                new ThrowingKnife(30),
                new WeaponOil(1.5),
                new WeaponOil(2.5),
                new WeaponOil(3)
            };

            return itemList[i];
        }

        public static String NameList(int i)
        {
            List<String> nameList = new List<String>
            {
                "Kevin The Killer",
                "Derek The Decapitator",
                "Chad the Chode",
                "Paul the Impaler",
                "Jerry Von Jingles",
                "Gragnak the barbarian",
                "Paul"
            };

            return nameList[i];
        }
    }
}
