namespace MineSweeper.Vectors
{
    using NeuralNet.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Vector
    {
        private static Rand _rand = Rand.Generator;

        public static List<double> NullVector(int dimensions)
        {
            return Enumerable.Repeat(0.0, dimensions).ToList();
        }

        public static List<double> RandomVector(int dimensions, double max)
        {
            return Enumerable.Range(0, dimensions).Select(x => _rand.NextDouble(max)).ToList();
        }

        public static List<double> RandomVector(int dimensions, double min, double max)
        {
            return Enumerable.Range(0, dimensions).Select(x => _rand.NextDouble(min, max)).ToList();
        }

        public static List<double> NullVector2D()
        {
            return NullVector(2);
        }

        public static List<double> RandomVector2D(double maxX, double maxY)
        {
            return new List<double> { _rand.NextDouble(maxX), _rand.NextDouble(maxY) };
        }

        public static bool VectorEquals(this List<double> vector, List<double> vectorToMatch)
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

        public static List<double> Normalize(this List<double> vector)
        {
            var length = vector.VectorLength();
            for (int i = 0; i < vector.Count; i++)
            {
                vector[i] /= length;
            }
            return vector;
        }

        public static double VectorLength(this List<double> vector)
        {
            var squares = 0.0;
            foreach (var axis in vector)
            {
                squares += axis * axis;
            }
            return Math.Sqrt(squares);
        }

        public static List<double> SubtractVector(this List<double> vector, List<double> subtractVector)
        {
            var difference = new List<double>();
            for (int i = 0; i < vector.Count; i++)
            {
                difference.Add(vector[i] - subtractVector[i]);
            }
            return difference;

        }
    }
}
