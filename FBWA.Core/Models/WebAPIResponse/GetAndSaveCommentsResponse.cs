using FBWA.Core.Models.RestAPI.JSONResponse;

namespace FBWA.Core.Models.WebAPIResponse
{
    public class GetAndSaveCommentsResponse : BaseResponse
    {
        /// <summary>
        /// Returning message about the request process.
        /// </summary>
        public string message { get; set; }
    }
}
