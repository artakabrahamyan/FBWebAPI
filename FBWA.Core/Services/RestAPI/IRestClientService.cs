using FBWA.Core.Models.RestAPI.JSONResponse;
using System.Threading.Tasks;

namespace FBWA.Core.Services.RestAPI
{
    public interface IRestClientService
    {
        /// <summary>
        /// Get method of Web API request and return generic type of object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlSegment"></param>
        /// <param name="userAgent"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        Task<T> Get<T>(string urlSegment, string userAgent, string cookie) where T : BaseResponse, new();

        /// <summary>
        /// Get method of Web API request, and the result is not JSON formatted.
        /// </summary>
        /// <typeparam name="UError"></typeparam>
        /// <param name="urlSegment"></param>
        /// <param name="userAgent"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        Task<NoneJSONBaseResponse> GetNoneJSON<UError>(string urlSegment, string userAgent, string cookie) where UError : AccessTokenErrorResponse;
    }
}
