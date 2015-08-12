namespace NeuralNet.AppHelpers
{
    using System;

    public class Runner
    {
        private int _tickCounter;
        private bool _ticksFinished;
        private bool _run;

        public IRunnerSpecification Specification { get; protected set; }

        public bool IsRunning { get { return _run; } }

        public Runner(IRunnerSpecification specification)
        {
            UpdateSpecification(specification);
        }

        public void UpdateSpecification(IRunnerSpecification specification)
        {
            _ticksFinished = false;
            Specification = specification;
            _run = false;
        }

        public void Setup()
        {
            Specification.Setup();
        }

        public void Start()
        {
            _tickCounter = 0;
            while (!_ticksFinished)
            {
                try
                {
                    tick();
                }
                catch (ObjectDisposedException) { }
            }
        }

        public void ShutdownMainLoop()
        {
            _ticksFinished = true;
        }

        public void EnableSimulation()
        {
            _run = true;
        }

        public void DisableSimulation()
        {
            _run = false;
        }

        private void tick()
        {
            if (_run)
            {
                if (_tickCounter < Specification.Ticks)
                {
                    Specification.NextTick();
                    _tickCounter++;
                }
                else
                {
                    Specification.NextGeneration();
                    _tickCounter = 0;
                }
                Specification.AfterTick();
                if (Specification.IsFinished())
                {
                    ShutdownMainLoop();
                }
            }
        }
    }
}