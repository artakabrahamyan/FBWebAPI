using FBWA.Core.Models.RestAPI.JSONResponse;
using System.Collections.ObjectModel;

namespace FBWA.Core.Models.RestAPI.Interfaces
{
    public interface IFeedListInfo
    {
        /// <summary>
        /// Data list of posted topics
        /// </summary>
        ObservableCollection<FeedInfoResponse> data { get; set; }

        /// <summary>
        /// Paging information (previous/next) of comment
        /// </summary>
        PagingInfoResponse paging { get; set; }
    }
}
