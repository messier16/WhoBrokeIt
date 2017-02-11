using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messier16.VstsClient.Objects
{
    public class Link
    {
        public string Href { get; set; }
    }

    public class Links
    {
        public Link Self { get; set; }
        public Link Collection { get; set; }
        public Link Web { get; set; }
    }
}
