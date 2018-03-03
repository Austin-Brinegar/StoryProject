using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    abstract class Item
    {
        public String Name { get; set; }
        public String Description { get; set; }

        public abstract void Effect(Character user, Character opponent);
    }
}
