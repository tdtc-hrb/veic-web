using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace veic_web.Models.Wraps
{
    public class NavMenuDto
    {
        public string Name { get; set; }
        public string LinkAddr { get; set; }
        public string ParentName { get; set; }
        public string ParentLink { get; set; }
    }
}
