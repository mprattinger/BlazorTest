using BlazorTest.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorizationCore();
            services.AddScoped<MyAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<MyAuthenticationStateProvider>());
            services.AddSingleton<B2CService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
