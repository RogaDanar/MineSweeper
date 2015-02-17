namespace MineSweeper.Utils
{
    using System.Collections.Generic;

    public static class DistanceCalculator
    {
        public static bool DetectCollision(IList<double> subjectPosition, IList<double> objectPosition, double touchDistance)
        {
            var collision = false;

            var distance = objectPosition.SubtractVector(subjectPosition).VectorLength();
            if (distance <= touchDistance)
            {
                collision = true;
            }
            return collision;
        }

        public static IList<double> GetClosestObject(IList<double> subjectPosition, IList<IList<double>> objectPositions, int skip = 0)
        {
            var closestDistance = double.MaxValue;
            var closestObjectPosition = Vector.NullVector2D();

            for (int i = 0; i < objectPositions.Count; i++)
            {
                var differenceVector = objectPositions[i].SubtractVector(subjectPosition);
                var distance = differenceVector.VectorLength();
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObjectPosition = objectPositions[i];
                }
            }
            return closestObjectPosition;
        }

        public static IList<double> GetNormalizedVectorToObject(IList<double> subjectPosition, IList<double> objectPosition)
        {
            var vectorToObject = objectPosition.SubtractVector(subjectPosition);
            return vectorToObject.Normalize();
        }
    }
}
