using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    class Battle
    {
        private PlayerCharacter pc;
        private Character opponent;
        bool battleOn; //true if fight is still going on

        //constructor
        public Battle(Character opponent)
        {
            pc = PlayerCharacter.Instance;
            this.opponent = opponent;
            battleOn = true;
        }

        //logic behind the entire fight
        public void Fight()
        {
            do
            {
                PlayerTurn();
                if (CheckDeath(opponent) || CheckDeath(pc) || !battleOn) break; //End battle if Opponent died
                OpponentTurn();
            }
            while (battleOn);
        }

        //logic behind player's turn
        void PlayerTurn()
        {
            String choice;
            bool turnOver = false;
            do
            {
                Console.WriteLine("A: Attack");
                Console.WriteLine("B: Use Item");
                Console.WriteLine("C: Check Stats");
                Console.WriteLine("D: Run");

                choice = Console.ReadLine(); //read player selection
                choice = choice.ToLower();
                switch(choice)
                {
                    case "a":
                        PlayerAttackText(pc.Attack(opponent));
                        if (CheckDeath(opponent)) battleOn = false;
                        turnOver = true;
                        break;
                    case "b":
                        turnOver = PlayerSelectItem();
                        if (turnOver) break;
                        else continue;
                    case "c":
                        Console.WriteLine($"You have {pc.Health} health left");
                        break;
                    case "d":
                        //Console.WriteLine("You fled the battle");
                        //battleOn = false;
                        //turnOver = true;
                        Console.WriteLine("Where are you going to run to, scardy cat?");
                        turnOver = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid input, your clumsy mistakes deals 1 damage to you.");
                        pc.Health -= 1;
                        if (CheckDeath(pc))
                        {
                            Utility.ColorText("Congratulations, You killed yourself", ConsoleColor.DarkRed);
                            battleOn = false;
                        }
                        break;
                }
            } while (!turnOver);
        }

        //logic behind opponent's turn
        void OpponentTurn()
        {
            Random rng = new Random();
            int rand = rng.Next(10);
            //if (opponent.Health <= 10 && opponent.Items.Count > 0)
            if (rand < opponent.Items.Count)
            {
                opponent.Items[0].Effect(opponent, pc);
            }
            else
            {
                OpponentAttackText(opponent.Attack(pc));
            }
            if (pc.Health <= 0) battleOn = false;
        }

        //Text if player attacks
        void PlayerAttackText(double damage)
        {
            Console.Clear();
            Console.WriteLine($"You hit {opponent.Name} with your {pc.EquippedWeapon.Name} for {damage} " +
                $"damage... he has {opponent.Health} health left"); 
            if (CheckDeath(opponent))
            {
                Utility.ColorText("You killed him!", ConsoleColor.Cyan);
            }
        }
        
        //Text when an opponent attacks
        void OpponentAttackText(double damage)
        {
            String s = ($"{opponent.Name} hits you with {opponent.EquippedWeapon.Name} for  { damage} " +
                $"damage... you have {pc.Health} health left.");
            Utility.ColorText(s, ConsoleColor.Red);
            if (CheckDeath(pc))
            {
                Utility.ColorText("You Died", ConsoleColor.DarkRed);
            }
            
        }

        //Check to see if a character is dead
        bool CheckDeath(Character c)
        {
            if(c.Health <= 0)
            {
                return true;
            }
            return false;
        }

        //Prompts the user to select an item and handles selection
        bool PlayerSelectItem()
        {
            //Write list of items to screen. Fill with empty if they dont exist
            Console.WriteLine("Please select which item to use:");
            int i;
            for (i = 0; i < 5; i++)
            {
                if (i < pc.Items.Count)
                {
                    Console.WriteLine($"{i + 1}: {pc.Items[i].Name}");
                }
                else Console.WriteLine($"{i + 1}: empty");
            }
            Console.WriteLine($"{i + 1}: Back"); //Last entry (6 is max) should always be back
            String choice;
            bool endLoop = false;
            do //loop over player choice until they get it right
            {
                choice = Console.ReadLine(); //read player selection
                choice = choice.ToLower();
                switch (choice)
                {
                    //for each case, return out of the method with true (indicating that the item was used and the turn should end) 
                    //or break the switch to allow for another attempt.
                    case "1":
                        if (PlayerUseItem(0)) return true;
                        else break;
                    case "2":
                        if (PlayerUseItem(1)) return true;
                        else break;
                    case "3":
                        if (PlayerUseItem(2)) return true;
                        else break;
                    case "4":
                        if (PlayerUseItem(3)) return true;
                        else break;
                    case "5":
                        if (PlayerUseItem(4)) return true;
                        else break;
                    case "6":
                        return false;
                    default:
                        Console.WriteLine("Seriously? Read the list...");
                        break;
                }
            } while (!endLoop);
            return false;//Will never be reached
        }

        //Checks to see if the desired item exists, then uses it if it does. Returns true if item exists.
        bool PlayerUseItem(int index)
        {
            //check if item exists then use it
            if (pc.Items.Count > index && pc.Items[index] != null) 
            {
                pc.Items[index].Effect(pc, opponent);
                return true;
            }
            else
            {
                Console.WriteLine("Theres Nothing there...");
                return false;
            }

        }
    }
}