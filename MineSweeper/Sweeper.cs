﻿using NeuralNet.Network;
using System;
using System.Collections.Generic;

namespace MineSweeper
{
    public class Sweeper
    {
        private const int _brainInputs = 4;
        private const int _brainOutputs = 2;
        private const double _maxRotation = 0.5;

        private INeuralNet _brain;
        public INeuralNet Brain
        {
            get { return _brain; }
            private set
            {
                _brain = value ?? new FeedforwardNetwork(_brainInputs, _brainOutputs, 20, 2);
                if (Brain.MaxInputs != _brainInputs || Brain.MinOutputs != _brainOutputs)
                {
                    throw new Exception("Incorrect brainsize");
                }
            }
        }

        public List<double> ClosestMine { get; private set; }

        public List<double> Position { get; set; }

        public List<double> Direction { get; private set; }

        public double Rotation { get; private set; }

        public double Speed { get; private set; }

        public Sweeper(List<double> position, double rotation, INeuralNet brain = null)
        {
            Brain = brain;
            Initiliaze(position, rotation);
        }

        public void Initiliaze(List<double> position, double rotation)
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

            Speed = rotLeft + rotRight;
            updatePosition(Speed);
        }

        private void updatePosition(double speed)
        {
            Position[0] += Direction[0] * speed;
            Position[1] += Direction[1] * speed;
        }

        public List<double> CheckForMine(double mineSize)
        {
            var mine = default(List<double>);

            var distance = getVectorLength(subtractVector(ClosestMine, Position));
            if (distance < mineSize)
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
                var differenceVector = subtractVector(mine, Position);
                var length = getVectorLength(differenceVector);
                if (length < closestDistance)
                {
                    closestDistance = length;
                    vectorToClosestMine = differenceVector;
                    ClosestMine = mine;
                }
            }

            return normalizeVector(vectorToClosestMine);
        }

        private List<double> normalizeVector(List<double> vector)
        {
            var length = getVectorLength(vector);
            for (int i = 0; i < vector.Count; i++)
            {
                vector[i] /= length;
            }
            return vector;
        }

        private double getVectorLength(List<double> difference)
        {
            var squares = 0.0;
            foreach (var axis in difference)
            {
                squares += axis * axis;
            }
            return Math.Sqrt(squares);
        }

        private List<double> subtractVector(List<double> vector, List<double> subtractionVector)
        {
            var difference = new List<double>();
            for (int i = 0; i < vector.Count; i++)
            {
                difference.Add(vector[i] - subtractionVector[i]);
            }
            return difference;
        }

        private void updateDirection()
        {
            Direction = Direction ?? new List<double> { 0.0, 0.0 };
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
