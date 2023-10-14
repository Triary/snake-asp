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
       // private Point _speed;

       private Point _snakeHead;
        public Snake()
        {
            Random rand = new Random();

            _snakeBody = new Queue<Point>();
            int snakeHeadX = rand.Next(BORN_SNAKE_SIZE - 1, Field._FIELD_WIDTH - BORN_SNAKE_SIZE);
            int snakeheadY = rand.Next(BORN_SNAKE_SIZE - 1, Field._FIELD_HEIGTH - BORN_SNAKE_SIZE);
           // _snakeHead = new Point(rand.Next(Field._FIELD_WIDTH), rand.Next(Field._FIELD_HEIGTH));
            _snakeHead = new Point(snakeHeadX, snakeheadY);

            for(int counter=0; counter<BORN_SNAKE_SIZE; counter++) {
                _snakeBody.Enqueue(new Point(snakeHeadX, snakeheadY)); 
            }
        }
        public void Move()
        {
            Point head = SnakeHead;
            Point nextHead = new Point(head.X + Speed.X, head.Y + Speed.Y);
            
            _snakeBody.Enqueue(nextHead);
            _snakeBody.Dequeue();
        }
    }
}
