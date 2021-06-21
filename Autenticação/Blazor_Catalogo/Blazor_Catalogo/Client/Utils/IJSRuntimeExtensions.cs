﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Catalogo.Client.Utils
{
    public  static class IJSRuntimeExtensions
    {
        public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content)
            => js.InvokeAsync<object>("localStorage.setITem", key, content);
        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js,
         string key) => js.InvokeAsync<string>("localStorage.getItem", key);
        public static ValueTask<object> RemoveItem(this IJSRuntime js, string key) =>
            js.InvokeAsync<object>("localStorage.removeItem", key);



    }
}
