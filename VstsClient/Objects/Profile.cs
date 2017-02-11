using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messier16.VstsClient.Objects
{
    public class Profile
    {
        public string DisplayName { get; set; }
        public string PublicAlias { get; set; }
        public string EmailAddress { get; set; }
        public int CoreRevision { get; set; }
        public string TimeStamp { get; set; }
        public string Id { get; set; }
        public int Revision { get; set; }
    }
}
