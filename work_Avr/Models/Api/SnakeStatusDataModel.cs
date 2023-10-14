using work_Avr.game;

namespace work_Avr.Models.Api
{
    public class SnakeStatusDataModel
    {


       public SnakeStatusDataModel(Game game)  { 
        
            GameTime = game.stats.GameTime;
            SnakeSize = game.Snake.SnakeSize;
            SnakeScore = game.stats.GameScore;
        }


        public TimeSpan GameTime { get; }
        public int SnakeSize { get; }
        public int SnakeScore { get; }
        //public int 
    }
}
