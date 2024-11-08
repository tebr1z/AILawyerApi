using Google.Apis.Auth;
using HuquqApi.Model;
using HuquqApi.Service.Interfaces;
using HuquqApi.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HuquqApi.Service.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GetToken(IList<string>userRole,User user, JwtSetting jwtSetting)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {

               new Claim("id",user.Id),
               new Claim("UserName",user.UserName),
               new Claim("Email",user.Email),
               new Claim("FullName",user.FullName),
               new Claim("RequestCount",user.RequestCount.ToString("")),
               new Claim("LastQuestionDate",user.LastQuestionDate.ToString("dd-MM-yyyy HH:mm:ss")),
               new Claim("FullName",user.FullName),
                new Claim("IsPremium", user.IsPremium.ToString()),
                 new Claim("PremiumExpirationDate", user.PremiumExpirationDate?.ToString("dd-MM-yyyy HH:mm:ss") ?? string.Empty)
            };

            claims.AddRange(userRole.Select(r => new Claim(ClaimTypes.Role, r)).ToList());


            var audience = jwtSetting.Audience;

            var issuer = jwtSetting.Issuer;


            var sectoken = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(sectoken);
            return  token;
        }












        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string token)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _config["Authentication:Google:ClientId"] }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(token, settings);
            return payload;
        }

        public async Task<string> CreateTokenAsync(IList<string> userRole, User user, JwtSetting jwtSetting)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {

               new Claim("id",user.Id),
               new Claim("UserName",user.UserName),
               new Claim("Email",user.Email),
               new Claim("FullName",user.FullName)
               
            };

            claims.AddRange(userRole.Select(r => new Claim(ClaimTypes.Role, r)).ToList());


            var audience = jwtSetting.Audience;

            var issuer = jwtSetting.Issuer;


            var sectoken = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(sectoken);
            return token;

        }


    }
}
