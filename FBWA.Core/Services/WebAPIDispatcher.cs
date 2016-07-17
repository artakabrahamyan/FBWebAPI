using System;
using System.Threading.Tasks;
using FBWA.Core.Models.WebAPIResponse;
using FBWA.Core.Models.RestAPI.Interfaces;
using FBWA.Core.Models.RestAPI.JSONRequest;
using System.Collections.ObjectModel;
using FBWA.Core.Models.RestAPI.JSONResponse;
using System.Xml.Serialization;
using System.IO;
using FBWA.Core.Models.XML;

namespace FBWA.Core.Services
{
    public class WebAPIDispatcher : IWebAPIDispatcher
    {
        IFacebookWSContract _facebookWSContract;

        public WebAPIDispatcher(IFacebookWSContract facebookWSContract)
        {
            _facebookWSContract = facebookWSContract;
        }

        /// <summary>
        /// /// Get posted topics, comments and replied commentes then save them in the XML file.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecretKey"></param>
        /// <param name="pageId"></param>
        /// <param name="feedFilter"></param>
        /// <returns></returns>
        public async Task<GetAndSaveCommentsResponse> GetCommentsAndSaveInXML(string appId, string appSecretKey, string pageId, string feedFilter)
        {
            // Validation of Input parameters
            if (string.IsNullOrEmpty(appId))
                throw (new Exception("The App ID should not be null or empty"));

            if (string.IsNullOrEmpty(appSecretKey))
                throw (new Exception("The App Secret Key should not be null or empty"));

            if (string.IsNullOrEmpty(pageId))
                throw (new Exception("The Page ID should not be null or empty"));

            // Authentication
            // Create object for Facebook authentication request.
            var facebookAuthRequest = new FacebookAuthRequest() {
                AppID = appId,
                AppSecretKey = appSecretKey
            };

            //Request for getting Facebook App Access Token
            var appAccessToken = await _facebookWSContract.GetAppAccessToken(facebookAuthRequest);

            //Validation of result
            if (appAccessToken == null)
                throw (new Exception("The result of AccessToken request is null."));

            if (!appAccessToken.Success)
                throw (new Exception(appAccessToken.error.message));

            if (string.IsNullOrEmpty(appAccessToken.access_token))
                throw (new Exception("The returned AccessToken should not be null or empty"));

            // Page Info
            // Create object requesting information about Facebook page.
            var pageInfoRequest = new PageInfoRequest() {
                access_token = appAccessToken.access_token,
                id = pageId
            };

            //Request for getting Facebook page information.
            var pageInfoResponse = await _facebookWSContract.GetPageInfo(pageInfoRequest);

            //Validation
            if (pageInfoResponse == null)
                throw (new Exception("The provided page id is not valid for Facebook."));

            if (!pageInfoResponse.Success)
                throw (new Exception(pageInfoResponse.error.message));

            // Feed list
            var collFeedInfo = await GetFeedsList(pageInfoRequest, feedFilter);

            if(collFeedInfo.Count == 0)
                throw (new Exception("There is not any feed/post to save in the file."));

            var collXMLFeedInfoModel = new ObservableCollection<XMLFeedInfoModel>();

            foreach (var feedInfo in collFeedInfo)
            {
                var feedInfoRequest = new FeedInfoRequest()
                {
                    access_token = appAccessToken.access_token,
                    id = feedInfo.id
                };

                // Comment list
                var colFeedCommentResponse = await GetCommentsList(feedInfoRequest);

                collXMLFeedInfoModel.Add(new XMLFeedInfoModel()
                {
                    Comments = colFeedCommentResponse,
                    created_time = feedInfo.created_time,
                    error = feedInfo.error,
                    id = feedInfo.id,
                    message = feedInfo.message,
                    StatusCode = feedInfo.StatusCode,
                    story = feedInfo.story,
                    Success = feedInfo.Success
                });
            }

            GetAndSaveCommentsResponse result = null;
            try
            {
                using (var ms = new MemoryStream())
                {
                    var xlRootAttr = new XmlRootAttribute("Posts");
                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<XMLFeedInfoModel>), xlRootAttr);
                    serializer.Serialize(ms, collXMLFeedInfoModel);

                    using (var fileStream = new FileStream("D:\\PostCommentInfo.xml", FileMode.Create, FileAccess.ReadWrite))
                    {
                        ms.WriteTo(fileStream);
                    }
                };

