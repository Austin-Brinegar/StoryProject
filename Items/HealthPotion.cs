using System;

namespace StoryProject
{
    class HealthPotion : Item
    {
        int HealingAmount { get; set; }

        //constructor
        public HealthPotion(int HealingAmount)
        {
            Name = $"Health Potion [+{HealingAmount} health]";
            Description = "The Vial has a faint red glow... it smells like strawberries.";
            this.HealingAmount = HealingAmount;
        }

        //specifies what the item does.
        public override void Effect(Character user, Character opponent)
        {
            user.Health += HealingAmount;
            if (user.IsPC)
            {
                Console.Clear();
                Utility.ColorText($"You used your {Name} and have been healed {HealingAmount}. Your health is now {user.Health}"
                    , ConsoleColor.Green);
            }
            else
            {
                Utility.ColorText($"{user.Name} used his {Name} to heal {HealingAmount}. his health is now {user.Health}"
                    , ConsoleColor.Yellow);
            }
            user.Items.Remove(this);
        }
    }
}
