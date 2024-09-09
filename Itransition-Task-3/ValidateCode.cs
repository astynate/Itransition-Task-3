using System.Security.Cryptography;
using System.Text;

namespace Itransition_Task_3
{
    public class ValidateCode
    {
        public string Key { get; private set; } = Guid.NewGuid().ToString();
        public string Value { get; private set; } = string.Empty;

        public ValidateCode(Moves move)
        {
            byte[] key = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }

            byte[] messageBytes = Encoding.UTF8.GetBytes(move.ToString());

            using (var hmac = new HMACSHA256(key))
            {
                byte[] hash = hmac.ComputeHash(messageBytes);
                Value = BitConverter.ToString(hash).Replace("-", "").ToLower();   
            }
        }
    }
}