using System.Security.Cryptography;
using System.Text;

namespace Itransition_Task_3
{
    public class ValidationCode
    {
        public string Key { get; private set; } = string.Empty;
        public string Value { get; private set; } = string.Empty;

        public ValidationCode(string move)
        {
            byte[] key = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }

            byte[] messageBytes = Encoding.UTF8.GetBytes(move);

            using (var hmac = new HMACSHA256(key))
            {
                byte[] hash = hmac.ComputeHash(messageBytes);

                Key = BitConverter.ToString(key);
                Value = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}