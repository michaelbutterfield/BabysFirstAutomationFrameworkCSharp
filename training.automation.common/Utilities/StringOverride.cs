using System.Text.RegularExpressions;

namespace training.automation.common.Utilities
{
    public static class StringOverride
    {
        public static string RemoveBackslashAndQuotation(this string str)
        {
            str = Regex.Replace(str, "[\\ \"]", "");

            return str;
        }
    }
}
