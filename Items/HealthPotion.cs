using System;

namespace StoryProject
{
    class HealthPotion : Item
    {
        int HealingAmount { get; set; }

        //constructor
        public HealthPotion(int HealingAmount)
        {
            Name = $"Health Potion +{HealingAmount}";
            Description = "The Vial has a faint red glow... it smells like strawberries.";
            this.HealingAmount = HealingAmount;
        }

        //specifies what the item does.
        public override void Effect(Character c)
        {
            c.Health += HealingAmount;
            if (c.Name.Equals("You"))
            {
                Console.Clear();
                Battle.ColorText($"{c.Name} used your {Name} and have been healed {HealingAmount}. Your health is now {c.Health}"
                    , ConsoleColor.Green);
            }
            else{
                Battle.ColorText($"{c.Name} used his {Name} to heal {HealingAmount}. his health is now {c.Health}"
                    , ConsoleColor.Yellow);
            }
            c.Items.Remove(this);
        }
    }
}
