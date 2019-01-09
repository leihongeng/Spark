using System;
using System.Text;

namespace Spark.Utility
{
    public class RandomUtil
    {
        public static string Next(int count)
        {
            string buffer = "0123456789";// 随机字符中也可以为汉字（任何）
            StringBuilder sb = new StringBuilder();
            Random r = new Random();
            int range = buffer.Length - 1;
            for (int i = 0; i < count; i++)
            {
                sb.Append(buffer.Substring(r.Next(range), 1));
            }
            return sb.ToString();
        }
    }
}
