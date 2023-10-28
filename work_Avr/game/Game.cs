using System.Net.NetworkInformation;

namespace SnakeProj.game
{
    public class Game
    {
        public Field field => _field;
        public Snake Snake => _snake;
        public GameTimer Timer => _timer;

        private readonly Field _field;
        private readonly Snake _snake;
        private readonly GameTimer _timer;
        public readonly Statistics stats;
        private readonly Apple _apple;


        public Game()
        {   
            _snake = new Snake();
            _apple = new Apple(_snake);
            _field = new Field(_snake,_apple);
            stats = new Statistics(_snake);
            _timer = new GameTimer(TimeSpan.FromSeconds(0.1f),
                                    _snake.Move,
                                    _apple.onDataUpdated,
                                    stats.Tick,
                                    _field.ChangeField
                                    );
        }
    }
}
