namespace MineSweeper.Creatures
{
    using MineSweeper.Utils;
    using NeuralNet.Network;
    using System;
    using System.Collections.Generic;

    public class ClusterSweeper : ICreature
    {
        public static int BrainInputs = 10;
        public static int BrainOutputs = 2;

        private const double _maxRotation = 0.7;
        private const double _maxSpeed = 1.5;
        private double _maxX;
        private double _maxY;

        private INeuralNet _brain;
        public INeuralNet Brain
        {
            get { return _brain; }
            protected set
            {
                _brain = value ?? new FeedforwardNetwork(BrainInputs, BrainOutputs, 1, 16);
                if (Brain.MaxInputs != BrainInputs || Brain.MinOutputs != BrainOutputs)
                {
                    throw new Exception("Incorrect brainsize");
                }
            }
        }

        public double Fitness
        {
            get { return Brain.Genome.Fitness; }
            set { Brain.Genome.Fitness = value; }
        }

        public Motion Motion { get; protected set; }

        public ClusterSweeper(double maxX, double maxY, INeuralNet brain = null)
        {
            _maxX = maxX;
            _maxY = maxY;
            Brain = brain;
            SetRandomMotion();
        }

        public void SetRandomMotion()
        {
            Motion = new Motion(_maxX, _maxY, _maxSpeed, _maxRotation);
        }

        public void Update(List<double> closestClusterMine, List<double> secondClosestClusterMine, List<double> closestMine, List<double> secondClosestMine)
        {
            var vectorToClosestClusterMine = DistanceCalculator.GetNormalizedVectorToObject(Motion.Position, closestClusterMine);
            var vectorToSecondClosestClusterMine = DistanceCalculator.GetNormalizedVectorToObject(Motion.Position, secondClosestClusterMine);
            var vectorToClosestMine = DistanceCalculator.GetNormalizedVectorToObject(Motion.Position, closestMine);
            var vectorToSecondClosestMine = DistanceCalculator.GetNormalizedVectorToObject(Motion.Position, secondClosestMine);

            var inputs = new List<double>();
            inputs.AddRange(vectorToClosestClusterMine);
            inputs.AddRange(vectorToSecondClosestClusterMine);
            inputs.AddRange(vectorToClosestMine);
            inputs.AddRange(vectorToSecondClosestMine);
            inputs.AddRange(Motion.Direction);

            var output = Brain.Observe(inputs.ToArray());

            var rotLeft = output[0];
            var rotRight = output[1];

            Motion.Rotate(rotLeft - rotRight);
            Motion.SetNewSpeed(rotLeft + rotRight);
            Motion.MoveToNextPosition();
        }
    }
}
