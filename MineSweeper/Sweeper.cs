using MineSweeper.Vectors;
using NeuralNet.Network;
using System;
using System.Collections.Generic;

namespace MineSweeper
{
    public class Sweeper
    {
        public static int BrainInputs = 4;
        public static int BrainOutputs = 2;

        private const double _maxRotation = 0.5;

        private double _maxX;
        private double _maxY;

        private INeuralNet _brain;
        public INeuralNet Brain
        {
            get { return _brain; }
            private set
            {
                _brain = value ?? new FeedforwardNetwork(BrainInputs, BrainOutputs, 1, 6);
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

        public List<double> ClosestMine { get; private set; }

        public List<double> Position { get; set; }

        public List<double> Direction { get; private set; }

        public double Rotation { get; private set; }

        public Sweeper(List<double> position, double rotation, double maxX, double maxY, INeuralNet brain = null)
        {
            _maxX = maxX;
            _maxY = maxY;
            Brain = brain;
            Initialize(position, rotation);
        }

        public void Initialize(List<double> position, double rotation)
        {
            Position = position;
            Rotation = rotation;
            updateDirection();
        }

        public void Update(List<List<double>> mines)
        {
            var closestMine = getNormalizedVectorToClosestMine(mines);

            var inputs = new List<double>();
            inputs.AddRange(closestMine);
            inputs.AddRange(Direction);

            var output = Brain.Observe(inputs);

            var rotLeft = output[0];
            var rotRight = output[1];

            Rotation += getLimitedRotation(rotLeft - rotRight);
            updateDirection();

            var speed = (rotLeft + rotRight);
            updatePosition(speed);
        }

        public List<double> CheckForMine(double touchDistance)
        {
            var mine = default(List<double>);

            var distance = ClosestMine.SubtractVector(Position).VectorLength();
            if (distance <= touchDistance)
            {
                mine = ClosestMine;
            }
            return mine;
        }

        private List<double> getNormalizedVectorToClosestMine(List<List<double>> mines)
        {
            var vectorToClosestMine = new List<double>();

            var closestDistance = double.MaxValue;
            foreach (var mine in mines)
            {
                var differenceVector = mine.SubtractVector(Position);
                var length = differenceVector.VectorLength();
                if (length < closestDistance)
                {
                    closestDistance = length;
                    vectorToClosestMine = differenceVector;
                    ClosestMine = mine;
                }
            }

            return vectorToClosestMine.Normalize();
        }

        private void updatePosition(double speed)
        {
            Position[0] += Direction[0] * speed;
            Position[1] += Direction[1] * speed;

            if (Position[0] > _maxX) Position[0] -= _maxX;
            if (Position[0] < 0) Position[0] += _maxX;
            if (Position[1] > _maxY) Position[1] -= _maxY;
            if (Position[1] < 0) Position[1] += _maxY;
        }

        private void updateDirection()
        {
            Direction = Direction ?? Vector.NullVector2D();
            Direction[0] = -Math.Sin(Rotation);
            Direction[1] = Math.Cos(Rotation);
        }

        private double getLimitedRotation(double rotationForce)
        {
            if (rotationForce > _maxRotation)
            {
                rotationForce = _maxRotation;
            }
            if (rotationForce < -_maxRotation)
            {
                rotationForce = -_maxRotation;
            }
            return rotationForce;
        }
    }
}
