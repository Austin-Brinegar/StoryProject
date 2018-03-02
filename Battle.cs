using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    class Battle
    {
        private PlayerCharacter pc;
        private Character opponent;
        bool battleOn;

        public Battle(Character opponent)
        {
            pc = PlayerCharacter.Instance;
            this.opponent = opponent;
            battleOn = true;
        }

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

        void PlayerTurn()
        {
            Console.WriteLine("A: Attack");
            Console.WriteLine("B: Run");
            String choice;
            do
            {
                choice = Console.ReadLine(); //read player selection
                choice = choice.ToLower();
                if (choice.Equals("a"))
                {
                    float damage = pc.Attack();
                    opponent.TakeDamage(damage); //Damage opponent
                    PlayerAttackText(damage);
                    if (CheckDeath(opponent)) battleOn = false;
                }
                else if (choice.Equals("b"))
                {
                    Console.WriteLine("You fled the battle");
                    battleOn = false;
                }
                else
                {
                    Console.WriteLine("Not a valid input, your clumsy mistakes deals 1 damage to you.");
                    pc.Health -= 1;
                    if (CheckDeath(pc))
                    {
                        Console.WriteLine("Congratulations, You killed yourself");
                        battleOn = false;
                    }
                }
            } while (!choice.Equals("a") && !choice.Equals("b"));
        }

        void OpponentTurn()
        {
            float damage = opponent.Attack();
            pc.TakeDamage(damage);
            OpponentAttackText(damage);
            if (pc.Health <= 0) battleOn = false;
        }

        void PlayerAttackText(float damage)
        {
            Console.WriteLine("You hit " + opponent.Name + " with your " + pc.EquippedWeapon.Name +
                " for " + damage + " Damage... He has " + opponent.Health + " health left.");
            if (CheckDeath(opponent))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("You killed him!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        
        void OpponentAttackText(float damage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(opponent.Name + " hits you with " + opponent.EquippedWeapon.Name + " for " +
                damage + " Damage... you have " + pc.Health + " health left.");
            if (CheckDeath(pc))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You Died");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        bool CheckDeath(Character c)
        {
            if(c.Health <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
