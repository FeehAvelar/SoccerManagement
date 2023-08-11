using System.Security.Cryptography;
using System.Security.Policy;

namespace SoccerManagement.Services
{
    public class EncryptService
    {
        private static readonly int _keySize = 64;        
        
        public static string EncryptPassword(string password, out byte[] salt)
        {
            //refers: https://code-maze.com/csharp-hashing-salting-passwords-best-practices/

            salt = RandomNumberGenerator.GetBytes(_keySize);            
            
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, 1000, HashAlgorithmName.SHA512, _keySize);

            return Convert.ToHexString(hash);
        }

        public static bool VerifyPassword(string password, byte[] salt, string hashSenha)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, 1000, HashAlgorithmName.SHA512, _keySize);

            var retorno = CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hashSenha));

            return retorno;
        }

    }
}
