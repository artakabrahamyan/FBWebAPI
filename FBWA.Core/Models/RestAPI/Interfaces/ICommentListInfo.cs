using FBWA.Core.Models.RestAPI.JSONResponse;
using System.Collections.ObjectModel;

namespace FBWA.Core.Models.RestAPI.Interfaces
{
    public interface ICommentListInfo
    {
        /// <summary>
        /// Data list of comment
        /// </summary>
        ObservableCollection<CommentInfoResponse> data { get; set; }

        /// <summary>
        /// Paging information (previous/next) of comment
        /// </summary>
        PagingInfoResponse paging { get; set; }
    }
}
