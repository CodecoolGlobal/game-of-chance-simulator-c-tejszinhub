using System;
using System.IO;
using System.Collections.Generic;

namespace GameOfChanceSimulator

{
    class Program
    {
        static void Main(string[] args)
        {
            HistoricalDataSet dataSet = new HistoricalDataSet();

            for (int i = 0; i < 1000; i++)
            {
                dataSet.Generate();
            }
            Console.WriteLine(dataSet.DataPoints[1].DataPoint+ dataSet.DataPoints[2].DataPoint+ dataSet.DataPoints[3].DataPoint);
            //Console.WriteLine(dataSet.Size);
        }
    }
}
