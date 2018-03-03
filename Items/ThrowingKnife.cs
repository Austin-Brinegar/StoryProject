using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    class ThrowingKnife : Item
    {
        int Damage { get; set; }

        //Constructor
        public ThrowingKnife(int Damage)
        {
            Name = $"Throwing Knife [Deals {Damage} damage]";
            Description = "A sharp throwing knife. Ignores armor effect when used";
            this.Damage = Damage;
        }

        //Deals damage to opponent and displays item text. 
        public override void Effect(Character user, Character opponent)
        {
            opponent.Health -= Damage;
            if (user.IsPC)
            {
                Console.Clear();
                Console.WriteLine($"You throw your {Name} at {opponent.Name} and deal {Damage} damage.");
            }
            else
            {
                Utility.ColorText($"{user.Name} throws his {Name} at you and deals {Damage} damage.", ConsoleColor.Magenta);
            }
            user.Items.Remove(this);
        }
    }
}
