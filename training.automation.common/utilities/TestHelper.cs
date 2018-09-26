using NHamcrest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training.automation.common.utilities
{
    class TestHelper
    {
        public static void HandleException(String errorMessage, Exception e, Boolean takeScreenshot)
        {
            String exception = String.Format("{0} : {1} : ", errorMessage, e);
            Console.WriteLine(exception);

            throw new System.ArgumentException(e.Message, e);
        }
    }
}
