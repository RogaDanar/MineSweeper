namespace NeuralNet.Helpers
{
    using System;

    public class Rand
    {
        private static Rand instance;

        private int seed;
        private Random rand;

        private Rand()
        {
            seed = DateTime.Now.Millisecond;
            rand = new Random(seed);
        }

        public static Rand Generator
        {
            get
            {
                if (instance == null)
                    instance = new Rand();
                return instance;
            }
        }

        /// <summary>
        ///  between 0 and int.MaxValue
        /// </summary>
        public int Next()
        {
            return rand.Next();
        }

        /// <summary>
        ///  between 0 and max
        /// </summary>
        public int Next(int max)
        {
            return rand.Next(max);
        }

        /// <summary>
        ///  between min and max
        /// </summary>
        public int Next(int min, int max)
        {
            return rand.Next(min, max);
        }

        /// <summary>
        ///  between 0.0 and 1.0
        /// </summary>
        public double NextDouble()
        {
            return rand.NextDouble();
        }

        /// <summary>
        ///  between 0.0 and max
        /// </summary>
        public double NextDouble(double max)
        {
            return max * rand.NextDouble();
        }

        /// <summary>
        ///  between -1.0 and 1.0
        /// </summary>
        public double NextClamped()
        {
            return NextDouble(-1.0, 1.0);
        }

        /// <summary>
        ///  between min and max
        /// </summary>
        public double NextDouble(double min, double max)
        {
            var range = max - min;
            return (range * rand.NextDouble()) + min;
        }
    }
}
