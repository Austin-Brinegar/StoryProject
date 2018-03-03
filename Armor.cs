using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    public class Armor
    {
        private string name;
        private float damageResistance;

        public Armor(string name, float damageResistance)
        {
            this.name = name;
            this.damageResistance = damageResistance;
        }

        public float DamageResistance
        {
            get { return damageResistance;  }
            set { damageResistance = value; }
        }
    }
}
