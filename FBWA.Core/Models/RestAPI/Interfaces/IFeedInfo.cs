using System;

namespace FBWA.Core.Models.RestAPI.Interfaces
{
    public interface IFeedInfo : IBaseInfo
    {
        /// <summary>
        /// Post topic created date/time
        /// </summary>
        DateTime created_time { get; set; }

        /// <summary>
        /// Posted topic's content
        /// </summary>
        string message { get; set; }

        /// <summary>
        /// Posted topic's story
        /// </summary>
        string story { get; set; }
    }
}
