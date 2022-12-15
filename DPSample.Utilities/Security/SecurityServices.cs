using System.Security.Cryptography;
using System.Text;

namespace DPSample.Utilities.Security
{
    public class SecurityServices : ISecurityServices
    {
        public string CreatePasswordHash(string password, string salt)
        {
            string saltAndPwd = String.Concat(password, salt);
            var sha512 = SHA512.Create();
            var hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(saltAndPwd));
            return Convert.ToBase64String(hash);
        }

        public string CreateRandomSalt()
        {
            int size = 16;
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }
    }
}