using SnakeProj.game;

namespace SnakeProj.Models.Api
{
    public class SnakeStatusDataModel
    {


       public SnakeStatusDataModel(Game game)  { 
        
            GameTime = game.stats.GameTime;
            SnakeSize = game.Snake.SnakeSize;
            SnakeScore = game.stats.GameScore;
            isSnakeAlive = !game.stats.IsSnakeDead;
            isSnakeMove = game.Snake.isMoving;
        }


        public TimeSpan GameTime { get; }
        public int SnakeSize { get; }
        public int SnakeScore { get; }

        public bool isSnakeAlive {  get; }
        public bool isSnakeMove {  get; }
    }
}
