using System.Threading.Tasks;
using FBWA.Core.Constants.RestAPI;
using FBWA.Core.Models.RestAPI.Interfaces;
using FBWA.Core.Models.RestAPI.JSONRequest;
using FBWA.Core.Models.RestAPI.JSONResponse;
using FBWA.Core.Services.RestAPI;

namespace FBWA.Core.Managers.RestAPI
{
    /// <summary>
    /// Manager class to prepare and request the data from Facebook webapi server.
    /// </summary>
    public class FacebookWSManager : IFacebookWSContract
    {
        private readonly IRestRequestService _restRequestService;

        public FacebookWSManager(IRestRequestService restRequestService)
        {
            _restRequestService = restRequestService;
        }

        /// <summary>
        /// Get App Access Token from Facebook server based on the AppId and AppSerectKey.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FacebookAuthResponse> GetAppAccessToken(FacebookAuthRequest request)
        {
            var apiUrlPath = string.Format(URLConstants.AUTH_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX, request.AppID, request.AppSecretKey);
            return await _restRequestService.BuildAccessTokenRequest<FacebookAuthResponse>(apiUrlPath);
        }

        /// <summary>
        /// Get comment detail information for specified comment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommentInfoResponse> GetCommentInfo(CommentInfoRequest request)
        {
            var apiUrlPath = string.Format(URLConstants.OBJECTID_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX, request.id, request.access_token);
            return await _restRequestService.BuildEmptyRequest<CommentInfoResponse>(apiUrlPath, null);
        }

        /// <summary>
        /// Get the comments for specified post topic.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommentListResponse> GetComments(FeedInfoRequest request)
        {
            var apiUrlPath = string.Format(URLConstants.COMMENTS_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX, request.id, request.access_token);
            return await _restRequestService.BuildEmptyRequest<CommentListResponse>(apiUrlPath, null);
        }

        /// <summary>
        /// Get replied comments for specified comment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommentListResponse> GetComments(CommentInfoRequest request)
        {
            var apiUrlPath = string.Format(URLConstants.COMMENTS_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX, request.id, request.access_token);
            return await _restRequestService.BuildEmptyRequest<CommentListResponse>(apiUrlPath, null);
        }

        /// <summary>
        /// Get the comments for specified Facebook URL.
        /// </summary>
        /// <param name="requestUrlFullPath"></param>
        /// <returns></returns>
        public async Task<CommentListResponse> GetComments(string requestUrlFullPath)
        {
            var apiUrlPath = requestUrlFullPath;
            return await _restRequestService.BuildEmptyRequest<CommentListResponse>(apiUrlPath, null);
        }

        /// <summary>
        /// Get post topic detail information for specified post topic.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FeedInfoResponse> GetFeedInfo(FeedInfoRequest request)
        {
            var apiUrlPath = string.Format(URLConstants.OBJECTID_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX, request.id, request.access_token);
            return await _restRequestService.BuildEmptyRequest<FeedInfoResponse>(apiUrlPath, null);
        }

        /// <summary>
        /// Get the post topics for specified Facebook URL.
        /// </summary>
        /// <param name="requestUrlFullPath"></param>
        /// <returns></returns>
        public async Task<FeedListResponse> GetFeeds(string requestUrlFullPath)
        {
            var apiUrlPath = requestUrlFullPath;
            return await _restRequestService.BuildEmptyRequest<FeedListResponse>(apiUrlPath, null);
        }

        /// <summary>
        /// Get post topics for specified page.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FeedListResponse> GetFeeds(PageInfoRequest request)
        {
            var apiUrlPath = string.Format(URLConstants.PAGE_FEED_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX, request.id, request.access_token);
            return await _restRequestService.BuildEmptyRequest<FeedListResponse>(apiUrlPath, null);
        }

        /// <summary>
        /// Get page detail information for specified page.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PageInfoResponse> GetPageInfo(PageInfoRequest request)
        {
            var apiUrlPath = string.Format(URLConstants.OBJECTID_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX, request.id, request.access_token);
            return await _restRequestService.BuildEmptyRequest<PageInfoResponse>(apiUrlPath, null);
        }
    }
}
