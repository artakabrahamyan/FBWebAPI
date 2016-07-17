using FBWA.Core.Models.RestAPI.JSONResponse;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FBWA.Core.Models.XML
{
    [XmlRoot(ElementName = "PostItem")]
    public class XMLFeedInfoModel : FeedInfoResponse
    {
        /// <summary>
        /// Comment list
        /// </summary>
        [XmlArray("Comments")]
        [XmlArrayItem("CommentItem")]
        public ObservableCollection<CommentInfoResponse> Comments { get; set; }
    }
}
