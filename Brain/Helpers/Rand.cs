namespace Brainspace.Helpers
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

        public int Next(int min, int max)
        {
            return rand.Next(min, max);
        }

        /// <summary>
        ///  between 0 and max
        /// </summary>
        public int Next(int max)
        {
            return rand.Next(max);
        }

        /// <summary>
        ///  between 0 and int.MaxValue
        /// </summary>
        public int Next()
        {
            return rand.Next();
        }

        public double NextClamped()
        {
            return NextDouble(-1.0, 1.0);
        }

        public double NextDouble(double min, double max)
        {
            var range = max - min;
            return (range * rand.NextDouble()) + min;
        }

        /// <summary>
        ///  between 0.0 and 1.0
        /// </summary>
        public double NextDouble()
        {
            return rand.NextDouble();
        }
    }
}
