namespace MineSweeper.Utils
{
    using System.Collections.Generic;

    public static class DistanceCalculator
    {
        public static bool DetectCollision(List<double> subjectPosition, List<double> objectPosition, double touchDistance)
        {
            var collision = false;

            var distance = objectPosition.SubtractVector(subjectPosition).VectorLength();
            if (distance <= touchDistance)
            {
                collision = true;
            }
            return collision;
        }

        public static List<double> GetClosestObject(List<double> subjectPosition, List<List<double>> objectPositions)
        {
            var closestDistance = double.MaxValue;
            var closestObject = Vector.NullVector2D();
            foreach (var objectPosition in objectPositions)
            {
                var differenceVector = objectPosition.SubtractVector(subjectPosition);
                var length = differenceVector.VectorLength();
                if (length < closestDistance)
                {
                    closestDistance = length;
                    closestObject = objectPosition;
                }
            }
            return closestObject;
        }

        public static List<double> GetNormalizedVectorToObject(List<double> subjectPosition, List<double> objectPosition)
        {
            var vectorToObject = objectPosition.SubtractVector(subjectPosition);
            return vectorToObject.Normalize();
        }
    }
}
