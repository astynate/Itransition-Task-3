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
            Key = Guid.NewGuid().ToString();

            var messageBytes = Encoding.UTF8.GetBytes(move);
            var keyAsBytes = Encoding.UTF8.GetBytes(Key);

            Value = ByteArrayToHex(HMACSHA256.HashData(keyAsBytes, messageBytes));
        }

        static string ByteArrayToHex(byte[] buff)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < buff.Length; i++)
            {
                stringBuilder.Append(buff[i].ToString("x2"));
            }
            
            return stringBuilder.ToString();
        }
    }
}