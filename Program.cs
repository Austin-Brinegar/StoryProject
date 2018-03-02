using System;

namespace StoryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerCharacter pc = PlayerCharacter.Instance;
            Character baddie = new Character("Gragnak", 20, 5, new Weapon("Sword", 10), new Armor("wood", 1), Alignment.Evil);
            Console.WriteLine("Greetings " + pc.Name);
            Console.WriteLine("A new challenger aproaches");
            Console.WriteLine(baddie.Name + " Approaches with his weapon drawn \nwhat do you do?");
            new Battle(baddie).Fight();
            Console.WriteLine("How'd it go?");
        }
    }
}