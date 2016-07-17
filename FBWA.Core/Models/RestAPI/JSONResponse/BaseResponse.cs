using FBWA.Core.Models.RestAPI.JSONError;
using System.Xml.Serialization;

namespace FBWA.Core.Models.RestAPI.JSONResponse
{
    public class BaseResponse
    {
        /// <summary>
        /// Status code
        /// </summary>
        [XmlIgnore]
        public string StatusCode { get; set; }

        /// <summary>
        /// Indicates whether the request is success or fault 
        /// </summary>
        [XmlIgnore]
        public bool Success { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        [XmlIgnore]
        public ErrorDetail error { get; set; }
    }
}
