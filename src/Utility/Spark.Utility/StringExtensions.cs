using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Spark.Utility
{
    public static class StringExtensions
    {
        #region MD5

        public static string EncryptMD5(this string input)
        {
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                return BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(input))).Replace("-", string.Empty).ToLower();
            }
        }

        public static string EncryptShortMD5(this string input)
        {
            string Md5string = EncryptMD5(input);

            return Md5string.Substring(8, 16);
        }

        public static bool ValidateMD5(this string input, string encryptedValue)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            if (encryptedValue.Length == 16)
            {
                return input.EncryptShortMD5().Equals(encryptedValue);
            }
            else
            {
                return input.EncryptMD5().Equals(encryptedValue);
            }
        }

        #endregion MD5

        #region JSON序列化和反序列化

        public static T FromJson<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        public static string ToJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        #endregion JSON序列化和反序列化

        public static long ToInt64(this string input)
        {
            return Convert.ToInt64(input);
        }

        /// <summary>
        /// 根据GUID获取19位的唯一数字序列
        /// </summary>
        /// <returns></returns>
        public static long GuidToLongID(this Guid input)
        {
            byte[] buffer = input.ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        public static bool ValidateMobile(this string input)
        {
            string pattern = "^((1[358][0-9])|(14[57])|(17[0678])|(19[7]))\\d{8}$";
            return Regex.Match(input, pattern).Success;
        }

        public static bool StringCompare(this string source, string value, bool ignoreCase = true)
        {
            if (ignoreCase)
            {
                if (source.ToLower() == value.ToLower())
                    return true;
                else
                    return false;
            }
            else
            {
                if (source == value)
                    return true;
                else
                    return false;
            }
        }

    }
}