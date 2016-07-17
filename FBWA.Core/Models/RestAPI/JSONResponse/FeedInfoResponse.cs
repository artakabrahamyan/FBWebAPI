using FBWA.Core.Models.RestAPI.Interfaces;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace FBWA.Core.Models.RestAPI.JSONResponse
{
    public class FeedInfoResponse : BaseResponse, IFeedInfo
    {
        /// <summary>
        /// Post topic created date/time
        /// </summary>
        [XmlIgnore]
        public DateTime created_time { get; set; }

        [XmlElement(ElementName = "Time")]
        public string created_timeString
        {
            get { return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(created_time, "Pacific Standard Time").ToString(); }
            set { created_time = DateTime.Parse(value); }
        }

        /// <summary>
        ///Posted topic Id 
        /// </summary>
        [XmlIgnore]
        public string id { get; set; }

        /// <summary>
        /// Posted topic's content
        /// </summary>
        [XmlIgnore]
        public string message { get; set; }

        /// <summary>
        /// Posted topic's story
        /// </summary>
        [XmlIgnore]
        public string story { get; set; }

        [JsonIgnore]
        [XmlElement(ElementName = "PostTopic")]
        public string PostTopic
        {
            get { return string.IsNullOrEmpty(message) ? story : message; }
            set { message = value; }
        }
    }
}
