using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training.automation.common.Pop_up
{
    public abstract class Pop_up
    {
        protected string name;

        protected Pop_up(string name)
        {
            this.name = name;
        }
    }
}
