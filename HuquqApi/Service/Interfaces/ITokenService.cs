using Google.Apis.Auth;
using HuquqApi.Model;
using HuquqApi.Settings;

namespace HuquqApi.Service.Interfaces
{
    public interface ITokenService
    {
        string GetToken(IList<string> userRole,User user, JwtSetting jwtSetting);
        Task<string> CreateTokenAsync(IList<string> roles, User user, JwtSetting jwtSetting);
        Task<Google.Apis.Auth.GoogleJsonWebSignature.Payload> VerifyGoogleToken(string token);
    }
}
