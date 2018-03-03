using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    public enum Alignment
    {
        Good,
        Neutral,
        Evil
    }

    class Character
    {

        public Character(String Name, float Health, float Strength, Weapon EquippedWeapon, Armor EquippedArmor, 
            Alignment PlayerAlignment, List<Item> Items)
        {
            this.Name = Name;
            this.Health = Health;
            this.Strength = Strength;
            this.EquippedWeapon = EquippedWeapon;
            this.EquippedArmor = EquippedArmor;
            this.PlayerAlignment = PlayerAlignment;
            this.Items = new List<Item>();
            this.Items.AddRange(Items);
        }

        public String Name { get; set; }

        public float Health { get; set; }
        
        public float Strength { get; set; }

        public Weapon EquippedWeapon { get; set; }

        public Armor EquippedArmor { get; set; }

        public Alignment PlayerAlignment { get; set; }

        public List<Item> Items { get; set; }

        //Calculates damage to be done to opponent and returns the damage dealt after modifiers
        public float Attack(Character opponent)
        {
            //Calculate power (The total damage to be dealt to opponent)
            Random rng = new Random();
            float modifier = rng.Next(11);
            modifier /= 10;
            float power = Strength * modifier + EquippedWeapon.Damage;

            //Deal out the damage
            if (power - EquippedArmor.DamageResistance <= 0)
            {
                opponent.Health -= 1;    
                return 1;
            }
            else
            {
                opponent.Health -= (power - EquippedArmor.DamageResistance);
                return (power - EquippedArmor.DamageResistance);
            }
        }

        public void addItem(Item i)
        {
            if(Items.Count <= 5)
            {
                Items.Add(i);
            }
            else
            {
                Console.WriteLine("Inventory Full");
            }
        }
    }
}
