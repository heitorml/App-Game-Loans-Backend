using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AppGameLoans.Utilities.Util
{
    public class SecurityUtil
    {
        public static string GenerateSHA256Hash(string data)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var salt = "myawesomesaltforinvillia";
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(salt + data));
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    stringBuilder.Append(hash[i].ToString("x2")); // two hexadecimals uppercase
                }
                return stringBuilder.ToString();
            }
        }
        public static string Decrypt(string encryptedText, string password)
        {
            if (encryptedText == null)
            {
                return null;
            }

            if (password == null)
            {
                password = String.Empty;
            }

            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesDecrypted = SecurityUtil.Decrypt(bytesToBeDecrypted, passwordBytes);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }
        private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
        public static string GerarSenhaAleatoria(int? quantidade = 8)
        {
            string senha = "";

            char[] caracters = new char[] {'Q','W','E','R','T','Y','U','I','O','P','A','S','D','F','G','H','J','K','L','Z','X','C','V','B','N','M',
                                           'q','w','e','r','t','y','u','i','o','p','a','s','d','f','g','h','j','k','l','z','x','c','v','b','n','m',
                                           '@','1','2','3','4','5','6','7','8','9','0'};

            Random rndPosition = new Random();

            int i = 0;
            int[] numbPositions = new int[2];

            while (i < 2)
            {
                numbPositions[i] = rndPosition.Next(0, 7);
                i++;
            }

            int upperPosition = rndPosition.Next(0, 7);

            Random r = new Random();

            for (i = 0; i < quantidade; i++)
            {
                char[] temp = caracters;

                if (numbPositions.Contains(i))
                    temp = caracters.Where(c => char.IsNumber(c)).ToArray();

                if (upperPosition == i)
                    temp = caracters.Where(c => char.IsUpper(c)).ToArray();

                senha += temp[r.Next(0, temp.Length)].ToString();
            }

            return senha.Trim();
        }
    }
}
