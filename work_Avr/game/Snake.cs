using System.Drawing;

namespace work_Avr.game
{
    public class Snake
    {
        public const int BORN_SNAKE_SIZE = 4;
        public Point[] SnakeBody => _snakeBody.Where(x => x != SnakeHead).ToArray();
        public Point SnakeHead => _snakeBody.Last();
        public Point Speed { get; set; } = Point.Empty;

        private readonly Queue<Point> _snakeBody;
        public bool isMoving { get; private set; } = false;
        public bool isDead { get; private set; } = false;
        public int SnakeSize => _snakeBody.Count;

        public Snake()
        {
            Random randomizer = new Random();
            int snakeHead_X = randomizer.Next(Field._FIELD_WIDTH);
            int snakeHead_Y = randomizer.Next(Field._FIELD_HEIGTH);

            _snakeBody = new Queue<Point>();
            for (int counter = 0; counter < BORN_SNAKE_SIZE; counter++)
            {
                _snakeBody.Enqueue(new Point(snakeHead_X, snakeHead_Y));
            }
            isDead = false;
        }
        public void Move()
        {
            isMoving = Speed != Point.Empty;

            if (isDead) return;

            Point head = SnakeHead;
            Point nextHead = new Point(head.X + Speed.X, head.Y + Speed.Y);

            isDead = isOutOfField(nextHead);

            if (isDead) return;

            _snakeBody.Dequeue();

            isDead |= isHitMyself(nextHead);

            if (isDead) return;

            _snakeBody.Enqueue(nextHead);

        }

        private bool isHitMyself(Point nextHead)
        {
            return SnakeBody.Length >= BORN_SNAKE_SIZE - 1 && _snakeBody.Contains(nextHead);
        }

        private bool isOutOfField(Point nextHead)
        {
            return nextHead.X >= Field._FIELD_WIDTH || nextHead.X < 0 ||
                   nextHead.Y >= Field._FIELD_HEIGTH || nextHead.Y < 0;
        }

    }
}