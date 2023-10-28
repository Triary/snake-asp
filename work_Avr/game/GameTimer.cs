namespace SnakeProj.game
{
    using System.Configuration;
    using System.Threading;
    public class GameTimer
    {
        private readonly TimeSpan _timeout;
        private readonly Action[] _timerListener;
        private Timer _timer;

        public GameTimer(TimeSpan timeout,params Action[] timerListener)
        {
            _timeout = timeout;
            _timerListener = timerListener;
            _timer = new Timer(OnTimer);

            if(timerListener.Length > 0) 
                _timer.Change(_timeout, Timeout.InfiniteTimeSpan);
        }


        private void OnTimer(object? state)
        {
            foreach(var timerListener in _timerListener)
            {
                timerListener();
            }

            _timer.Change(_timeout, Timeout.InfiniteTimeSpan);
        }
    }
}
