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

        public static void Add(string Key, object Value)
        {
            TestData.Add(Key, Value);
        }

        public static object Get(string Key)
        {
            return TestData[Key];
        }

        public static string GetAsString(string Key)
        {
            return TestData[Key].ToString();
        }

        public static void Destroy()
        {
            TestData.Clear();
        }
    }
}
