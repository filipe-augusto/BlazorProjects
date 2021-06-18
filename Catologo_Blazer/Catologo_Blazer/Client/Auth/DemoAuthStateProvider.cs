using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace Catologo_Blazer.Client.Auth
{
    public class DemoAuthStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(4000);
            //indicamos se o usuario esta autenticado e tamb´me os seus claims
            var usuario = new ClaimsIdentity();
            return await Task.FromResult(new AuthenticationState(
                new ClaimsPrincipal(usuario)));
        }
    }
}
