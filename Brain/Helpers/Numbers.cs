namespace Brainspace.Helpers
{
    using System.Collections.Generic;

    public static class Numbers
    {
        public static IList<double> Zero()
        {
            return new List<double> {
                1, 1, 1, 1, 1, 1, 1,
                1, 1, 0, 0, 0, 1, 1,
                1, 0, 1, 1, 1, 0, 1,
                1, 0, 1, 1, 1, 0, 1,
                1, 0, 1, 1, 1, 0, 1,
                1, 0, 1, 1, 1, 0, 1,
                1, 1, 0, 0, 0, 1, 1,
                1, 1, 1, 1, 1, 1, 1,
            };
        }

        public static IList<double> One()
        {
            return new List<double> {
                1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1,
            };
        }

        public static IList<double> Two()
        {
            return new List<double> {
                1, 1, 1, 1, 1, 1, 1,
                1, 1, 0, 0, 0, 1, 1,
                1, 0, 1, 1, 1, 0, 1,
                1, 1, 1, 1, 0, 1, 1,
                1, 1, 1, 0, 1, 1, 1,
                1, 1, 0, 1, 1, 1, 1,
                1, 0, 0, 0, 0, 0, 1,
                1, 1, 1, 1, 1, 1, 1,
            };
        }

        public static IList<double> Three()
        {
            return new List<double> {
                1, 1, 1, 1, 1, 1, 1,
                1, 0, 0, 0, 0, 1, 1,
                1, 1, 1, 1, 1, 0, 1,
                1, 1, 0, 0, 0, 1, 1,
                1, 1, 1, 1, 1, 0, 1,
                1, 0, 1, 1, 1, 0, 1,
                1, 1, 0, 0, 0, 1, 1,
                1, 1, 1, 1, 1, 1, 1,
            };
        }

        public static IList<double> Four()
        {
            return new List<double> {
                1, 1, 1, 1, 1, 1, 1,
                1, 0, 1, 1, 0, 1, 1,
                1, 0, 1, 1, 0, 1, 1,
                1, 0, 1, 1, 0, 1, 1,
                1, 0, 0, 0, 0, 0, 1,
                1, 1, 1, 1, 0, 1, 1,
                1, 1, 1, 1, 0, 1, 1,
                1, 1, 1, 1, 1, 1, 1,
            };
        }
    }
}
