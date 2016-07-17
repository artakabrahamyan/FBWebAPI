namespace FBWA.Core.Models.RestAPI.Interfaces
{
    public interface IPagingInfo
    {
        /// <summary>
        /// URL string for next pagination.
        /// </summary>
        string next { get; set; }

        /// <summary>
        /// URL string for previous pagination.
        /// </summary>
        string previous { get; set; }
    }
}
