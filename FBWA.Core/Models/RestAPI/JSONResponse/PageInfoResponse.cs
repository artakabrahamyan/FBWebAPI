using FBWA.Core.Models.RestAPI.Interfaces;

namespace FBWA.Core.Models.RestAPI.JSONResponse
{
    public class PageInfoResponse : BaseResponse, IPageInfo
    {
        /// <summary>
        /// Page Id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Page Name
        /// </summary>
        public string name { get; set; }
    }
}
