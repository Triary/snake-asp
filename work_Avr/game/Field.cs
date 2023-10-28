
using System.Drawing;

namespace SnakeProj.game
{
    public class Field
    {
        public const int _FIELD_WIDTH = 15;
        public const int _FIELD_HEIGTH = 15;
        public int[][] FieldData => _field;
        public Snake _snake;
        private int[][] _field;
        private readonly Apple _apple;

        private static int[][] InitField()
        {
            int[][] result = new int[_FIELD_HEIGTH][];
            for (int rowCounter = 0; rowCounter < _FIELD_HEIGTH; rowCounter++)
            {
                result[rowCounter] = new int[_FIELD_WIDTH];
                Array.Fill(result[rowCounter], 0, 0, _FIELD_WIDTH);
            }
            return result;
        }

        private void AddSnakeDataToField()
        {
            Point snakeHead = _snake.SnakeHead;
            Point[] snakeBody = _snake.SnakeBody;

            _field[snakeHead.Y][snakeHead.X] = 3;
            foreach (var snakeBodyPoint in snakeBody)
            {
                _field[snakeBodyPoint.Y][snakeBodyPoint.X] = 2;
            }
        }


        public Field(Snake snake)
        {
            _snake = snake;
            _field = InitField();
        }

        public Field(Snake snake, Apple appl)
        {
            _snake = snake;
            _apple = appl;
            _field = InitField();
        } 
        public void ChangeField()
        {
                _field = InitField();
                AddSnakeDataToField();
                AddAppleField();   
        }

        private void AddAppleField()
        {
            _field[_apple.Position.X][_apple.Position.Y] = 1;
        }
    }
}
