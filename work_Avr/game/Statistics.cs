using Microsoft.AspNetCore.Authentication;

namespace SnakeProj.game
{
    public class Statistics
    {

        private readonly Snake _snake;

        public DateTime GameStopped { get; set; }
        public TimeSpan GameTime { get; private set; }
        private DateTime GameStarted { get; set; }
        public int GameScore {  get; private set; }
        public int SnakeSize {  get; private set; }
        public bool IsSnakeDead { get; private set; }

        public Statistics(Snake snake) 
        {
            _snake = snake;
            GameStopped = DateTime.MinValue;
            GameStarted = _snake.isMoving ? DateTime.Now : DateTime.MinValue;
            SnakeSize = _snake.SnakeSize;
            GameTime = TimeSpan.Zero;
            GameScore = 0;
            IsSnakeDead = false;
        }

        public void Tick()
        {

            if(_snake.isDead)
            {
                IsSnakeDead = true;
                GameStopped = GameStopped == DateTime.MinValue ? DateTime.Now: GameStopped;
            }

            if( _snake.isMoving && GameStarted == DateTime.MinValue) 
            {
                 GameStarted = DateTime.Now;
            }
            if( _snake.isMoving )
            {
                GameTime = GameStopped == DateTime.MinValue ? DateTime.Now - GameStarted : GameStopped - GameStarted;

            }
            if(_snake.SnakeSize != SnakeSize)
            {
                SnakeSize = _snake.SnakeSize;
                ///base score 100
                ///100 for 10 steps
                ///10 for more than 20 steps
                ///
                var eatSeconds = (int)(DateTime.Now - GameStarted).TotalSeconds;
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