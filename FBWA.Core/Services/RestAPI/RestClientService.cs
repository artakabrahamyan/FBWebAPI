using FBWA.Core.Constants.RestAPI;
using FBWA.Core.Models.RestAPI.JSONError;
using FBWA.Core.Models.RestAPI.JSONResponse;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace FBWA.Core.Services.RestAPI
{
    public class RestClientService : IRestClientService
    {
        #region Private Fields
        /// <summary>
        /// The base Url for production enviroment
        /// </summary>
        #endregion

        #region Properties

        private string _jsonResultString;

        private string JsonResultString
        {
            get { return _jsonResultString; }
            set { _jsonResultString = value; }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Get method of Web API request and return generic type of object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlSegment"></param>
        /// <param name="userAgent"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public async Task<T> Get<T>(string urlSegment, string userAgent, string cookie) where T : BaseResponse, new()
        {
            T obj = new T();

            var handler = new HttpClientHandler { UseCookies = false };
            try
            {
                //Create the Http Rest client
                using (var client = new HttpClient(handler))
                {
                    var url = urlSegment;
                    if (!(url.IndexOf(URLConstants.PROTOCOL) == 0))
                        url = URLConstants.BASE_URL + url;

                    // Agent Headers 
                    var msg = CreateRequestMessage(userAgent, HttpMethod.Get, url, cookie);

                    var result = await client.SendAsync(msg);

                    //Convert the response to string
                    JsonResultString = await result.Content.ReadAsStringAsync();

                    WriteDebug(msg, result);

                    //Parse Json string to the Response entity
                    int statusCode = Convert.ToInt32(result.StatusCode);

                    obj = JsonConvert.DeserializeObject<T>(JsonResultString);
                    obj.StatusCode = statusCode.ToString();

                    if (!(200 <= statusCode && statusCode <= 299))
                        obj.Success = false;
                    else
                        obj.Success = true;
                }
            }
            catch (Exception ex)
            {
                obj = JsonConvert.DeserializeObject<T>(ex.Message);
                obj.Success = false;
                obj.StatusCode = "1";
            }

            return obj;
        }

        /// <summary>
        /// Get method of Web API request, and the result is not JSON formatted. 
        /// </summary>
        /// <typeparam name="UError"></typeparam>
        /// <param name="urlSegment"></param>
        /// <param name="userAgent"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public async Task<NoneJSONBaseResponse> GetNoneJSON<UError>(string urlSegment, string userAgent, string cookie) where UError : AccessTokenErrorResponse
        {
            var noneJSONBaseResponse = new NoneJSONBaseResponse();

            var handler = new HttpClientHandler { UseCookies = false };
            try
            {
                //Create the Http Rest client
                using (var client = new HttpClient(handler))
                {
                    var url = urlSegment;
                    if (!(url.IndexOf(URLConstants.PROTOCOL) == 0))
                        url = URLConstants.BASE_URL + url;

                    // Agent Headers 
                    var msg = CreateRequestMessage(userAgent, HttpMethod.Get, url, cookie);

                    var result = await client.SendAsync(msg);

                    //Convert the response to string
                    JsonResultString = await result.Content.ReadAsStringAsync();

                    WriteDebug(msg, result);

                    //Parse Json string to the Response entity
                    int statusCode = Convert.ToInt32(result.StatusCode);

                    noneJSONBaseResponse.StatusCode = statusCode.ToString();
                    if (!(200 <= statusCode && statusCode <= 299))
                    {
                        noneJSONBaseResponse.Success = false;
                        noneJSONBaseResponse.Error = JsonConvert.DeserializeObject<UError>(JsonResultString);
                    }
                    else
                    {
                        noneJSONBaseResponse.Success = true;
                        noneJSONBaseResponse.Data = JsonResultString;
                    }
                }
            }
            catch (Exception ex)
            {
                noneJSONBaseResponse.Success = false;
                noneJSONBaseResponse.Error = new AccessTokenErrorResponse()
                {
                    error = new ErrorDetail() { code = 1, message = ex.Message }
                };
            };

            return noneJSONBaseResponse;
        }

        /// <summary>
        /// Send the headers to API
        /// </summary>
        /// <param name="userAgent">The user Agent</param>
        /// <param name="method">The sent method</param>
        private HttpRequestMessage CreateRequestMessage(string userAgent, HttpMethod method, string url, string cookie)
        {
            // Add a new Request Message
            HttpRequestMessage requestMessage = new HttpRequestMessage(method, new Uri(url));

            //var mimeType = MimeTypesHelper.GetMimeType("json");

            // Add our custom headers
            if (!string.IsNullOrWhiteSpace(userAgent))
                requestMessage.Headers.Add("Authorization", userAgent);
            requestMessage.Headers.Add("Cache-Control", "no-cache");
            requestMessage.Headers.Add("pragma", "no-cache");
            if (!string.IsNullOrWhiteSpace(cookie))
                requestMessage.Headers.Add("Cookie", string.Format("ap_session={0}", cookie));

            return requestMessage;
        }

        /// <summary>
        /// Writes the debug request.
        /// </summary>
        /// <param name="msg">The current message request.</param>
        /// <param name="resultString">The result string.</param>
        /// <param name="content">The POST or PUT content.</param>
        private async static void WriteDebug(HttpRequestMessage msg, HttpResponseMessage response, string content = "")
        {
            Debug.WriteLine("________________________________");
            Debug.WriteLine("HttpRequestMessage");
            Debug.WriteLine("________________________________");
            Debug.WriteLine(msg.Method.ToString());
            Debug.WriteLine(msg.RequestUri.ToString());
            Debug.WriteLine(msg.Headers.ToString());
            var msgHeaders = msg.Content != null ? msg.Content.Headers.ToString() : string.Empty;
            Debug.WriteLineIf((msg.Method.Method == "POST" || msg.Method.Method == "PUT"), msgHeaders);
            Debug.WriteLineIf((msg.Method.Method == "POST" || msg.Method.Method == "PUT"), content);
            Debug.WriteLine("--------------------------------");
            Debug.WriteLine("HttpResponseMessage");
            Debug.WriteLine("--------------------------------");
            Debug.WriteLine(response.Headers.ToString());
            Debug.WriteLine(await response.Content.ReadAsStringAsync());
            Debug.WriteLine("________________________________");
        }

        #endregion
    }
}
