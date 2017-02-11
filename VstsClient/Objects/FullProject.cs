using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messier16.VstsClient.Objects
{
    public class Versioncontrol
    {
        public string SourceControlType { get; set; }
    }

    public class ProcessTemplate
    {
        public string TemplateName { get; set; }
    }

    public class Capabilities
    {
        public Versioncontrol Versioncontrol { get; set; }
        public ProcessTemplate ProcessTemplate { get; set; }
    }

    public class DefaultTeam
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class FullProject : BasicProject
    {
        public Capabilities Capabilities { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }

        public DefaultTeam DefaultTeam { get; set; }
    }
}
