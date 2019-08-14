
using System;
using System.Threading.Tasks;
using BlazorTest.Models;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace BlazorTest.Services {
    public class B2CService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly MyAuthenticationStateProvider _myAuthenticationStateProvider;

        public bool IsLoggedIn { get; private set; }
        public string AccessToken { get; private set; }
        public string IdToken { get; private set; }

        public B2CService(IJSRuntime jsRuntime, MyAuthenticationStateProvider myAuthenticationStateProvider)
        {
            _jsRuntime = jsRuntime;
            _myAuthenticationStateProvider = myAuthenticationStateProvider;
        }

        public Task<string> GetTokenAsync()
        {
            //return _jsRuntime.InvokeAsync<object>("B2CService.login");
            return _jsRuntime.InvokeAsync<string>("B2CService.login", DotNetObjectRef.Create(this));

            //var token = await _jsRuntime.InvokeAsync<object>("B2CService.login");
            ////return _jsRuntime.InvokeAsync<string>("myPromiseFn");

            //return token.ToString();
        }

        [JSInvokable]
        public void HandleLoginSuccess(string jsonData)
        {
            var msal = JsonConvert.DeserializeObject<AuthResp>(jsonData);
            AccessToken = msal.AccessToken;

            Console.WriteLine("Reveived auth response. Authorizing user...");
            StaticStore.AuthResult = msal;

            _myAuthenticationStateProvider.ReAuthenticate();
            
        }
    }
}