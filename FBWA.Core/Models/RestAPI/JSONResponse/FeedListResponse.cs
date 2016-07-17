using FBWA.Core.Models.RestAPI.Interfaces;
using System.Collections.ObjectModel;

namespace FBWA.Core.Models.RestAPI.JSONResponse
{
    public class FeedListResponse : BaseResponse, IFeedListInfo
    {
        /// <summary>
        /// Data list of posted topics
        /// </summary>
        public ObservableCollection<FeedInfoResponse> data { get; set; }

        /// <summary>
        /// Paging information (previous/next) of comment
        /// </summary>
        public PagingInfoResponse paging { get; set; }
    }
}
