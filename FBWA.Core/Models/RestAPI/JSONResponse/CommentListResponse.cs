using FBWA.Core.Models.RestAPI.Interfaces;
using System.Collections.ObjectModel;

namespace FBWA.Core.Models.RestAPI.JSONResponse
{
    public class CommentListResponse : BaseResponse, ICommentListInfo
    {
        /// <summary>
        /// Data list of comment
        /// </summary>
        public ObservableCollection<CommentInfoResponse> data { get; set; }

        /// <summary>
        /// Paging information (previous/next) of comment
        /// </summary>
        public PagingInfoResponse paging { get; set; }
    }
}
