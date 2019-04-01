using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training.automation.common.Pages
{
    public abstract class Page
    {
        protected string name;

        protected Page(string name)
        {
            this.name = name;
        }
    }
}
