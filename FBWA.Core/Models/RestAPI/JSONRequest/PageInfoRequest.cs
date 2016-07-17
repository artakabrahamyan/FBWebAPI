using FBWA.Core.Models.RestAPI.Interfaces;

namespace FBWA.Core.Models.RestAPI.JSONRequest
{
    public class PageInfoRequest : BaseRequest, IAccessTokenInfo, IBaseInfo
    {
        /// <summary>
        /// Access Token
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Facebook page id
        /// </summary>
        public string id { get; set; }
    }
}
