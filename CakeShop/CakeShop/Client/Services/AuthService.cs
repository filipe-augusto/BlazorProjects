//using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
//using MXSystem.Client.Auth;
//using MXSystem.Client.Utils;
//using MXSystem.Shared.Model.Usuario;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CakeShop.Client.Services
{
    //public class AuthService : IAuthService
    //{
    //    private readonly IJSRuntime _js;
    //    private readonly HttpClient _http;
    //    private readonly AuthenticationStateProvider _authenticationStateProvider;

    //    public AuthService(IJSRuntime jSRuntime, HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider)
    //    {
    //        _authenticationStateProvider = authenticationStateProvider;
    //        _http = httpClient;
    //        _js = jSRuntime;
    //    }



    //    public async Task Logout()
    //    {
    //        try
    //        {
    //            await _js.RemoveItem("tokenKey");
    //            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
    //            _http.DefaultRequestHeaders.Authorization = null;
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }

    //    public async Task<UsuarioToken> Login(UsuarioInfo usuario)
    //    {
    //        var loginJson = JsonSerializer.Serialize(usuario);
    //        var result = await _http.PostAsync("api/account/login", new StringContent(loginJson, Encoding.UTF8, "application/json"));
    //        var loginResult = JsonSerializer.Deserialize<UsuarioToken>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    //        if (!result.IsSuccessStatusCode)
    //        {
    //            return loginResult;
    //        }

    //        await _js.SetInLocalStorage("tokenKey", loginResult.Token);
    //        ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAuthenticated(usuario.Email);
    //        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("baerer", loginResult.Token);

    //        return loginResult;
    //    }
    //    public async Task<string> GetId()
    //    {
    //        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
    //        return authState.User.Claims.Where(c => c.Type == "IdUsuario").FirstOrDefault().Value.ToString();
    //    }
    //}


}
