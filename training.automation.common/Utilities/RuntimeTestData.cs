﻿using System.Collections.Generic;
using training.automation.common.Tests;

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

        public static bool ContainsKey(string Key)
        {
            return TestData.ContainsKey(Key);
        }

        public static bool ContainsValue(string Value)
        {
            return TestData.ContainsValue(Value);
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
            TestLogger.CreateTestStep("Runtime Test Data Destroyed");
            TestData.Clear();
        }
    }
}