                result = new GetAndSaveCommentsResponse()
                {
                    message = "Successfully",
                    Success = true,
                    StatusCode = "200",
                    error = null
                };
            }
            catch (Exception ex)
            {
                //result = new GetAndSaveCommentsResponse()
                //{
                //    message = ex.Message,
                //    Success = false,
                //    StatusCode = "-1",
                //    error = null
                //};
                throw (ex);
            }
            return result;
        }

        private async Task<ObservableCollection<FeedInfoResponse>> GetFeedsList(PageInfoRequest pageInfoRequest, string filter = null)
        {
            var isFinished = false;
            var isRequestedByNextPage = pageInfoRequest == null;
            FeedListResponse colFeedInfoResponse = null;
            var collFeedInfo = new ObservableCollection<FeedInfoResponse>();
            do
            {
                if (isRequestedByNextPage)
                {
                    colFeedInfoResponse = await _facebookWSContract.GetFeeds(colFeedInfoResponse.paging.next);
                }
                else
                {
                    colFeedInfoResponse = await _facebookWSContract.GetFeeds(pageInfoRequest);
                    isRequestedByNextPage = true;
                }

                isFinished = false;
                if (colFeedInfoResponse.Success)
                {
                    isFinished = colFeedInfoResponse != null && colFeedInfoResponse.data != null && colFeedInfoResponse.data.Count > 0;
                    if (isFinished)
                    {
                        isFinished = isFinished && colFeedInfoResponse.paging != null && !string.IsNullOrEmpty(colFeedInfoResponse.paging.next);

                        foreach (var item in colFeedInfoResponse.data)
                        {
                            var message = string.IsNullOrEmpty(item.message) ? item.story : item.message;
                            if (string.IsNullOrEmpty(filter) ||
                                (!string.IsNullOrEmpty(filter) && message.Equals(filter)))
                                collFeedInfo.Add(item);
                        }
                    }
                }
            } while (isFinished);

            return collFeedInfo;
        }

        private async Task<ObservableCollection<CommentInfoResponse>> GetCommentsList(FeedInfoRequest feedInfoRequest)
        {
            var isFinished = false;
            var isRequestedByNextPage = feedInfoRequest == null;
            CommentListResponse colCommentInfoResponse = null;
            var collCommentInfo = new ObservableCollection<CommentInfoResponse>();
            do
            {
                if (isRequestedByNextPage)
                {
                    colCommentInfoResponse = await _facebookWSContract.GetComments(colCommentInfoResponse.paging.next);
                }
                else
                {
                    colCommentInfoResponse = await _facebookWSContract.GetComments(feedInfoRequest);
                    isRequestedByNextPage = true;
                }

                isFinished = false;
                if (colCommentInfoResponse.Success)
                {
                    isFinished = colCommentInfoResponse != null && colCommentInfoResponse.data != null && colCommentInfoResponse.data.Count > 0;
                    if (isFinished)
                    {
                        isFinished = isFinished && colCommentInfoResponse.paging != null && !string.IsNullOrEmpty(colCommentInfoResponse.paging.next);

                        foreach (var item in colCommentInfoResponse.data)
                        {
                            collCommentInfo.Add(item);

                            var commentInfoRequest = new CommentInfoRequest()
                            {
                                access_token = feedInfoRequest.access_token,
                                id = item.id
                            };

                            var colRepliedCommentInfoResponse = await GetCommentsList(commentInfoRequest);
                            if (colRepliedCommentInfoResponse != null && colRepliedCommentInfoResponse.Count > 0)
                            {
                                foreach (var repliedItem in colRepliedCommentInfoResponse)
                                    collCommentInfo.Add(repliedItem);
                            }
                        }
                    }
                }
            } while (isFinished);

            return collCommentInfo;
        }

        private async Task<ObservableCollection<CommentInfoResponse>> GetCommentsList(CommentInfoRequest commentInfoRequest)
        {
            var isFinished = false;
            var isRequestedByNextPage = commentInfoRequest == null;
            CommentListResponse colCommentInfoResponse = null;
            var collCommentInfo = new ObservableCollection<CommentInfoResponse>();
            do
            {
                if (isRequestedByNextPage)
                {
                    colCommentInfoResponse = await _facebookWSContract.GetComments(colCommentInfoResponse.paging.next);
                }
                else
                {
                    colCommentInfoResponse = await _facebookWSContract.GetComments(commentInfoRequest);
                    isRequestedByNextPage = true;
                }

                isFinished = false;
                if (colCommentInfoResponse.Success)
                {
                    isFinished = colCommentInfoResponse != null && colCommentInfoResponse.data != null && colCommentInfoResponse.data.Count > 0;
                    if (isFinished)
                    {
                        isFinished = isFinished && colCommentInfoResponse.paging != null && !string.IsNullOrEmpty(colCommentInfoResponse.paging.next);

                        foreach (var item in colCommentInfoResponse.data)
                            collCommentInfo.Add(item);
                    }
                }
            } while (isFinished);

            return collCommentInfo;
        }
    }
}
