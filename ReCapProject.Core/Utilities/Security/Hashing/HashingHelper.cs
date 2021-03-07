using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)// passwordun hashini oluşturacak out gönderilern değer boş bile olsa doldurup geri gönderir
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) // hmac creagrofy clasına denk geliyor
            {
                passwordSalt = hmac.Key; // her kullanıcı için bir key oluşturur 
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));// bir şeyin byte karşılığı almış olduk
            }
        } // bir şifreyi çözerken salta ihtiyaç var

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) // tekrardan girmeye çalıştığı parola yani doğrulama
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) // hmac creagrofy clasına denk geliyor
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)// üstteki byte array dödürür karşılaırma yapcaz 
                {
                    if (computedHash[i]!=passwordHash[i]) // iki hash karşılaştırması kendimin ki ile ver tabanı
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
