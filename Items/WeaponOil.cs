using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    class WeaponOil : Item
    {
        double DmgMultiplier { get; set; }

        //Constructor
        public WeaponOil(double DmgMultiplier)
        {
            Name = $"Weapon oil [x{DmgMultiplier} damage]";
            Description = "Oil your weapon to deal more damage this hit";
            this.DmgMultiplier = DmgMultiplier;
        }

        //Buffs weapon by damage multipyer, strikes enemy, then returns weapon damage to normal. Displays attack text as well.
        public override void Effect(Character user, Character opponent)
        {
            user.EquippedWeapon.Damage *= DmgMultiplier;
            double damage = user.Attack(opponent);
            user.EquippedWeapon.Damage /= DmgMultiplier;
            if (user.IsPC)
            {
                Console.WriteLine($"You apply your {Name} and strike {opponent.Name} for {damage} damage.");
            }
            else
            {
                Utility.ColorText($"{user.Name} applies his {Name} and strikes you for {damage} damage.", ConsoleColor.Magenta);
            }
            user.Items.Remove(this);
        }
    }
}
