using NHamcrest;
using NHamcrest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training.automation.common.utilities
{
    public class TestHelper
    {
        public static void HandleException(String errorMessage, Exception e, Boolean takeScreenshot)
        {
            String exception = String.Format("{0} : {1} : ", errorMessage, e);
            Console.WriteLine(exception);

            throw new System.ArgumentException(e.Message, e);
        }

        //public static <T> void AssertThat(T actual, Matcher<? super T> matcher, String stepDescription)
        //{
        //    AssertThat(actual, matcher, stepDescription, true);
        //}

        //public static <T> void AssertThat(T actual, Matcher<? super T> matcher, String stepDescription, Boolean takeScreenshot)
        //{
        //    try
        //    {
        //        MatcherAssert.assertThat(stepDescription, actual, matcher);
        //    }
        //    catch (Exception e)
        //    {
        //        String errorMessage = stepDescription + " failed.\n" + e.Message;
        //        HandleException(errorMessage, e, takeScreenshot);
        //    }
        //}
    }
}
