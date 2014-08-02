namespace NeuralNet.Genetics
{
    using System.Collections.Generic;
    using System.Linq;

    public class FitnessStats
    {
        public double Total { get; set; }
        public double Best { get; set; }
        public double Worst { get; set; }
        public double Average { get; set; }

        public double TotalChange { get; set; }
        public double BestChange { get; set; }
        public double WorstChange { get; set; }
        public double AverageChange { get; set; }

        public List<double> PreviousGenerationsTotal { get; set; }
        public List<double> PreviousGenerationsBest { get; set; }
        public List<double> PreviousGenerationsWorst { get; set; }
        public List<double> PreviousGenerationsAverage { get; set; }

        public FitnessStats()
        {
            PreviousGenerationsTotal = new List<double>();
            PreviousGenerationsBest = new List<double>();
            PreviousGenerationsWorst = new List<double>();
            PreviousGenerationsAverage = new List<double>();
        }

        public void Update(IList<Genome> genomes)
        {
            Total = genomes.Sum(x => x.Fitness);
            Best = genomes.Max(x => x.Fitness);
            Worst = genomes.Min(x => x.Fitness);
            Average = genomes.Average(x => x.Fitness);

            TotalChange = Total - PreviousGenerationsTotal.LastOrDefault();
            BestChange = Best - PreviousGenerationsBest.LastOrDefault();
            WorstChange = Worst - PreviousGenerationsWorst.LastOrDefault();
            AverageChange = Average - PreviousGenerationsAverage.LastOrDefault();
        }

        public void SaveCurrentToHistory()
        {
            PreviousGenerationsTotal.Add(Total);
            PreviousGenerationsBest.Add(Best);
            PreviousGenerationsWorst.Add(Worst);
            PreviousGenerationsAverage.Add(Average);
        }
    }
}
