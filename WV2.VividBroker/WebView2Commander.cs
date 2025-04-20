using System;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.WinForms;

namespace WV2.VividBroker
{
    public abstract class WebView2Commander
    {
        protected WebView2 _wv;
        protected Func<string, string> _logger;
        public WebView2Commander(WebView2 wv,
                                  Func<string, string> logger = null)
        {
            _wv = wv;
            _logger = logger;
        }

        protected void log(string message)
        {
            _logger?.Invoke(message);
        }

        protected void inv(Action a)
        {
            if (_wv.InvokeRequired) _wv.Invoke(a); else a();
        }

        public void Navigate(string url)
        {
            inv(() => _wv.CoreWebView2.Navigate(url));
        }

        public async Task<string> ExecuteScriptAsync(string jsScript)
        {
            var result = string.Empty;
            Task<string> task = null;

            inv(() =>
            {
                task = _wv.ExecuteScriptAsync(jsScript);
            });

            await task.ContinueWith(
                (x) =>
                {
                    result = task.Result;
                },
                TaskScheduler.Current
            );
            return result;
        }

        public async Task<string> GetButtonCaption(string buttonSelector)
        {
            var jScriptCheck = $"document.querySelector('{buttonSelector}').innerText";
            var buttonCaption = await this.ExecuteScriptAsync(jScriptCheck);

            buttonCaption = (!string.IsNullOrWhiteSpace(buttonCaption)) ?
                            buttonCaption.Trim('"').Replace("null", "") :
                            string.Empty;
            return buttonCaption;
        }

        public async Task<bool> ClickButton(string buttonSelector)
        {
            if (string.IsNullOrWhiteSpace(await this.GetButtonCaption(buttonSelector))) return false;
            var jScriptClick = $"document.querySelector('{buttonSelector}').click()";
            await this.ExecuteScriptAsync(jScriptClick);
            return true;
        }

        public async Task DisplayAlert(string alertMessage)
        {
            await this.ExecuteScriptAsync($"window.alert('{alertMessage}')");
        }

    }
}
