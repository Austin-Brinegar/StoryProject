using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    public class Armor
    {
        public string Name { get; set; }
        public double DamageResistance { get; set; }

        public Armor(string Name, double DamageResistance)
        {
            this.Name = Name;
            this.DamageResistance = DamageResistance;
        }

    }
}
