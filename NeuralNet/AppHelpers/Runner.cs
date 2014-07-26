﻿namespace NeuralNet.AppHelpers
{
    using NeuralNet.Genetics;
    using System;

    public class Runner
    {
        private int _tickCounter;
        private bool _ticksFinished;
        private bool _run;
        private IGeneticAlgorithm _genetics;

        public IRunnerSpecification Specification { get; protected set; }
        public bool IsRunning { get { return _run; } }

        public Runner(IRunnerSpecification specification)
        {
            Specification = specification;
            _run = false;
        }

        public void Setup()
        {
            _genetics = Specification.SetupGenetics();
            Specification.SetupCreatures();
            Specification.SetupPopulation();
        }

        public void Start()
        {
            _tickCounter = 0;
            while (!_ticksFinished)
            {
                try
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
                            Specification.NextGeneration(_genetics);
                            _tickCounter = 0;
                        }
                        Specification.AfterTick();
                    }
                }
                catch (ObjectDisposedException) { }
            }
        }

        public void Shutdown()
        {
            _ticksFinished = true;
        }

        public void StartRun()
        {
            _run = true;
        }

        public void StopRun()
        {
            _run = false;
        }
    }
}
