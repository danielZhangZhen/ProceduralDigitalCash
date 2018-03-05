using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WFDigitalCash.OKCoin
{
    class HttpUtilMgr
    {
        private static readonly Lazy<HttpUtilMgr> _instance = new Lazy<HttpUtilMgr>(() => new HttpUtilMgr());

        public static HttpUtilMgr Ins
        {
            get
            {
                return _instance.Value;
            }
        }

        /// <summary>
        /// 发送get请求得到响应内容
        /// </summary>
        /// <param name="url_prex">url前缀</param>
        /// <param name="url">请求路径url</param>
        /// <param name="param">请求参数键值对</param>
        /// <returns>响应字符串</returns>
        public string requestHttpGet(string url_prex, string url, string param)
        {
            string responseContent = "";
            HttpWebResponse httpWebResponse = null;
            StreamReader streamReader = null;
            try
            {
                url = url_prex + url;
                if (param != null && !param.Equals(""))
                {
                    url = url + "?" + param;
                }
                Console.WriteLine(url);
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                if (streamReader == null)
                {
                    return "";
                }
                responseContent = streamReader.ReadToEnd();
                if (responseContent == null || "".Equals(responseContent))
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (httpWebResponse != null)
                {
                    httpWebResponse.Close();

                }
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
            return responseContent;
        }
        /// <summary>
        /// 发送post请求得到响应内容
        /// </summary>
        /// <param name="url_prex">url前缀</param>
        /// <param name="url">请求路径url</param>
        /// <param name="paras">请求数据键值对</param>
        /// <returns>响应字符串</returns>
        public string requestHttpPost(string url_prex, string url, Dictionary<string, string> paras)
        {
            string responseContent = "";
            HttpWebResponse httpWebResponse = null;
            StreamReader streamReader = null;
            try
            {  //组装访问路径
                url = url_prex + url;
                //根据url创建HttpWebRequest对象
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                //设置请求方式和头信息
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                //遍历参数集合
                if (!(paras == null || paras.Count == 0))
                {
                    StringBuilder buffer = new StringBuilder();
                    int i = 0;
                    foreach (string key in paras.Keys)
                    {
                        if (i > 0)
                        {
                            buffer.AppendFormat("&{0}={1}", key, paras[key]);
                        }
                        else
                        {
                            buffer.AppendFormat("{0}={1}", key, paras[key]);
                        }
                        i++;
                    }
                    byte[] btBodys = Encoding.UTF8.GetBytes(buffer.ToString());
                    httpWebRequest.ContentLength = btBodys.Length;
                    //将请求内容封装在请求体中
                    httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);
                }
                //获取响应
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                //得到响应流
                streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                //读取响应内容
                responseContent = streamReader.ReadToEnd();
                //关闭资源
                httpWebResponse.Close();
                streamReader.Close();
                //返回结果
                if (responseContent == null || "".Equals(responseContent))
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (httpWebResponse != null)
                {
                    httpWebResponse.Close();

                }
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
            return responseContent;
        }

    }
}
