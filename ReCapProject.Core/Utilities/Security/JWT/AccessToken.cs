using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Core.Utilities.Security.JWT
{
   public class AccessToken  // Token bilgilerini tuttuğumuz kısım
    {
        public string Token { get; set; } //Token değeri
        public DateTime Expiration { get; set; } // Token geçerlilik süresi
    

    }
}
