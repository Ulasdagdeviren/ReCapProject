using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;

namespace ReCapProject.Core.Extensions
{
    public static class ClaimExtensions // bir extensions class yazmamız için method ve class static olmalı bu classı genişletmek demek
    {
        public static void AddEmail(this ICollection<Claim> claims, string email) // claimin içinde addEmaili görmek istioyurz
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email)); // bunu email kısmına kaydet demek
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
