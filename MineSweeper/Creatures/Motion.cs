namespace MineSweeper.Creatures
{
    using System;
    using System.Collections.Generic;
    using MineSweeper.Utils;
    using NeuralNet.Helpers;

    public class Motion
    {
        private double _maxX;
        private double _maxY;
        private double _maxSpeed;
        private double _maxRotation;

        public IList<double> Position { get; private set; }

        public double Speed { get; private set; }

        public double Rotation { get; private set; }

        private double _xDirection { get { return -Math.Sin(Rotation); } }
        private double _yDirection { get { return Math.Cos(Rotation); } }

        public IList<double> Direction
        {
            get
            {
                return new List<double> { _xDirection, _yDirection };
            }
        }

        public Motion(double maxX, double maxY, double maxSpeed, double maxRotation)
        {
            _maxX = maxX;
            _maxY = maxY;
            _maxSpeed = maxSpeed;
            _maxRotation = maxRotation;
            Position = GetRandomPosition();
            Rotation = GetRandomRotation();
        }

        public Motion(List<double> position, double rotation, double maxX, double maxY, double maxSpeed, double maxRotation)
            : this(maxX, maxY, maxSpeed, maxRotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public void MoveToNextPosition()
        {
            Position[0] += _xDirection * Speed;

            if (Position[0] > _maxX)
            {
                Position[0] -= _maxX;
            }

            if (Position[0] < 0)
            {
                Position[0] += _maxX;
            }

            Position[1] += _yDirection * Speed;
            if (Position[1] > _maxY)
            {
                Position[1] -= _maxY;
            }
            if (Position[1] < 0)
            {
                Position[1] += _maxY;
            }
        }

        public void SetNewSpeed(double speed)
        {
            if (speed > _maxSpeed)
            {
                speed = _maxSpeed;
            }
            Speed = speed;
        }

        public void Rotate(double rotationForce)
        {
            if (rotationForce > _maxRotation)
            {
                rotationForce = _maxRotation;
            }
            if (rotationForce < -_maxRotation)
            {
                rotationForce = -_maxRotation;
            }
            Rotation += rotationForce;
        }

        private double GetRandomRotation()
        {
            return Rand.Generator.NextDouble() * Math.PI * 2;
        }

        private IList<double> GetRandomPosition()
        {
            return Vector.RandomVector2D(_maxX, _maxY);
        }
    }
}