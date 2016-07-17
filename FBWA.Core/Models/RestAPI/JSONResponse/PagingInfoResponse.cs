using FBWA.Core.Models.RestAPI.Interfaces;

namespace FBWA.Core.Models.RestAPI.JSONResponse
{
    public class PagingInfoResponse : BaseResponse, IPagingInfo
    {
        /// <summary>
        /// URL string for next pagination.
        /// </summary>
        public string next { get; set; }

        /// <summary>
        /// URL string for previous pagination.
        /// </summary>
        public string previous { get; set; }
    }
}
