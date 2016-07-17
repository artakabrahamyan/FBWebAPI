using FBWA.Core.Models.WebAPIResponse;
using System.Threading.Tasks;

namespace FBWA.Core.Services
{
    public interface IWebAPIDispatcher
    {
        /// <summary>
        /// Get posted topics, comments and replied commentes then save them in the XML file.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecretKey"></param>
        /// <param name="pageId"></param>
        /// <param name="feedFilter"></param>
        /// <returns></returns>
        Task<GetAndSaveCommentsResponse> GetCommentsAndSaveInXML(string appId, string appSecretKey, string pageId, string feedFilter);
    }
}
