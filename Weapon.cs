using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    class Weapon
    {
        String name;
        float damage;

        public Weapon(String name, float damage)
        {
            this.name = name;
            this.damage = damage;
        }

        public float Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
