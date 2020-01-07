using System;
using System.IO;
using System.Collections.Generic;

namespace GameOfChanceSimulator

{
    class Program
    {
        static void Main(string[] args)
        {
            Round round = new Round();
            round.LoadFighters(@"C:\Users\nevie\Desktop\gameOfChance\game-of-chance-simulator\Fighters.csv");
            string[] resultArray = new string[3];
            resultArray = round.FightResult();
            Console.WriteLine($"fighter1: '{resultArray[0]}', fighter2: '{resultArray[1]}', winner: '{resultArray[2]}'"); 
        }
    }
}
