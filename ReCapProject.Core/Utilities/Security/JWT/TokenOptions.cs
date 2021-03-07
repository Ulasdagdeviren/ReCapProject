using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Core.Utilities.Security.JWT
{
   public class TokenOptions
    {
        public string Audience { get; set; } // token nın kullanıcı kitlesi
        public string Issuer { get; set; }// imzalayan gibi düşün
        public int AccessTokenExpiration { get; set; } //dakika cinsinden yazılır
        public string SecurityKey { get; set; } //
    }
}
