using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {

        public IConfiguration Configuration { get; } // appsetting.json'daki ilgili bölümü okumaya yarar
        private TokenOptions _tokenOptions; // TokenOptions appsetting.json'daki alanların karşılığı. TokenOptions bir helper classtır.
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); // appsettings içindeki "TokenOptions" bul ve içindeki değerleri TokenOptions sınıfının içine tek tek atar. GetSections seçim yapar.
          
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims) //Token oluştururken user ve claimi verdik.
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration); // token ne zaman expire olacak. tokenoptions'tan alıyor.
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); // tokenoptions'taki securitykey'i kullanarak oluşturduk
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey); // hangi algoritma ve anahtar nedir? CredentialsHelper'da bu soruların cevabı var.
            // ELİMİZDE ARTIK NE ZAMAN BİTECEĞİ, ANAHTAR, CREDENTIAL DEĞERLERİ HERŞEY VAR. YENİ AŞAMA TOKEN OPTIONLARI KULLANARAK:
            // TOKENOPTIONLARI KULLANARAK, İLGİLİ KULLANICI İÇİN, İLGİLİ CREDANTIELLERI KULLANARAK, BU USER İÇİN ATANACAK YETKİLERİ İÇEREN BİR TANE METOD YAZIYORUZ. CreateJwtSecurityToken altta oluşturulmuş.
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }  

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials,List<OperationClaim> operationClaims) // 34. satırda bahsedilen metod.
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims), //claimler bizim için önemli. 59. satırda claimler içinde bir metod yazdık.
                signingCredentials: signingCredentials);
            
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();//System.Security.Claims .NET içerisinde gelen namespace
            // Sürekli newleyerek birşey eklemek yerine extension yazarız. genişletiriz. varolan bir class'a kendi metodlarımızı ekleriz.
            // bunun için Core/Extensions/ClaimExtensions.cs ile bu işlemi yaptık. 
            // böylece claims. dediğimizde aşağıdaki addemail, addname gibi metodları çağırabiliyoruz.
            claims.AddNameIdentifier(user.UserId.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.OperationName).ToArray());

            return claims;
        }
    }
}
