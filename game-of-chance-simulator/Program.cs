using System;
using System.IO;
using System.Collections.Generic;

namespace GameOfChanceSimulator

{
    class Program
    {
        static void Main()
        {

            var file = @"C:\Learning\game-of-chance-simulator-c-tejszinhub\game-of-chance-simulator\Fighters.csv";
            using (var reader = new StreamReader(file))
            {
                List<string> listA = new List<string>();
                List<string[]> listB = new List<string[]>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    listA.Add(line);
                }
                Fighter[] allFighters = new Fighter[listA.Count];
                foreach (var item in listA)
                {
                    var values = item.Split(',');
                    listB.Add(values);
                }

                for (int i = 0; i < listB.Count; i++)
                {
                    allFighters[i] = new Fighter(listB[i][0], Int32.Parse(listB[i][1]), Int32.Parse(listB[i][2]), Int32.Parse(listB[i][3]), Int32.Parse(listB[i][4]));
                }


                /*Fighter geralt = new Fighter("Geralt", 80, 75, 60, 4);
                Fighter manhattan = new Fighter("Dr_Manhattan", 100, 1000, 40, 1);
                Fighter terminator = new Fighter("Terminator3", 90, 15, 20, 30);
                Fighter rambo = new Fighter("Rambo", 100, 45, 65, 25);
                */


                for (int i = 0; i < 10; i++)
                {
                    Random randomFighter = new Random();
                    Console.WriteLine(allFighters[0].Fight(allFighters[randomFighter.Next(0, allFighters.Length)], allFighters[randomFighter.Next(0, allFighters.Length)]));
                }
            }
        }
    }
}
