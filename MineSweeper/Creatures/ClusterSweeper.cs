namespace MineSweeper.Creatures
{
    using System;
    using System.Collections.Generic;
    using MineSweeper.Utils;
    using NeuralNet.Network;

    public class ClusterSweeper : ICreature
    {
        public static int BrainInputs = 10;
        public static int BrainOutputs = 2;

        private double _maxRotation;
        private double _maxSpeed;
        private double _maxX;
        private double _maxY;

        private INeuralNet _brain;

        public INeuralNet Brain
        {
            get { return _brain; }
            protected set
            {
                if (value.InputNeuronCount != BrainInputs || value.OutputNeuronCount != BrainOutputs)
                {
                    throw new Exception("Incorrect brainsize");
                }
                _brain = value;
            }
        }

        public double Fitness
        {
            get { return Brain.Genome.Fitness; }
        }

        public Motion Motion { get; protected set; }

        public ClusterSweeper(double maxX, double maxY, double maxSpeed, double maxRotation, INeuralNet brain)
        {
            _maxX = maxX;
            _maxY = maxY;
            _maxSpeed = maxSpeed;
            _maxRotation = maxRotation;
            Brain = brain;
            SetRandomMotion();
        }

        public void SetRandomMotion()
        {
            Motion = new Motion(_maxX, _maxY, _maxSpeed, _maxRotation);
        }

        public void Update(IList<double> closestClusterMine, IList<double> secondClosestClusterMine, IList<double> closestMine, IList<double> secondClosestMine)
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

            var output = Brain.Observe(inputs);

            var rotLeft = output[0];
            var rotRight = output[1];

            Motion.Rotate(rotLeft - rotRight);
            Motion.SetNewSpeed(rotLeft + rotRight);
            Motion.MoveToNextPosition();
        }

        public void IncreaseFitness(int fitnessIncrease)
        {
            Brain.Genome.IncreaseFitness(fitnessIncrease);
        }

        public void DecreaseFitness(int fitnessDecrease)
        {
            Brain.Genome.DecreaseFitness(fitnessDecrease);
        }
    }
}