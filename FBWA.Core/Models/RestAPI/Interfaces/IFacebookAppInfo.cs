namespace FBWA.Core.Models.RestAPI.Interfaces
{
    public interface IFacebookAppInfo
    {
        /// <summary>
        /// Facebook Application ID.
        /// </summary>
        string AppID { get; set; }

        /// <summary>
        /// Facebook Application Secret Key.
        /// </summary>
        string  AppSecretKey { get; set; }
    }
}
