using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GameOfChanceSimulator
{
    class HistoricalDataSet
    {
        public int Size { get; private set; }
        private List<HistoricalDataPoint> _DataPoints = new List<HistoricalDataPoint>();
        public IReadOnlyList<HistoricalDataPoint> DataPoints { get { return _DataPoints.AsReadOnly(); } }
        internal void AddDatapoint(HistoricalDataPoint dataPoint)
        {
            _DataPoints.Add(dataPoint);
        }
        public HistoricalDataSet(ILogger log)
        {

        }

        public void Generate()
        {
            Round round = new Round();
            round.LoadFighters(@"..\..\..\Fighters.csv");
            HistoricalDataPoint dataPoint = new HistoricalDataPoint(round.FightResult());
            AddDatapoint(dataPoint);
            this.Size++;

            string history = @"..\..\..\history.csv";
            if (!File.Exists(history))
            {
                File.WriteAllText(history, dataPoint.DataPoint + "\n");
            }
            else
            {
                File.AppendAllText(history, dataPoint.DataPoint + "\n");
            }

        }
        public void Load()
        {
            string file = @"..\..\..\history.csv";
            string[] historialData = System.IO.File.ReadAllLines(file);
            foreach (var item in historialData)
            {
                HistoricalDataPoint nextDataPoint = new HistoricalDataPoint(item);
                AddDatapoint(nextDataPoint);
                this.Size++;
            }
        }
    }
}
