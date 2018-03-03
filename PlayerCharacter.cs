using System;
using System.Collections.Generic;
using System.Text;

namespace StoryProject
{
    class PlayerCharacter : Character
    {
        private static PlayerCharacter instance;
        private int karma;

        private PlayerCharacter() :base("Main Character",100, 10)
        {
            EquippedWeapon = new Weapon("Fists", 0);
            EquippedArmor = new Armor("Clothes", 0);
            PlayerAlignment = Alignment.Neutral;
            Items = new List<Item>();
            karma = 0;
            IsPC = true;
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

        public void Reset()
        {
            instance.Name = "Main Character";
            instance.Health = 100;
            instance.Strength = 10;
            instance.EquippedWeapon = new Weapon("Fists", 0);
            instance.EquippedArmor = new Armor("Clothes", 0);
            instance.PlayerAlignment = Alignment.Neutral;
            instance.Items = new List<Item>();
            instance.karma = 0;
            instance.IsPC = true;
        }
    }
}
