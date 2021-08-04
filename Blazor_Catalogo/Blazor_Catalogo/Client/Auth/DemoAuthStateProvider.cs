﻿using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blazor_Catalogo.Client.Auth
{
    public class DemoAuthStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(4000);
            //indicamos se o usuário esta autenticado e também os seus claims
            // var usuario = new ClaimsIdentity();
            //   var usuario = new ClaimsIdentity("demo");
            var usuario = new ClaimsIdentity(new List<Claim>() {
            new Claim("Chave","Valor"),
            new Claim(ClaimTypes.Name,"Filipe Augusto ") 
           ,new Claim(ClaimTypes.Role,"Admin")
            },"demo");

            return await Task.FromResult(new AuthenticationState(
                new ClaimsPrincipal(usuario)));
        }
    }
}
