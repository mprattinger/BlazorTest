
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorTest.Services {
    public class B2CService : IB2CService
    {
        private readonly IJSRuntime _jsRuntime;

        public bool IsLoggedIn { get; private set; }
        public string AccessToken { get; private set; }
        public string IdToken { get; private set; }

        public B2CService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public Task<string> Login()
        {
            return _jsRuntime.InvokeAsync<string>("theAuth.sign_in");
            //return _jsRuntime.InvokeAsync<string>("myPromiseFn");
        }
    }
}