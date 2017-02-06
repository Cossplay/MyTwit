
using System.Security.Cryptography;
using System.Text;


namespace MyTwit.Util
{
    public static class Hash
    {
        public static string CreateMd5(string input)
        {
            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                var sb = new StringBuilder();
                foreach (var b in data)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public static bool VerifyMd5Hash(string input, string hash)
        {
            var hashOfinput = CreateMd5(input);
            return hashOfinput.Equals(hash);
        }
    }
}