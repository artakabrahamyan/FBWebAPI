using FBWA.Core.Models.RestAPI.Interfaces;

namespace FBWA.Core.Models.RestAPI.JSONRequest
{
    public class FacebookAuthRequest : BaseRequest, IFacebookAppInfo
    {
        /// <summary>
        /// Facebook application id
        /// </summary>
        public string AppID { get; set; }

        /// <summary>
        /// Facebook application secret key
        /// </summary>
        public string AppSecretKey { get; set; }
    }
}
