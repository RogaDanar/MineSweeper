namespace MineSweeper.Creatures
{
    using System;
    using System.Collections.Generic;
    using MineSweeper.Utils;
    using NeuralNet.Network;

    public class SweeperDodger : ICreature
    {
        public static int BrainInputs = 6;
        public static int BrainOutputs = 2;

        private const double _maxRotation = 0.5;
        private const double _maxSpeed = 1;
        private double _maxX;
        private double _maxY;

        private INeuralNet _brain;
        public INeuralNet Brain
        {
            get { return _brain; }
            protected set
            {
                _brain = value ?? new FeedforwardNetwork(BrainInputs, BrainOutputs, 1, 8);
                if (_brain.InputNeuronCount != BrainInputs || _brain.OutputNeuronCount != BrainOutputs)
                {
                    throw new Exception("Incorrect brainsize");
                }
            }
        }

        public double Fitness
        {
            get { return Brain.Genome.Fitness; }
        }

        public Motion Motion { get; protected set; }

        public SweeperDodger(double maxX, double maxY, INeuralNet brain = null)
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

        public void Update(IList<double> closestMine, IList<double> closestHole)
        {
            var vectorToClosestMine = DistanceCalculator.GetNormalizedVectorToObject(Motion.Position, closestMine);
            var vectorToClosestHole = DistanceCalculator.GetNormalizedVectorToObject(Motion.Position, closestHole);

            var inputs = new List<double>();
            inputs.AddRange(vectorToClosestMine);
            inputs.AddRange(vectorToClosestHole);
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
