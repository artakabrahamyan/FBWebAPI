using FBWA.Core.Models.RestAPI.Interfaces;

namespace FBWA.Core.Models.RestAPI.JSONResponse
{
    public class FacebookAuthResponse : BaseResponse, IAccessTokenInfo
    {
        /// <summary>
        /// Facebook Access Token
        /// </summary>
        public string access_token { get; set; }
    }
}
