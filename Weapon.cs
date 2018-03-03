using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    public class Weapon
    {
        public String Name { get; set; }
        public double Damage { get; set; }

        public Weapon(String Name, float Damage)
        {
            this.Name = Name;
            this.Damage = Damage;
        }
    }
}
