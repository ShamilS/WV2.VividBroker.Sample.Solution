using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers;

namespace WV2.VividBroker
{
    public class TimeOutTimer:IDisposable
    {
        public bool ConditionVerifiedFlag { get; private set; }
        public bool TimeOutFlag { get; private set; }

        private Func<Task<bool>> _condition;
        private int _timeOutIntervalInSeconds;
        private System.Timers.Timer _timeOutTimer;
        private Stopwatch _timer;
        public double ElapsedTimeInSeconds => _timer.Elapsed.TotalSeconds;
        private int _tickerCount;
        private int _tickerCountCurrentValue;
        public TimeOutTimer(
             Func<Task<bool>> condition,
             int conditionVerificationIntervalInMS,
             int timeOutIntervalInSeconds)
        {
            _condition = condition;
            _timeOutIntervalInSeconds = timeOutIntervalInSeconds;
            _timeOutTimer = new System.Timers.Timer(conditionVerificationIntervalInMS);
            _timeOutTimer.Elapsed += new System.Timers.ElapsedEventHandler(timer_tick);
            _timer = new Stopwatch();

            var tickInterval = conditionVerificationIntervalInMS;
            if (tickInterval > 1000) tickInterval = tickInterval % 1000;
            if (tickInterval > 500) tickInterval -= 500;
            _tickerCountCurrentValue = _tickerCount = (int)(1000.0 / tickInterval);
        }

        public void Start()
        {
            _timer.Start();
            _timeOutTimer.Start();
        }

        public EventHandler<EventArgs> ConditionVerified { get; set; }
        public EventHandler<EventArgs> TimeOut { get; set; }
        public EventHandler<EventArgs> Tick { get; set; }
        private bool _timer_tick_inProgress;
        private async void timer_tick(Object sender, ElapsedEventArgs e)
        {
            if (_timer_tick_inProgress) return;

            try
            {
                _timer_tick_inProgress = true;
                if (await _condition())
                {
                    this.ConditionVerifiedFlag = true;
                    _timeOutTimer.Stop();
                    ConditionVerified?.Invoke(sender, e);
                }
                else if (_timer.Elapsed.TotalSeconds >= _timeOutIntervalInSeconds)
                {
                    this.TimeOutFlag = true;
                    _timeOutTimer.Stop();
                    TimeOut?.Invoke(sender, e);
                }
                else if (--_tickerCountCurrentValue == 0)
                {
                    Tick?.Invoke(sender, e);
                    _tickerCountCurrentValue = _tickerCount;
                }
            }
            finally
            {
                _timer_tick_inProgress = false;
            }
        }

        public void Dispose()
        {
            if (_timeOutTimer != null)
            {
                _timeOutTimer.Elapsed -= new System.Timers.ElapsedEventHandler(timer_tick);
                _timeOutTimer.Dispose();
            }
        }
    }

}
