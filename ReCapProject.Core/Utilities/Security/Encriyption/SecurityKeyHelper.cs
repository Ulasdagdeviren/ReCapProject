using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ReCapProject.Core.Utilities.Security.Encriyption
{
   public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securitykey)// web api den json dosyasında oluşturduğumuz securitykey
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitykey));// anahtarlar simetrik ve asimetrik olarak ayrılır
        }
    }
}
