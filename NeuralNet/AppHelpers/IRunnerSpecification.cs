namespace NeuralNet.AppHelpers
{
    public interface IRunnerSpecification
    {
        /// <summary>
        /// Number of ticks for each generation
        /// </summary>
        int Ticks { get; }

        /// <summary>
        /// Set up any genetics, creatures, populations, etc.
        /// </summary>
        void Setup();

        /// <summary>
        /// Action performed each Tick
        /// </summary>
        void NextTick();

        /// <summary>
        /// Action to perform after Tick has finished
        /// </summary>
        void AfterTick();

        /// <summary>
        /// Indicates whether to continue with the next tick, or to break the loop
        /// </summary>
        bool IsFinished();

        /// <summary>
        /// Determines how the next generation will be computed
        /// </summary>
        void NextGeneration();
    }
}