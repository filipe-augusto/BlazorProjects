using Microsoft.JSInterop;
using System;
using System.Timers;

namespace BlazorDisplayToastAutomatically
{
    public class ToastService : IDisposable
    {
        public event Action<string,string, ToastLevel> OnShow;
        public event Action OnHide;
        private Timer Countdown;
        private JSRuntime jSRuntime;

        public void ShowToast(string message, string titulo, ToastLevel level)
        {
            OnShow?.Invoke(message,titulo, level);
            ChamaJavaScript();
            StartCountdown();
        }

        private void ChamaJavaScript()
        {
            jSRuntime.InvokeVoidAsync("exibeToast");
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
                Countdown = new Timer(50000);
                Countdown.Elapsed += HideToast;
                Countdown.AutoReset = false;
            }
        }

        private void HideToast(object source, ElapsedEventArgs args)
        {
            OnHide?.Invoke();
        }

        public void Dispose()
        {
            Countdown?.Dispose();
        }
    }
}
