using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FBWA.Core.Models.RestAPI.Interfaces;
using FBWA.Core.Models.RestAPI.JSONResponse;

namespace FBWA.Core.Services.RestAPI
{
    public class RestRequestService : IRestRequestService
    {
        private readonly IRestClientService _restClientService;
        private readonly IErrorResponseBuilder _errorResponseBuilder;

        public RestRequestService(IRestClientService restClientService, IErrorResponseBuilder errorResponseBuilder)
        {
            _restClientService = restClientService;
            _errorResponseBuilder = errorResponseBuilder;
        }

        /// <summary>
        /// Build request for getting generic type of object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resourcePath"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<T> BuildEmptyRequest<T>(string resourcePath, string accessToken) where T : BaseResponse, new()
        {
            return await BuildRequest<T, IDisposable>(resourcePath, accessToken, null);
        }

        /// <summary>
        /// Build request for getting App Access Token
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resourcePath"></param>
        /// <returns></returns>
        public async Task<T> BuildAccessTokenRequest<T>(string resourcePath) where T : FacebookAuthResponse, new()
        {
            var clientResponse = new T();
            try
            {
                //Call Rest request and get App Access Token
                var result = await _restClientService.GetNoneJSON<AccessTokenErrorResponse>(resourcePath, string.Empty, null);

                //Validation
                if (result == null)
                {
                    clientResponse = new T
                    {
                        access_token = null,
                        error = _errorResponseBuilder.BuildErrorResponse(1, "The result is null"),
                        Success = false,
                        StatusCode = "1111"
                    };
                }
                else
                {
                    if (result.Success)
                    {
                        var data = result.Data;
                        var access_token = data.Substring(data.IndexOf("=") + 1, data.Length - data.IndexOf("=") - 1);
                        clientResponse = new T
                        {
                            access_token = access_token,
                            error = null,
                            Success = true,
                            StatusCode = string.Empty
                        };
                    }
                    else
                    {
                        clientResponse = new T
                        {
                            access_token = null,
                            error = result.Error.error,
                            Success = result.Success,
                            StatusCode = result.StatusCode
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("making request error report");
                var badRequest = Convert.ToInt32(System.Net.HttpStatusCode.BadRequest);
                clientResponse = new T
                {
                    access_token = null,
                    error = _errorResponseBuilder.BuildErrorResponse(badRequest, ex.Message),
                    Success = false,
                    StatusCode = badRequest.ToString()
                };
            }

            Debug.WriteLine("returning");
            return clientResponse;
        }

        /// <summary>
        /// Build request with generic type of object for getting another generic type of object
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="resourcePath"></param>
        /// <param name="accessToken"></param>
        /// <param name="clientRequest"></param>
        /// <returns></returns>
        public async Task<T1> BuildRequest<T1, T2>(string resourcePath, string accessToken, T2 clientRequest) where T1 : BaseResponse, new()
        {
            var clientResponse = new T1();

            try
            {
                //Call Rest request and get result
                clientResponse = await _restClientService.Get<T1>(resourcePath, string.Empty, null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("making request error report");
                var badRequest = Convert.ToInt32(System.Net.HttpStatusCode.BadRequest);
                clientResponse = new T1
                {
                    error = _errorResponseBuilder.BuildErrorResponse(badRequest, ex.Message),
                    Success = false,
                    StatusCode = badRequest.ToString()
                };
            }

            Debug.WriteLine("returning");
            return clientResponse;
        }
    }
}
