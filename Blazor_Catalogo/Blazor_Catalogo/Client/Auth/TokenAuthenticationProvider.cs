using Blazor_Catalogo.Client.Utils;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blazor_Catalogo.Client.Auth
{
    public class TokenAuthenticationProvider : AuthenticationStateProvider
    {

        private readonly IJSRuntime js;
        private readonly HttpClient http;
        public static readonly string tokenKey = "tokenKey";

        public TokenAuthenticationProvider(IJSRuntime iJSRuntime, HttpClient httpClient)
        {
            js = iJSRuntime;
            http = httpClient;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await js.GetFromLocalStorage(tokenKey);
        }
    }
}
