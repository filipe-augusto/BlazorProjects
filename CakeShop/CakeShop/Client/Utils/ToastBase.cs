using BlazorDisplayToastAutomatically;
using Microsoft.AspNetCore.Components;
using System;

namespace CakeShop.Client.Utils
{
    public class ToastBase : ComponentBase
    {
        [Inject] ToastService ToastService { get; set; }

        protected string Heading { get; set; }
        protected string Message { get; set; }
        protected bool IsVisible { get; set; }
        protected string BackgroundCssClass { get; set; }
        protected string IconCssClass { get; set; }

        protected override void OnInitialized()
        {
            ToastService.OnShow += ShowToast;
            ToastService.OnHide += HideToast;
        }

        private void ShowToast(string message, string titulo, ToastLevel level)
        {
            BuildToastSettings(level, message,titulo);
            IsVisible = true;
            StateHasChanged();
        }

        private void HideToast()
        {
            IsVisible = false;
            StateHasChanged();
        }

        private void BuildToastSettings(ToastLevel level, string message, string titulo)
        {
            switch (level)
            {
                case ToastLevel.Info:
                    BackgroundCssClass = "info";
                    IconCssClass = "info";
                    Heading = titulo;
                    break;
                case ToastLevel.Success:
                    BackgroundCssClass = "success";
                    IconCssClass = "check";
                    Heading = titulo;
                    break;
                case ToastLevel.Warning:
                    BackgroundCssClass = "warning";
                    IconCssClass = "exclamation";
                    Heading = titulo;
                    break;
                case ToastLevel.Error:
                    BackgroundCssClass = "danger";
                    IconCssClass = "times";
                    Heading = titulo;
                    break;
            }

            Message = message;
        }

        public void Dispose()
        {
            ToastService.OnShow -= ShowToast;
        }
    }
}
