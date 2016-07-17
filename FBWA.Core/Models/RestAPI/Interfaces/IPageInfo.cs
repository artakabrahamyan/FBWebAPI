namespace FBWA.Core.Models.RestAPI.Interfaces
{
    public interface IPageInfo : IBaseInfo
    {
        /// <summary>
        /// Name of Facebook page
        /// </summary>
        string name { get; set; }
    }
}
