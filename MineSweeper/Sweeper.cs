namespace MineSweeper
{
    using MineSweeper.Vectors;
    using NeuralNet.Network;
    using System;
    using System.Collections.Generic;

    public class Sweeper
    {
        public static int BrainInputs = 4;
        public static int BrainOutputs = 2;

        private const double _maxRotation = 0.5;
        private const double _maxSpeed = 2;

        private double _maxX;
        private double _maxY;

        protected INeuralNet _brain;
        public virtual INeuralNet Brain
        {
            get { return _brain; }
            protected set
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

        public List<double> ClosestMine { get; protected set; }

        public List<double> Position { get; set; }

        public List<double> Direction { get; protected set; }

        public double Rotation { get; protected set; }

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
            UpdateDirection();
        }

        public void Update(List<List<double>> mines)
        {
            ClosestMine = ClosestMine ?? new List<double>();
            var closestMine = GetNormalizedVectorToClosestObject(mines, ClosestMine);

            var inputs = new List<double>();
            inputs.AddRange(closestMine);
            inputs.AddRange(Direction);

            var output = Brain.Observe(inputs);

            var rotLeft = output[0];
            var rotRight = output[1];

            Rotation += GetLimitedRotation(rotLeft - rotRight);
            UpdateDirection();

            var speed = GetLimitedSpeed(rotLeft + rotRight);
            UpdatePosition(speed);
        }

        public List<double> DetectColision(List<double> subject, double touchDistance)
        {
            var collidedObject = default(List<double>);

            var distance = subject.SubtractVector(Position).VectorLength();
            if (distance <= touchDistance)
            {
                collidedObject = subject;
            }
            return collidedObject;
        }

        protected List<double> GetNormalizedVectorToClosestObject(List<List<double>> objects, List<double> closestItem)
        {
            var vectorToClosest = new List<double>();

            var closestDistance = double.MaxValue;
            foreach (var item in objects)
            {
                var differenceVector = item.SubtractVector(Position);
                var length = differenceVector.VectorLength();
                if (length < closestDistance)
                {
                    closestDistance = length;
                    vectorToClosest = differenceVector;
                    // Do not assign to closestItem, we don't want to change the reference
                    closestItem.Clear();
                    closestItem.AddRange(item);
                }
            }

            return vectorToClosest.Normalize();
        }

        protected void UpdatePosition(double speed)
        {
            Position[0] += Direction[0] * speed;
            Position[1] += Direction[1] * speed;

            if (Position[0] > _maxX) Position[0] -= _maxX;
            if (Position[0] < 0) Position[0] += _maxX;
            if (Position[1] > _maxY) Position[1] -= _maxY;
            if (Position[1] < 0) Position[1] += _maxY;
        }

        protected void UpdateDirection()
        {
            Direction = Direction ?? Vector.NullVector2D();
            Direction[0] = -Math.Sin(Rotation);
            Direction[1] = Math.Cos(Rotation);
        }

        protected double GetLimitedRotation(double rotationForce)
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

        protected double GetLimitedSpeed(double speed)
        {
            if (speed > _maxSpeed)
            {
                speed = _maxSpeed;
            }
            return speed;
        }
    }
}
