using System;
using System.Collections.Generic;

namespace StoryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                //Defines PC
                PlayerCharacter pc = PlayerCharacter.Instance;
                pc.Reset();
                //Allows Player to equip themselves
                OpeningScene();

                int baddiesKilled = 0;

                //Player will keep fighting new enemies until he dies. Loop also keeps track of wins
                while (pc.Health > 0)
                {
                    Utility.ColorText($"BATTLE NUMBER {baddiesKilled + 1} COMMENCING!", ConsoleColor.Blue
                        );
                    new Battle(RandomEnemyGenerator()).Fight();
                    if (pc.Health > 0) baddiesKilled++;
                }
                //Display how many kills you got this round
                Utility.ColorText($"You killed {baddiesKilled} enemies", ConsoleColor.DarkCyan);
                Console.WriteLine("Press any key to play again");
                Console.ReadLine();
            }
            while (true);
        }

        //Create a random enemy from the lists in the utility class
        static Character RandomEnemyGenerator()
        {
            Random rng = new Random();

            //create item list for enemy
            List<Item> items = new List<Item>
            {
                Utility.ItemList(rng.Next(9)),
                Utility.ItemList(rng.Next(9)),
                Utility.ItemList(rng.Next(9))
            };

            //create random character
            Character c = new Character(Utility.NameList(rng.Next(7)), rng.Next(20, 100), rng.Next(5, 10), 
                Utility.WeaponList(rng.Next(7)), Utility.ArmorList(rng.Next(7)), Alignment.Evil, items);

            return c;
        }

        //Pick from three Weapons(pick = 1), armor(pick = 2), or items(pick=3)
        static void PickThree(int pick)
        {
            PlayerCharacter pc = PlayerCharacter.Instance;
            Random rng = new Random();
            int choice; //user input
            switch (pick)
            {
                case 1: //Select Weapon from a random list of three
                    List<Weapon> weaponList = new List<Weapon>();
                    for(int i = 0; i < 3; i++)
                    {
                        weaponList.Add(Utility.WeaponList(rng.Next(7))); //Choose the three to display
                    }
                    Console.WriteLine("1) " + weaponList[0].Name); //display the three
                    Console.WriteLine("2) " + weaponList[1].Name);
                    Console.WriteLine("3) " + weaponList[2].Name);
                    choice = Int32.Parse(CorrectInput()); //Change string to int
                    choice -= 1; //adjust input from normie to programmer
                    pc.EquippedWeapon = weaponList[choice]; //equip weapon
                    break;
                case 2: //Select armor from a randm list of three
                    List<Armor> armorList = new List<Armor>();
                    for (int i = 0; i < 3; i++)
                    {
                        armorList.Add(Utility.ArmorList(rng.Next(7))); //Choose the three to display
                    }
                    Console.WriteLine("1) " + armorList[0].Name);//display the three
                    Console.WriteLine("2) " + armorList[1].Name);
                    Console.WriteLine("3) " + armorList[2].Name);
                    choice = Int32.Parse(CorrectInput()); //change string to int
                    choice -= 1; //adjust input from normie to programmer
                    pc.EquippedArmor = armorList[choice]; //equip Armor
                    break;
                case 3: //Select three items from three random lists of three
                    for (int j = 0; j < 3; j++) //run three times
                    {
                        List<Item> itemList = new List<Item>();
                        for (int i = 0; i < 3; i++)
                        {
                            itemList.Add(Utility.ItemList(rng.Next(9))); //choose items to display
                        }
                        Console.WriteLine("1) " + itemList[0].Name); //display the three
                        Console.WriteLine("2) " + itemList[1].Name);
                        Console.WriteLine("3) " + itemList[2].Name);
                        choice = Int32.Parse(CorrectInput()); //change string to int
                        choice -= 1; //adjust input from normie to programmer
                        pc.AddItem(itemList[choice]); //add item to inventory
                    }
                    break;

            }
        }  //this dude really needs refactoring

        //Check if input is correct for the PickThreeMethod
        static String CorrectInput()
        {
            Console.WriteLine("Choose Wisely");
            String choice;
            do
            {
                choice = Console.ReadLine(); //read player selection
                if(choice == "1" || choice == "2" || choice == "3")
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("You wont survive long with answers like that... Try again");
                }

            }
            while (choice != "1" || choice != "2" || choice != "3");
            return "Failed";
        }

        //Dialogue for the OpeningScene
        static void OpeningScene()
        {
            Console.WriteLine("WELCOME TO THE THUNDERDOME MOTHERFUCKER!");
            Console.WriteLine("You are not expected to get very far.");
            Console.WriteLine("Before you're sent to your inevitable death, some things need to be taken care of.");
            Console.WriteLine("First you need a weapon, choose from these three: ");
            PickThree(1);
            Console.Clear();
            Console.WriteLine("Good now Pick an armor");
            PickThree(2);
            Console.Clear();
            Console.WriteLine("Interesting Choice... Next you're going to pick three items, but only one from each list");
            PickThree(3);
            Console.Clear();
            Console.WriteLine("You're Ready... NOW GET IN THERE!");
        }

    }
}