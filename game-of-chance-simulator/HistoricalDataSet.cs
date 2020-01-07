using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfChanceSimulator
{
    class HistoricalDataSet
    {
        public int size { get; private set; }
        public IReadOnlyList<HistoricalDataPoint> DataPoints { get; private set; }
        /*public HistoricalDataSet(ILogger)
        {

        }*/
        /*
         Note: calling the method generates a single new (randomized) HistoricalDataPoint instance,
         it adds this to the list of available DataPoints
         stored by the class and finally appends a new entry to history.csv.
        */
        public void Generate()
        {

        }
    }
}
