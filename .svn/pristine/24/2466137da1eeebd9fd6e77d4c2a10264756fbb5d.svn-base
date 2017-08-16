
using System;
using System.Security.Cryptography;
using System.Text;

namespace IMIC.CONTROLLERS.Securities
{
    public class SecurityConexts
    {
        #region "9. Encrypt And Decrypt Information"

        private const string KEY = "imic.edu.vn, key provided by Doannv";
        private const string IV = "imiC+EDIFsA=";

        /// <summary>
        /// Nghiệp vụ Mã Hóa Thông Tin
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string EncryptInfo(string Input)
        {
            if (Input.Length == 0)
                return Input;
            byte[] Code = ASCIIEncoding.ASCII.GetBytes(Input);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] Key = md5.ComputeHash(Encoding.Unicode.GetBytes(KEY));
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = Key;
            tripleDES.IV = Convert.FromBase64String(IV);
            return Convert.ToBase64String(tripleDES.CreateEncryptor().TransformFinalBlock(Code, 0, Code.Length));
        }

        /// <summary>
        /// Nghiệp vụ giải mã thông tin
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string DecryptInfo(string Input)
        {
            if (Input.Length == 0)
                return Input;
            byte[] Code = Convert.FromBase64String(Input);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] Key = md5.ComputeHash(Encoding.Unicode.GetBytes(KEY));
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = Key;
            tripleDES.IV = Convert.FromBase64String(IV);
            return ASCIIEncoding.ASCII.GetString(tripleDES.CreateDecryptor().TransformFinalBlock(Code, 0, Code.Length));
        }

        #endregion "9. Encrypt And Decrypt Information"
    }
}