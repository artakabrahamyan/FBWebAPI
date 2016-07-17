using FBWA.Core.Models.RestAPI.Interfaces;

namespace FBWA.Core.Models.RestAPI.JSONRequest
{
    public class FeedInfoRequest : BaseRequest, IAccessTokenInfo, IBaseInfo
    {
        /// <summary>
        /// Access Token
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Posted topic Id
        /// </summary>
        public string id { get; set; }
    }
}
