
using System.Drawing;

namespace work_Avr.game
{
    public class Field
    {
        public const int _FIELD_WIDTH = 10;
        public const int _FIELD_HEIGTH = 10;
        public int[][] FieldData => _field;
        public Snake _snake;
        private int[][] _field;


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
            _field[snakeHead.X][snakeHead.Y] = 3;

            foreach(var snakeBodyPoint in snakeBody)
            {
                _field[snakeBodyPoint.Y][snakeBodyPoint.X] = 2;
            }
        }


        public Field(Snake snake)
        {
            _snake = snake;
            _field = InitField();
        }
        public void ChangeField()
        {
                _field = InitField();

                AddSnakeDataToField();

                //меняем местоположение яблока каждое обновление ChangeField()
                var rand = new Random();
                var rndRow = rand.Next() % 10;
                var rndColumn = rand.Next() % 10;
                _field[rndRow][rndColumn] = 1;
            
        }
    }
}
