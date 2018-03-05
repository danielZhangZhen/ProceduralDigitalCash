using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace WFDigitalCash.OKCoin
{
    class MD5Util
    {
        /// <summary>
        /// 生成签名结果(新版本使用)
        /// </summary>
        /// <param name="sArray">要签名的数组</param>
        /// <param name="secretKey">安全校验码</param>
        /// <returns>签名结果字符串</returns>
        public static string buildMysignV1(Dictionary<string, string> sArray,
            string secretKey)
        {
            string mysign = "";
            string prestr = createLinkString(sArray); // 把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
            prestr = prestr + "&secret_key=" + secretKey; // 把拼接后的字符串再与安全校验码连接起来
            mysign = getMD5String(prestr);
            return mysign;
        }
        /// <summary>
        /// 生成签名结果（老版本使用）
        /// </summary>
        /// <param name="sArray"> 要签名的数组</param>
        /// <param name="secretKey">安全校验码</param>
        /// <returns>签名结果字符串</returns>
        public static string buildMysign(Dictionary<string, string> sArray,
          string secretKey)
        {
            string mysign = "";
            try
            {
                string prestr = createLinkString(sArray); // 把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
                prestr = prestr + secretKey; // 把拼接后的字符串再与安全校验码直接连接起来
                mysign = getMD5String(prestr);
            }
            catch (Exception e)
            {
                throw e;
            }
            return mysign;
        }
        /// <summary>
        /// 把数组所有元素排序，并按照“参数=参数值”的模式用"&amp;"字符拼接成字符串;
        /// </summary>
        /// <param name="paras"> 需要排序并参与字符拼接的参数组</param>
        /// <returns>拼接后字符串</returns>
        /// 

        public static string createLinkString(Dictionary<string, string> paras)
        {
            List<string> keys = new List<string>(paras.Keys);

            var paraSort = from objDic in paras orderby objDic.Key ascending select objDic;
            string prestr = "";
            int i = 0;
            foreach (KeyValuePair<string, string> kvp in paraSort)
            {
                if (i == keys.Count() - 1)
                {
                    // 拼接时，不包括最后一个&字符
                    prestr = prestr + kvp.Key + "=" + kvp.Value;
                }
                else
                {
                    prestr = prestr + kvp.Key + "=" + kvp.Value + "&";
                }
                i++;
                if (i == keys.Count())
                {
                    break;
                }
            }
            return prestr;
        }


        private static char[] HEX_DIGITS = new char[]{'0', '1', '2', '3', '4', '5',
            '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
        /// <summary>
        /// 生成32位大写MD5值
        /// </summary>
        public static string getMD5String(string str)
        {

            if (str == null || str.Trim().Length == 0)
            {
                return "";
            }
            byte[] bytes = System.Text.Encoding.Default.GetBytes(str);
            MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
            bytes = md.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(HEX_DIGITS[(bytes[i] & 0xf0) >> 4] + ""
                        + HEX_DIGITS[bytes[i] & 0xf]);
            }
            return sb.ToString();
        }

    }
}
