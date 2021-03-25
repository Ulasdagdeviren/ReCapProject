using System;

using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Core.Extensions;
using ReCapProject.Core.Utilities.Security.Encriyption;

namespace ReCapProject.Core.Utilities.Security.JWT
{
    //// public IConfiguration Configuration { get; } // biizm apideki json dosyasındakileri okumamıza yarıyor
    //private TokenOptions _tokenOptions;// okuduğumuz değerleri buraya atıcaz lakin bu nesneyi oluşturmadık
    //private DateTime _accessTokenExpiration; // Access token ne zman geçerisileşecek
    public class JwtHelper : ITokenHelper
    {
        private IConfiguration Configuration { get; } // konfigürasyon dosyasını okuyacaz wep api dışında da kullanılır appsetting okuyacaz
        private TokenOptions TokenOptions { get; }  // token option alanımız vardı json da
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            TokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); // burda tokenoptionsları çekip nesneye aktardık keyi get içine aktardık
            _accessTokenExpiration = DateTime.Now.AddMinutes(TokenOptions.AccessTokenExpiration); // yazmış olduğumuz 10 dk yı ekledik
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(TokenOptions.SecurityKey); // oluşturulan tokenı encrypt ederken kendimzie ait anahtar lazım
            var signingCredentials = SigningCredentialHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(TokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore:DateTime.UtcNow,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }
        // olmayan bir şeye yeni methodlar ekleme extensions denir genişletmek yani
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims) // jwt nin içinde yalnızca yetki olmuyor başka bilgiler de olabilir claim 
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString()); // bunlar claims .net core da var içinde yok olduğu için Extensions oluşturdujk
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}"); // hoş geldin engin demiroğ gibi 
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
