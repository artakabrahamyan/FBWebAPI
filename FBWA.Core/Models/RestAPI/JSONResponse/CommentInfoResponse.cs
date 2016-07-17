using FBWA.Core.Models.RestAPI.Interfaces;
using System;
using System.Xml.Serialization;

namespace FBWA.Core.Models.RestAPI.JSONResponse
{
    public class CommentInfoResponse : BaseResponse, ICommentInfo
    {
        /// <summary>
        /// Comment created date/time
        /// </summary>
        [XmlIgnore]
        public DateTime created_time { get; set; }

        [XmlElement(ElementName = "Time")]
        public string created_timeString {
            get { return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(created_time, "Pacific Standard Time").ToString(); }
            set { created_time = DateTime.Parse(value); }
        }

        /// <summary>
        /// Information about the comemnt posted object.
        /// </summary>
        [XmlIgnore]
        public PageInfoResponse from { get; set; }

        /// <summary>
        /// Comment Id
        /// </summary>
        [XmlIgnore]
        public string id { get; set; }

        /// <summary>
        /// The content of message posted by anyone.
        /// </summary>
        [XmlElement(ElementName = "Comment")]
        public string message { get; set; }
    }
}
