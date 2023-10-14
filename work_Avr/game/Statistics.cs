using Microsoft.AspNetCore.Authentication;

namespace work_Avr.game
{
    public class Statistics
    {

        private readonly Snake _snake;
        public TimeSpan GameTime { get; private set; }
        private DateTime _time { get; set; }
        public int GameScore {  get; private set; }
        public int SnakeSize {  get; private set; }
        public Statistics(Snake snake) 
        {
            _snake = snake;
            _time = _snake.isMoving ? DateTime.Now : DateTime.MinValue;
            SnakeSize = _snake.SnakeSize;
            GameTime = TimeSpan.Zero;
            GameScore = 0;
        }

        public void Tick()
        {
            if( _snake.isMoving && _time == DateTime.MinValue) 
            {
                 _time = DateTime.Now;
            }
            if( _snake.isMoving )
            {
                GameTime = DateTime.Now - _time;
            }
            if(_snake.SnakeSize != SnakeSize)
            {
                SnakeSize = _snake.SnakeSize;
                ///base score 100
                ///100 for 10 steps
                ///10 for more than 20 steps
                ///
                var eatSeconds = (int)(DateTime.Now - _time).TotalSeconds;
                if(eatSeconds < 10 ) 
                {
                    GameScore += 50;
                }
                else if(eatSeconds <= 15 ) 
                {
                    GameScore += 10 * (15 - eatSeconds);
                }
                else if (eatSeconds <= 20)
                {
                    GameScore += 10 * (20 - eatSeconds);
                }
            }

        }


    }
}