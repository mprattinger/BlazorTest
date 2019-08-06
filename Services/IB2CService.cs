using System.Threading.Tasks;

namespace BlazorTest.Services
{
    public interface IB2CService
    {
        string AccessToken { get; }
        string IdToken { get; }
        bool IsLoggedIn { get; }

        Task<string> Login();
    }
}