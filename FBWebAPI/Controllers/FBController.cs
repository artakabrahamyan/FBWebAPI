using FBWA.Core.Models.WebAPIResponse;
using FBWA.Core.Services;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace FBWA.Controllers
{
    [RoutePrefix("api/FB")]
    public class FBController : ApiController
    {
        IWebAPIDispatcher _webAPIDispatcher;

        public FBController(IWebAPIDispatcher webAPIDispatcher)
        {
            _webAPIDispatcher = webAPIDispatcher;
        }

        [HttpGet]
        [Route("getandsavecomments/{appId}/{appSecretKey}/{pageId}/{topicFilter}")]
        [ResponseType(typeof(GetAndSaveCommentsResponse))]

        public async Task<IHttpActionResult> GetCommentsAndSaveInXML(string appId, string appSecretKey, string pageId, string topicFilter)
        {
            return Ok(await _webAPIDispatcher.GetCommentsAndSaveInXML(appId, appSecretKey, pageId, topicFilter));
        }
    }
}
