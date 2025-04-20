using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WV2.VividBroker.NetFramework.WinFormsApp
{
    public partial class TestForm: Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private string _url = "https://stackoverflow.com/";
        private string _startUpUrl = "https://bing.com/";
        private WebView2Controller _wvc;
        private async void TestForm_Load(Object sender, EventArgs e)
        {
            _wvc = new WebView2Controller(mainWebView, log);
            await _wvc.Init();

            await navigate(_startUpUrl);
        }

        private async Task navigate(string url)
        {
            mainWebView.CoreWebView2.Navigate(url);
            await Task.CompletedTask;
        }

        private async void cmdGoToStartWebPage_Click(Object sender, EventArgs e)
        {
            clearLog();
            await navigate(_startUpUrl);
        }

        private string askQuestionButtonSelector => "#mainbar > div.d-flex.fw-wrap.mb12 > div > a";
        private async Task<string> askQuestionButtonCaption()
        {
            return await _wvc.GetButtonCaption(askQuestionButtonSelector);
        }
        private async Task<bool> askQuestionButtonFound()
        {
            return !string.IsNullOrWhiteSpace(await askQuestionButtonCaption());
        }

        private void askQuestionButtonAvailable(Object sender, EventArgs e)
        {
            log($"'Ask Question' button available, elaped time = {_wvc.NavigationElapsedTimeInSeconds:0.000}s");
        }

        private void askQuestionButtonWaitingTimeOut(Object sender, EventArgs e)
        {
            log($"'Time-Out' event fired, elaped time = {_wvc.NavigationElapsedTimeInSeconds:0.000}s");
        }

        private void tick(Object sender, EventArgs e)
        {
            log($"Tick: Elapsed time {_wvc.NavigationElapsedTimeInSeconds:#0.0}s");
        }

        private async void cmdNavigateAndWait_Click(Object sender, EventArgs e)
        {
            try
            {
                clearLog();

                _wvc.ConditionVerified += new EventHandler<EventArgs>(askQuestionButtonAvailable);
                _wvc.TimeOut += new EventHandler<EventArgs>(askQuestionButtonWaitingTimeOut);
                _wvc.Tick += new EventHandler<EventArgs>(tick);

                if (!await _wvc.NavigateAndWaitForCondition(_url, askQuestionButtonFound))
                {
                    log("[Ask Question] button not found");
                }
            }
            finally
            {
                _wvc.ConditionVerified -= new EventHandler<EventArgs>(askQuestionButtonAvailable);
                _wvc.TimeOut -= new EventHandler<EventArgs>(askQuestionButtonWaitingTimeOut);
                _wvc.Tick -= new EventHandler<EventArgs>(tick);
            }
        }

        private async void cmdAskQuestion_Click(Object sender, EventArgs e)
        {
            //<a href="/questions/ask" class="ws-nowrap s-btn s-btn__filled">
            //        Ask Question
            //</a>
            try
            {
                clearLog();
                var buttonCaption = "Ask Question";
                var alertMessage = "";

                _wvc.ConditionVerified += new EventHandler<EventArgs>(askQuestionButtonAvailable);
                _wvc.TimeOut += new EventHandler<EventArgs>(askQuestionButtonWaitingTimeOut);
                _wvc.Tick += new EventHandler<EventArgs>(tick);

                if (await _wvc.NavigateAndWaitForCondition(_url, askQuestionButtonFound))
                {
                    if (await _wvc.ClickButton(askQuestionButtonSelector))
                    {
                        alertMessage = log($"[{buttonCaption}] button clicked.");
                        await _wvc.DisplayAlert(alertMessage);
                    }
                    else
                    {
                        alertMessage = log($"Failed to click [{buttonCaption}] button.");
                        await _wvc.DisplayAlert(alertMessage);
                    }
                }
                else
                {
                    alertMessage = log($"[{buttonCaption}] button not found.");
                    await _wvc.DisplayAlert(alertMessage);
                }
            }
            finally
            {
                _wvc.ConditionVerified -= new EventHandler<EventArgs>(askQuestionButtonAvailable);
                _wvc.TimeOut -= new EventHandler<EventArgs>(askQuestionButtonWaitingTimeOut);
                _wvc.Tick += new EventHandler<EventArgs>(tick);
            }

        }

        private void inv(Action a)
        {
            if (this.InvokeRequired) this.Invoke(a);
            else a();
        }
        private string log(string message)
        {
            inv(() =>
            {
                if (!string.IsNullOrWhiteSpace(txtLog.Text)) txtLog.Text += System.Environment.NewLine;
                txtLog.Text += message;  
            });
            return message;
        }
        private void clearLog()
        {
            inv(()=>txtLog.Clear());
        }
    }
}
