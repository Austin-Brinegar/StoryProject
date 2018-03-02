using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    class Armor
    {
        string name;
        float damageResistance;

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
