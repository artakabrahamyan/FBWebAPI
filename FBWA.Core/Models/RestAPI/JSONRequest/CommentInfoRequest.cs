﻿using FBWA.Core.Models.RestAPI.Interfaces;

namespace FBWA.Core.Models.RestAPI.JSONRequest
{
    public class CommentInfoRequest : BaseRequest, IAccessTokenInfo, IBaseInfo
    {
        /// <summary>
        /// Access Token
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Comment Id
        /// </summary>
        public string id { get; set; }
    }
}
