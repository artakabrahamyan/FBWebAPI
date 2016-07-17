
namespace FBWA.Core.Constants.RestAPI
{
    /// <summary>
    /// URLConstants class declares the constants to create/generate the URL string for connecting to Facebook WebAPI.
    /// </summary>
    class URLConstants
    {
        //---
        public static string QUERY_STRING_SEPARATOR = @"?";
        public static string QUERY_PARAM_SEPARATOR = @"&";
        public static string QUERY_PARAM_ID = @"ID={0}";
        public static string QUERY_PARAM_ACCESS_TOKEN = @"access_token={1}";

        public static string QUERY_PARAM_CLIENT_ID = @"client_id={0}";
        public static string QUERY_PARAM_CLIENT_SECRET = @"client_secret={0}";
        public static string QUERY_PARAM_GRANT_TYPE = @"grant_type={0}";

        //---
        public static string PROTOCOL = @"https";
        public static string PROTOCOL_SEPARATOR = @"://";
        public static string URL_FOLDERPATH_SEPARATOR = @"/";

        public static string DOMAIN_NAME = @"graph.facebook.com";
        public static int DOMAIN_PORT = 80;
        public static float API_VERSION = 1.0F;

        //---
        public static string BASE_URL = PROTOCOL + PROTOCOL_SEPARATOR + DOMAIN_NAME;
        //---

        // Api
        public static string REST_URL_SUFFIX = @"";
        public static string REST_ABSOLUTE_PATH_SUFFIX = REST_URL_SUFFIX;
        public static string REST_URL_FULL = BASE_URL + REST_ABSOLUTE_PATH_SUFFIX;
        //---

        // OAuth
        private static string AUTH_URL_SUFFIX = @"/oauth";
        private static string AUTH_ABSOLUTE_PATH_SUFFIX = REST_ABSOLUTE_PATH_SUFFIX + AUTH_URL_SUFFIX;
        private static string AUTH_URL_FULL = BASE_URL + AUTH_ABSOLUTE_PATH_SUFFIX;

        public static string AUTH_ACCESS_TOKEN_ACTION_URL_SUFFIX = @"/access_token";
        public static string AUTH_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX = AUTH_ABSOLUTE_PATH_SUFFIX + AUTH_ACCESS_TOKEN_ACTION_URL_SUFFIX
                                                                            + QUERY_STRING_SEPARATOR + @"client_id={0}"
                                                                            + QUERY_PARAM_SEPARATOR + @"client_secret={1}"
                                                                            + QUERY_PARAM_SEPARATOR + @"grant_type=client_credentials";

        public static string AUTH_ACCESS_TOKEN_ACTION_URL_FULL = BASE_URL + AUTH_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX;

        // OBJECT_ID (PAGE, FEED, COMMENT and etc.)
        public static string OBJECTID_ACTION_URL_SUFFIX = @"/{0}";
        public static string OBJECTID_ACTION_ABSOLUTE_PATH_SUFFIX = REST_ABSOLUTE_PATH_SUFFIX + OBJECTID_ACTION_URL_SUFFIX;
        public static string OBJECTID_ACTION_URL_FULL = BASE_URL + OBJECTID_ACTION_ABSOLUTE_PATH_SUFFIX;

        public static string OBJECTID_ACCESS_TOKEN_ACTION_URL_SUFFIX = QUERY_STRING_SEPARATOR + QUERY_PARAM_ACCESS_TOKEN;
        public static string OBJECTID_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX = OBJECTID_ACTION_ABSOLUTE_PATH_SUFFIX + OBJECTID_ACCESS_TOKEN_ACTION_URL_SUFFIX;
        public static string OBJECTID_ACCESS_TOKEN_ACTION_URL_FULL = BASE_URL + OBJECTID_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX;

        // Page feed
        private static string PAGE_FEED_ACTION_URL_SUFFIX = @"/feed";
        private static string PAGE_FEED_ACTION_ABSOLUTE_PATH_SUFFIX = OBJECTID_ACTION_ABSOLUTE_PATH_SUFFIX + PAGE_FEED_ACTION_URL_SUFFIX;
        private static string PAGE_FEED_ACTION_URL_FULL = BASE_URL + PAGE_FEED_ACTION_ABSOLUTE_PATH_SUFFIX;

        public static string PAGE_FEED_ACCESS_TOKEN_ACTION_URL_SUFFIX = QUERY_STRING_SEPARATOR + QUERY_PARAM_ACCESS_TOKEN;
        public static string PAGE_FEED_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX = PAGE_FEED_ACTION_ABSOLUTE_PATH_SUFFIX + PAGE_FEED_ACCESS_TOKEN_ACTION_URL_SUFFIX;
        public static string PAGE_FEED_ACCESS_TOKEN_ACTION_URL_FULL = BASE_URL + PAGE_FEED_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX;

        // Comments
        private static string COMMENTS_ACTION_URL_SUFFIX = @"/comments";
        private static string COMMENTS_ACTION_ABSOLUTE_PATH_SUFFIX = OBJECTID_ACTION_ABSOLUTE_PATH_SUFFIX + COMMENTS_ACTION_URL_SUFFIX;
        private static string COMMENTS_ACTION_URL_FULL = BASE_URL + COMMENTS_ACTION_ABSOLUTE_PATH_SUFFIX;

        public static string COMMENTS_ACCESS_TOKEN_ACTION_URL_SUFFIX = QUERY_STRING_SEPARATOR + QUERY_PARAM_ACCESS_TOKEN;
        public static string COMMENTS_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX = COMMENTS_ACTION_ABSOLUTE_PATH_SUFFIX + COMMENTS_ACCESS_TOKEN_ACTION_URL_SUFFIX;
        public static string COMMENTS_ACCESS_TOKEN_ACTION_URL_FULL = BASE_URL + COMMENTS_ACCESS_TOKEN_ACTION_ABSOLUTE_PATH_SUFFIX;
    }
}
