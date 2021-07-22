using Microsoft.JSInterop;
using System;
using System.Timers;

namespace BlazorDisplayToastAutomatically
{
    public class AlertService : IDisposable
    {
        public event Action<string, string, ToastLevel> OnShow;
        public event Action OnHide;
        private Timer Countdown;
        private JSRuntime jSRuntime;

        public void ShowAlert(string message, string titulo, ToastLevel level)
        {
            OnShow?.Invoke(message, titulo, level);
            ChamaJavaScript();
            StartCountdown();
        }

        private void ChamaJavaScript()
        {
            jSRuntime.InvokeVoidAsync("exibeAlert");
        }

        private void StartCountdown()
        {
            SetCountdown();

            if (Countdown.Enabled)
            {
                Countdown.Stop();
                Countdown.Start();
            }
            else
            {
                Countdown.Start();
            }
        }

        private void SetCountdown()
        {
            if (Countdown == null)
            {
                Countdown = new Timer(10000);
                Countdown.Elapsed += HideAlert;
                Countdown.AutoReset = false;
            }
        }

        private void HideAlert(object source, ElapsedEventArgs args)
        {
            OnHide?.Invoke();
        }

        public void Dispose()
        {
            Countdown?.Dispose();
        }
    }
}
