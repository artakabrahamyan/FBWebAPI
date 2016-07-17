namespace FBWA.Core.Models.RestAPI.JSONResponse
{
    public class NoneJSONBaseResponse
    {
        /// <summary>
        /// Returned data
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Status code
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// Indicates whether the request is success or fault 
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public AccessTokenErrorResponse Error { get; set; }
    }
}
