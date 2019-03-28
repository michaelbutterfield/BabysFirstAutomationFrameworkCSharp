using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training.automation.common.Pop_up
{
    public abstract class Pop_up
    {
        protected String name;

        protected Pop_up(String name)
        {
            this.name = name;
        }
    }
}
