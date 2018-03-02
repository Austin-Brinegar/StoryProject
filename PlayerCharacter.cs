using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    class PlayerCharacter : Character
    {
        private static PlayerCharacter instance;
        private int karma;

        private PlayerCharacter() :base("Traveler",100, 10, new Weapon("Fists", 0), new Armor("Clothes", 0), Alignment.Neutral)
        {
            karma = 0;
        }

        public static PlayerCharacter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerCharacter();
                }
                return instance;
            }
        }
    }
}
