using System;
using System.IO;
using System.Collections.Generic;

namespace GameOfChanceSimulator

{
    class Program
    {
        static ConsoleLogger conslog = new ConsoleLogger();
        static HistoricalDataSet dataSet = new HistoricalDataSet(conslog);
        static void Main(string[] args)
        {            
            if (args.Length == 0 || Convert.ToInt32(args[0]) == 0)
            {
                GenerateHistoricalDataSet(0);
            }
            else
            {
                GenerateHistoricalDataSet(Convert.ToInt32(args[0]));
            }
        }
        public static HistoricalDataSet GenerateHistoricalDataSet(int argNum)
        {
            if (argNum == 0)
            {
                dataSet.Load();
                conslog.Info("Using previously generated data." + "\n");
                for (int i = 0; i < dataSet.DataPoints.Count; i++)
                {
                    conslog.Info($"{dataSet.DataPoints[i].fighter1} vs {dataSet.DataPoints[i].fighter2}, winner: {dataSet.DataPoints[i].winner}" + "\n");
                }

                var dataEvaulator = new DataEvaluator(dataSet, conslog);
                return dataSet;
            }
            else
            {
                dataSet.Load();
                for (int i = 0; i < argNum; i++)
                {
                    dataSet.Generate();
                }
                
                for (int i = 0; i < dataSet.DataPoints.Count; i++)
                {
                    conslog.Info($"{dataSet.DataPoints[i].fighter1} vs {dataSet.DataPoints[i].fighter2}, winner: {dataSet.DataPoints[i].winner}" + "\n");
                }

                var dataEvaulator = new DataEvaluator(dataSet, conslog);
                return dataSet;
            }
            
    
        }
    }
}
