using System;

namespace GameOfChanceSimulator

{
    class Program
    {
        static void Main()
        {

            Fighter geralt = new Fighter("Geralt", 80, 75, 60, 4);
            Fighter manhattan = new Fighter("Dr_Manhattan", 100, 1000, 40, 1);
            Fighter terminator = new Fighter("Terminator3", 90, 15, 20, 30);
            Fighter rambo = new Fighter("Rambo", 100, 45, 65, 25);

            Fighter[] allFighters = new Fighter[] { geralt, manhattan, terminator, rambo };

            for (int i = 0; i < 1000; i++)
            {
                Random randomFighter = new Random();
                Console.WriteLine(allFighters[0].Fight(allFighters[randomFighter.Next(0, 4)], allFighters[randomFighter.Next(0, 4)]));
            }


            global::System.Console.WriteLine(geralt.Fight(geralt, manhattan));
        }
    }
}
