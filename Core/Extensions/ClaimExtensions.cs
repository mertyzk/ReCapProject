using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email) // bu metod sayesinde claims.AddEmail diye ekleyebileceğiz. Normalde 13. satırdaki gibi eklenecekti.
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email)); // metod sayesinde böyle bir ekleme yapmaktan kurtulup claims.AddEmail olarak kullanabileceğiz.
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles) // bana gönderilen rolleri (string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role))); // listey çevir [roles.ToList()] ve tek tek dolaş .ForEach ile her birini tek tek dolaş.
            // her birini (role =>) , git claim et [claims.Add(new Claim(ClaimTypes.Role, role)]
        }
    }
}
