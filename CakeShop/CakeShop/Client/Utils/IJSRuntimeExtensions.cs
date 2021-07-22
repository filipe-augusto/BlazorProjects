using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace CakeShop.Client.Utils
{
    public static class IJSRuntimeExtensions
    {
        public static ValueTask<Object> SetInLocalStorage(this IJSRuntime js,
            string key, string content) => js.InvokeAsync<Object>("localStorage.setItem", key, content);

        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js,
           string key) => js.InvokeAsync<string>("localStorage.getItem", key);

        public static ValueTask<Object> RemoveItem(this IJSRuntime js,
          string key) => js.InvokeAsync<Object>("localStorage.removeItem", key);
    }
}
