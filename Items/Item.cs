using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    abstract class Item
    {
        String Name { get; set; }
        String Description { get; set; }



        public abstract void effect();
    }
}
