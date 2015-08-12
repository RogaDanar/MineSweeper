namespace MineSweeper.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NeuralNet.Helpers;

    public static class Vector
    {
        private static Rand _rand = Rand.Generator;

        public static IList<double> NullVector(int dimensions)
        {
            return Enumerable.Repeat(0.0, dimensions).ToList();
        }

        public static IList<double> RandomVector(int dimensions, double max)
        {
            return Enumerable.Range(0, dimensions).Select(x => _rand.NextDouble(max)).ToList();
        }

        public static IList<double> RandomVector(int dimensions, double min, double max)
        {
            return Enumerable.Range(0, dimensions).Select(x => _rand.NextDouble(min, max)).ToList();
        }

        public static IList<double> NullVector2D()
        {
            return NullVector(2);
        }

        public static IList<double> RandomVector2D(double maxX, double maxY)
        {
            return new List<double> { _rand.NextDouble(maxX), _rand.NextDouble(maxY) };
        }

        public static bool VectorEquals(this IList<double> vector, IList<double> vectorToMatch)
        {
            if (vector.Count == vectorToMatch.Count)
            {
                for (int i = 0; i < vector.Count; i++)
                {
                    if (!vector[i].Equals(vectorToMatch[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static IList<double> Normalize(this IList<double> vector)
        {
            var length = vector.VectorLength();
            for (int i = 0; i < vector.Count; i++)
            {
                vector[i] /= length;
            }
            return vector;
        }

        public static double VectorLength(this IList<double> vector)
        {
            var squares = 0.0;
            for (int i = 0; i < vector.Count; i++)
            {
                squares += vector[i] * vector[i];
            }
            return Math.Sqrt(squares);
        }

        public static IList<double> SubtractVector(this IList<double> vector, IList<double> subtractVector)
        {
            var difference = new double[vector.Count];
            for (int i = 0; i < vector.Count; i++)
            {
                difference[i] = vector[i] - subtractVector[i];
            }
            return difference;
        }
    }
}