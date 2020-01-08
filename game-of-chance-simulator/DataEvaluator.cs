using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GameOfChanceSimulator
{
    class DataEvaluator
    {
        public DataEvaluator(HistoricalDataSet data, ILogger log)
        {
            try
            {
                var newResult = Run(data);
                log.Info($"Generated:  {newResult.NumberOfSimulations} rounds of data.\n");
                log.Info($"Number of simulations: {newResult.NumberOfSimulations} .\n");
                log.Info($"The best bet would be {newResult.BestChoice} with the winrate of {newResult.BestChoiceChance * 100:f2}%. \n");
            }
            catch (Exception)
            {

                log.Error("There is no file called history.csv, please generate a few rounds first!");
            }
        }

        public Result Run(HistoricalDataSet dataSet)
        {
            var numOfSimulation = dataSet.DataPoints.Count;
            var dictOfWinners = new Dictionary<string, int>();            

            for (int i = 0; i < numOfSimulation; i++)
            {
                var winners = dataSet.DataPoints[i].winner;
                if (!dictOfWinners.ContainsKey(winners))
                {
                    dictOfWinners[winners] = 1;
                }
                else
                {
                    dictOfWinners[winners]++;
                }   
            }
            string bestChoice = dictOfWinners.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            float bestChoiceChance = (float)dictOfWinners[bestChoice] / (float)numOfSimulation;
         
            Result result = new Result(numOfSimulation, bestChoice, bestChoiceChance);
            return result;
        }
    }
}
