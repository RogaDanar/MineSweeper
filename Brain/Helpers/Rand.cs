namespace Brainspace.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Rand
    {
        private static Rand instance;

        private int seed;
        private Random rand;

        private Rand() {
            seed = DateTime.Now.Millisecond;
            rand = new Random(seed);
        }

        public static Rand Generator {
            get {
                if (instance == null)
                    instance = new Rand();
                return instance;
            }
        }

        public int Next(int min, int max) {
            return rand.Next(min, max);
        }

        public int Next(int max) {
            return rand.Next(max);
        }

        public int Next() {
            return rand.Next();
        }
    }
}
