namespace MineSweeper
{
    using NeuralNet.Network;
    using System;
    using System.Collections.Generic;

    public class SweeperDodger : Sweeper
    {
        public new static int BrainInputs = 6;
        public new static int BrainOutputs = 4;

        public override INeuralNet Brain
        {
            get { return _brain; }
            protected set
            {
                _brain = value ?? new FeedforwardNetwork(BrainInputs, BrainOutputs, 1, 8);
                if (Brain.MaxInputs != BrainInputs || Brain.MinOutputs != BrainOutputs)
                {
                    throw new Exception("Incorrect brainsize");
                }
            }
        }

        public List<double> ClosestHole { get; private set; }

        public SweeperDodger(List<double> position, double rotation, double maxX, double maxY, INeuralNet brain = null)
            : base(position, rotation, maxX, maxY, brain)
        {

        }

        public void Update(List<List<double>> mines, List<List<double>> holes)
        {
            ClosestMine = ClosestMine ?? new List<double>();
            ClosestHole = ClosestHole ?? new List<double>();
            var closestMine = GetNormalizedVectorToClosestObject(mines, ClosestMine);
            var closestHole = GetNormalizedVectorToClosestObject(holes, ClosestHole);

            var inputs = new List<double>();
            inputs.AddRange(closestMine);
            inputs.AddRange(closestHole);
            inputs.AddRange(Direction);

            var output = Brain.Observe(inputs);

            var rotLeft = output[0];
            var rotRight = output[1];
            var forward = output[2];
            var reverse = output[3];

            Rotation += GetLimitedRotation(rotLeft - rotRight);
            UpdateDirection();

            var speed = GetLimitedSpeed(forward - reverse + rotLeft + rotRight);
            UpdatePosition(speed);
        }
    }
}
