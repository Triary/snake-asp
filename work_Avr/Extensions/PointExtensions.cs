using SnakeProj.game;
using System.Drawing;

namespace SnakeProj.Extensions
{
    public static class PointExtensions
    {

        public static Point GenerateFieldPoint(this Point point, IEnumerable<Point> excludePointsFromGeneration)
        {
            Random randomizer = new Random();
            var excludePointsFromGenerationArray = 
                excludePointsFromGeneration as Point[] ?? excludePointsFromGeneration.ToArray();
            while (true)
            {

                int X = randomizer.Next(Field._FIELD_WIDTH);
                int Y = randomizer.Next(Field._FIELD_HEIGTH);


                if (!excludePointsFromGeneration.Any(z => z.X == X && z.Y == Y))
                {
                    return new Point(X, Y);
                }
            }
        }
    }
}
