using FBWA.Core.Models.RestAPI.JSONResponse;
using System;

namespace FBWA.Core.Models.RestAPI.Interfaces
{
    public interface ICommentInfo : IBaseInfo
    {
        /// <summary>
        /// Comment created date/time
        /// </summary>
        DateTime created_time { get; set; }

        /// <summary>
        /// Information about the comemnt posted object.
        /// </summary>
        PageInfoResponse from { get; set; }

        /// <summary>
        /// The content of message posted by anyone.
        /// </summary>
        string message { get; set; }
    }
}
