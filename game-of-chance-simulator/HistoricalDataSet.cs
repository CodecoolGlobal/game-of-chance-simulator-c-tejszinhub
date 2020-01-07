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
        public IReadOnlyList<HistoricalDataPoint> DataPoints { get { return _DataPoints; } }
        internal void AddDatapoint(HistoricalDataPoint dataPoint)
        {
            _DataPoints.Add(dataPoint);
        }
        /*public HistoricalDataSet(ILogger)
        {

        }*/
        
        public void Generate()
        {
            Round round = new Round();
            round.LoadFighters(@"..\..\..\Fighters.csv");
            HistoricalDataPoint dataPoint = new HistoricalDataPoint(round.FightResult());
            AddDatapoint(dataPoint);
            this.Size++;

            string history = @"../../../history.csv";
            if (!File.Exists(history))
            {
                File.WriteAllText(history, dataPoint.DataPoint + "\n");
            }
            else
            {
                File.AppendAllText(history, dataPoint.DataPoint + "\n");
            }

        }
        /*public void Load()
        {
            string file = @"../../../history.csv";
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
                this.AllFighters = allFighters;
            }
        }*/
    }
}
