using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    enum Alignment
    {
        Good,
        Neutral,
        Evil
    }

    class Character
    {
        protected String name;
        protected float health; //how much damage can be taken in a fight
        protected float strength; //How much damage is done per hit (before modifiers)
        protected Weapon equippedWeapon;
        protected Armor equippedArmor;
        protected Alignment playerAlignment;

        public Character(String name, float health, float strength, Weapon equippedWeapon, Armor equippedArmor, 
            Alignment playerAlignment)
        {
            this.name = name;
            this.health = health;
            this.strength = strength;
            this.equippedWeapon = equippedWeapon;
            this.equippedArmor = equippedArmor;
            this.playerAlignment = playerAlignment;
        }

        public String Name {
            get { return name; }
            set { name = value;  }
        }

        public float Health
        {
            get { return health; }
            set { health = value; }
        }
        
        public float Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public Weapon EquippedWeapon
        {
            get { return equippedWeapon; }
            set { equippedWeapon = value; }
        }

        public Armor EquippedArmor
        {
            get { return equippedArmor; }
            set { equippedArmor = value; }
        }

        public Alignment PlayerAlignment
        {
            get { return playerAlignment; }
            set { playerAlignment = value; }
        }

        //returns total damage to be dealt
        public float Attack()
        {
            Random rng = new Random();
            float modifier = rng.Next(11);
            modifier /= 10;
            return strength*modifier + equippedWeapon.Damage;
        }
         
        //modifies health value by damage done 
        public void TakeDamage(float damage)
        {
            if(damage - equippedArmor.DamageResistance <= 0)
            {
                health -= 1;
            }
            else
            {
                health -= (damage - equippedArmor.DamageResistance);
            }
        }
    }
}
