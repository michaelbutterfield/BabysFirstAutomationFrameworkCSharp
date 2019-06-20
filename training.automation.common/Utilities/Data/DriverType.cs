using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training.automation.common.Utilities.Data
{
    public class DriverType
    {
        public enum DRIVER_TYPE
        {
            SELENIUM,
            APPIUM
        }

        public static DRIVER_TYPE driverType;
    }
}
