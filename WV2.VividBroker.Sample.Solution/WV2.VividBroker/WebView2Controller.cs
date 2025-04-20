using System;
using System.Diagnostics;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace WV2.VividBroker
{
    public class WebView2Controller: WebView2Commander
    {
        public WebView2Controller(WebView2 wv,
                                    Func<string, string> logger = null) :
                                    base(wv, logger) { }

        public async Task Init()
        {
            var env = await CoreWebView2Environment.CreateAsync(null, null);
            await _wv.EnsureCoreWebView2Async(env);
        }

        private const int TIMER_TICK_INTERVAL_IN_MS = 50;
        private const int TIME_OUT_IN_SECONDS = 10;
        private ManualResetEvent _waitFlag;
        private TimeOutTimer _smartTimer;
        public EventHandler<EventArgs> ConditionVerified { get; set; }
        public EventHandler<EventArgs> TimeOut { get; set; }
        public EventHandler<EventArgs> Tick { get; set; }
        public double NavigationElapsedTimeInSeconds => _smartTimer.ElapsedTimeInSeconds;
        public async Task<bool> NavigateAndWaitForCondition(
                    string url,
                    Func<Task<bool>> condition,
                    int timerTickIntervalInMS = TIMER_TICK_INTERVAL_IN_MS,
                    int timeOutInSeconds = TIME_OUT_IN_SECONDS)
        {
            var conditionOK = false;
            _waitFlag = new ManualResetEvent(false);
            _smartTimer = new TimeOutTimer(
                            condition,
                            timerTickIntervalInMS,
                            timeOutInSeconds);
            _smartTimer.ConditionVerified += new EventHandler<EventArgs>(conditionVerified);
            _smartTimer.TimeOut += new EventHandler<EventArgs>(timeOut);
            _smartTimer.Tick += new EventHandler<EventArgs>(tick);

            try
            {
                this.Navigate(url);

                _smartTimer.Start();

                var sw = Stopwatch.StartNew();
                log($"Non-blocking wait started.");
                await Task.Run(() =>
                {
                    _waitFlag.WaitOne();
                });
                log($"Non-blocking wait completed, elapsed = {sw.Elapsed.TotalSeconds:0.000}s");

                if (_smartTimer.ConditionVerifiedFlag)
                {
                    log($"Condition verified, elaped time = {_smartTimer.ElapsedTimeInSeconds:0.000}s");
                    conditionOK = true;
                }
                else if (_smartTimer.TimeOutFlag)
                {
                    log($"Time-Out, elaped time = {_smartTimer.ElapsedTimeInSeconds:0.000}s");
                }
                else
                {
#if DEBUG
                    Debug.Assert(false, "It can never happen...");
#else
                    throw new ApplicationException("It can never happen, but...");
#endif
                }

            }
            finally
            {
                _smartTimer.ConditionVerified -= new EventHandler<EventArgs>(conditionVerified);
                _smartTimer.TimeOut -= new EventHandler<EventArgs>(timeOut);
                _smartTimer.Tick -= new EventHandler<EventArgs>(tick);
                _smartTimer.Dispose();
            }
            return conditionOK;
        }

        private void timeOut(Object sender, EventArgs e)
        {
            this?.TimeOut?.Invoke(sender, e);
            _waitFlag.Set();
        }

        private void conditionVerified(Object sender, EventArgs e)
        {
            this?.ConditionVerified?.Invoke(sender, e);
            _waitFlag.Set();
        }

        private void tick(Object sender, EventArgs e)
        {
            this?.Tick?.Invoke(sender, e);
        }
    }
}


