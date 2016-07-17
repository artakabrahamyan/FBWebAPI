using System.Threading.Tasks;
using FBWA.Core.Models.RestAPI.JSONRequest;
using FBWA.Core.Models.RestAPI.JSONResponse;

namespace FBWA.Core.Models.RestAPI.Interfaces
{
    public interface IFacebookWSContract
    {
        Task<FacebookAuthResponse> GetAppAccessToken(FacebookAuthRequest request);

        Task<CommentInfoResponse> GetCommentInfo(CommentInfoRequest request);

        Task<CommentListResponse> GetComments(FeedInfoRequest request);

        Task<CommentListResponse> GetComments(CommentInfoRequest request);

        Task<CommentListResponse> GetComments(string requestUrlFullPath);

        Task<FeedInfoResponse> GetFeedInfo(FeedInfoRequest request);

        Task<FeedListResponse> GetFeeds(PageInfoRequest request);

        Task<FeedListResponse> GetFeeds(string requestUrlFullPath);

        Task<PageInfoResponse> GetPageInfo(PageInfoRequest request);
    }
}
