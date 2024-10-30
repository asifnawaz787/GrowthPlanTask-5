using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace WebApplication9.ProblemFactory
{
    public class HashKey : IHasher
    {
        public string Hash(string plainText)
        {
            var hashBytes = KeyDerivation.Pbkdf2(password: plainText, salt: Generate128BitSalt(),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 1000000, numBytesRequested: 256 / 8);
            return plainText;
        }

        public bool VerifyPassword(string plainText, string hash)
        {
            return String.CompareOrdinal(plainText, hash)==0;
        }
       public byte[] Generate128BitSalt()
        {
            var salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

       
        
    }

    public interface IHasher
    {
        string Hash(string plainText);
        bool VerifyPassword(string plainText, string hash);
        byte[] Generate128BitSalt();



    }
}
