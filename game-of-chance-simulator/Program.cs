using System;
using System.IO;
using System.Collections.Generic;

namespace GameOfChanceSimulator

{
    class Program
    {
        static void Main(string[] args)
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


                for (int i = 0; i < 10; i++)
                {
                    Random randomFighter = new Random();
                    int fighterA = randomFighter.Next(0, allFighters.Length);
                    int fighterB = randomFighter.Next(0, allFighters.Length);

                    while (fighterA == fighterB)
                    {
                        fighterB = randomFighter.Next(0, allFighters.Length);
                        /*Console.WriteLine("most" + allFighters[fighterB].Name);
                        Console.WriteLine("Ez volt" + allFighters[fighterA].Name);*/
                    }

                    Console.WriteLine(allFighters[0].Fight(allFighters[fighterA], allFighters[fighterB]));
                    /*Console.WriteLine("B " + allFighters[fighterB].Name);
                    Console.WriteLine("A " + allFighters[fighterA].Name);*/
                }

                HistoricalDataSet.GenerateHistoricalDataSet();

            }
        }
    }
}
