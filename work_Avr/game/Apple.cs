using SnakeProj.Extensions;
using System.Drawing;

namespace SnakeProj.game
{
    public class Apple
    {

        public Point Position { get; private set; }
        private readonly Snake _snake;
        public Apple(Snake snake) 
        { 
            _snake = snake;
            Position = GenerateApplePosition(_snake);
        }

        public void onDataUpdated()
        {
            if(Position == _snake.SnakeHead)
            {
                _snake.isGrowing = true;
                RegenerateApple();
            }
        }

        public void RegenerateApple()
        {
            Position = GenerateApplePosition(_snake);
        }

        private static Point GenerateApplePosition(Snake snake)
        {
            return Point.Empty.GenerateFieldPoint(
                snake.SnakeBody.Union(new[] { snake.SnakeHead })
                );
        }

    }
}
