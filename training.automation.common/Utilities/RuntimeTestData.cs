using System.Collections.Generic;

namespace training.automation.common.Utilities
{
    public class RuntimeTestData
    {
        private static Dictionary<string, object> TestData;

        static RuntimeTestData()
        {
            TestData = new Dictionary<string, object>();
        }

        public static void Add(string Key, string Value)
        {
            TestData.Add(Key, Value);
        }

        public static string GetAsString(string key)
        {
            return TestData[key].ToString();
        }

        public static void Destroy()
        {
            TestData.Clear();
        }
    }
}
