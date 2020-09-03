using System;
using System.IO;
using System.Net;

namespace RecruitmentPortal.Zest.Common.APIHelpers
{
    public static class CommonApiHelper
    {
        /// <summary>
        /// Call Get Method
        /// </summary>
        /// <param name="urlParameter"></param>
        /// <param name="isTokenRequired"></param>
        /// <returns></returns>
        public static string GetData(string urlParameter, bool isTokenRequired = false)
        {
            string response = string.Empty;

            try
            {
                ServicePointManager.Expect100Continue = false;

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}", "http://localhost:49833/", urlParameter));
              
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Call Post Method
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="apiMethod"></param>
        /// <param name="isTokenRequired"></param>
        /// <returns></returns>
        public static string PostData(string jsonData, string apiMethod, bool isTokenRequired = false)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}", "http://localhost:49833/", apiMethod));
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
