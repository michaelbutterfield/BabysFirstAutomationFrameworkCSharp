using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training.automation.common.Pages
{
    public abstract class Page
    {
        protected String name;

        protected Page(String name)
        {
            this.name = name;
        }
    }
}
