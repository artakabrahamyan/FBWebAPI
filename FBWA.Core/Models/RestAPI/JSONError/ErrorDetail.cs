namespace FBWA.Core.Models.RestAPI.JSONError
{
    public class ErrorDetail
    {
        /// <summary>
        /// Error code
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// Facebook trace id
        /// </summary>
        public string fbtrace_id { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Error type
        /// </summary>
        public string type { get; set; }
    }
}
