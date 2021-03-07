using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ReCapProject.Core.Utilities.Security.Encriyption
{
   public class SigningCredentialHelper // security key ve algoritmalarımızı belirlediğimiz bir nesnedir
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)// JWT larının oluşturuması için sistemi kullanabilmek için gerekenler
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature); // imzalama nesnesine dönüştürecek
        }
    }
}
