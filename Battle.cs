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
            Console.WriteLine("A: Attack");
            Console.WriteLine("B: Run");
            Console.WriteLine("C: Check Stats");
            String choice;
            bool turnOver = false;
            do
            {
                choice = Console.ReadLine(); //read player selection
                choice = choice.ToLower();
                switch(choice)
                {
                    case "a":
                        float damage = pc.Attack(opponent);
                        PlayerAttackText(damage);
                        if (CheckDeath(opponent)) battleOn = false;
                        turnOver = true;
                        break;
                    case "b":
                        Console.WriteLine("You fled the battle");
                        battleOn = false;
                        turnOver = true;
                        break;
                    case "c":
                        Console.WriteLine($"You have {pc.Health} health left");
                        break;
                    default:
                        Console.WriteLine("Not a valid input, your clumsy mistakes deals 1 damage to you.");
                        pc.Health -= 1;
                        if (CheckDeath(pc))
                        {
                            colorText("Congratulations, You killed yourself", ConsoleColor.DarkRed);
                            battleOn = false;
                        }
                        break;
                }
            } while (!turnOver);
        }

        //logic behind opponent's turn
        void OpponentTurn()
        {
            float damage = opponent.Attack(pc);
            OpponentAttackText(damage);
            if (pc.Health <= 0) battleOn = false;
        }

        //Text if player attacks
        void PlayerAttackText(float damage)
        {
            Console.Clear();
            Console.WriteLine($"You hit {opponent.Name} wirh your {pc.EquippedWeapon.Name} for {damage} " +
                $"damage... he has {opponent.Health} health left"); 
            if (CheckDeath(opponent))
            {
                colorText("You killed him!", ConsoleColor.Cyan);
            }
        }
        
        //Text when an opponent attacks
        void OpponentAttackText(float damage)
        {
            String s = ($"{opponent.Name} hits you with {opponent.EquippedWeapon.Name} for  { damage} " +
                $"damage... you have {pc.Health} health left.");
            colorText(s, ConsoleColor.Red);
            if (CheckDeath(pc))
            {
                colorText("You Died", ConsoleColor.DarkRed);
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

        //Change the output color of a string
        void colorText(String s, ConsoleColor c)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(s);
            Console.ForegroundColor = ConsoleColor.White;
        } 
    }
}