using FBWA.Core.Models.RestAPI.JSONResponse;
using System.Threading.Tasks;

namespace FBWA.Core.Services.RestAPI
{
    public interface IRestRequestService
    {
        /// <summary>
        /// Build request for getting App Access Token
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resourcePath"></param>
        /// <returns></returns>
        Task<T> BuildAccessTokenRequest<T>(string resourcePath) where T : FacebookAuthResponse, new();

        /// <summary>
        /// Build request for getting generic type of object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resourcePath"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<T> BuildEmptyRequest<T>(string resourcePath, string accessToken) where T : BaseResponse, new();

        /// <summary>
        /// Build request with generic type of object for getting another generic type of object
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="resourcePath"></param>
        /// <param name="accessToken"></param>
        /// <param name="clientRequest"></param>
        /// <returns></returns>
        Task<T1> BuildRequest<T1, T2>(string resourcePath, string accessToken, T2 clientRequest) where T1 : BaseResponse, new();
    }
}
