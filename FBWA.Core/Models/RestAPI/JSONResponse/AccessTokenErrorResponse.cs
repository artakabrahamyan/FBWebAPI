using FBWA.Core.Models.RestAPI.JSONError;

namespace FBWA.Core.Models.RestAPI.JSONResponse
{
    public class AccessTokenErrorResponse
    {
        /// <summary>
        /// Error
        /// </summary>
        public ErrorDetail error { get; set; }
    }
}
