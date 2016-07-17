using System;
using System.Collections;
using System.Diagnostics;

namespace FBWA.Core.Helpers
{
    /// <summary>
    /// This class is showing the messages on the debug output window.
    /// </summary>
    public static class ExceptionDebugLogHelper
    {
        public static void Log(string value)
        {
            Debug.WriteLine(value);
        }

        public static void Log(Exception ex)
        {
            Debug.WriteLine("Error Begin ================================");
            Debug.WriteLine("HelpLink: {0}", ex.HelpLink);
            Debug.WriteLine("HResult: {0}", ex.HResult);
            Debug.WriteLine("Message: {0}", ex.Message);
            Debug.WriteLine("Source: {0}", ex.Source);
            Debug.WriteLine("StackTrace: {0}", ex.StackTrace);
            foreach (DictionaryEntry item in ex.Data)
            {
                Debug.WriteLine("Key: {0}; Value: {1}", item.Key.ToString(), item.Value.ToString());
            }
            Debug.WriteLine("Error End ================================");
        }
    }
}
