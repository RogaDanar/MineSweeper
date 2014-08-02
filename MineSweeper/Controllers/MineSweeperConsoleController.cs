namespace MineSweeper.Controllers
{
    using MineSweeper.Specs;
    using NeuralNet.AppHelpers;
    using System;

    public class MineSweeperConsoleController
    {
        private Runner _runner;
        private IMineSweeperSpec _spec;

        public MineSweeperConsoleController(IMineSweeperSpec spec)
        {
            _spec = spec;
            _spec.NextGenerationEnded += specNextGeneration;

            _runner = new Runner(_spec);
        }

        public void Start()
        {
            _runner.Setup();
            _runner.EnableSimulation();
            _runner.Start();
        }

        private void specNextGeneration(object sender, EventArgs e)
        {
            var pop = _spec.Population;

            Console.WriteLine("Best: {0}({1})   Avg: {2}({3})",
                pop.FitnessStats.Best,
                pop.FitnessStats.BestChange,
                pop.FitnessStats.Average,
                pop.FitnessStats.AverageChange);
        }
    }
}
