using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messier16.VstsClient.Objects
{

    public class BuildLinks : Links
    {
        public Link timeline { get; set; }
    }
    

    public class Definition
    {
        public string Type { get; set; }
        public int Revision { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public BasicProject Project { get; set; }
    }
    
    public class OrchestrationPlan
    {
        public string PlanId { get; set; }
    }

    public class Logs
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
    }

    public class Repository
    {
        public string Id { get; set; }
        public string Type { get; set; }
        //public object Clean { get; set; }
        public bool CheckoutSubmodules { get; set; }
    }

    public class Build
    {
        public List<string> Tags { get; set; }

        [JsonProperty("_links")]
        public BuildLinks Links { get; set; }
        public int Id { get; set; }
        public string Url { get; set; }
        public Definition Definition { get; set; }
        public string BuildNumber { get; set; }
        public BasicProject Project { get; set; }
        public string Uri { get; set; }
        public string SourceBranch { get; set; }
        public string SourceVersion { get; set; }
        public string Status { get; set; }
        public Queue Queue { get; set; }
        public string QueueTime { get; set; }
        public string Priority { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public string Reason { get; set; }
        public string Result { get; set; }
        public User RequestedFor { get; set; }
        public User RequestedBy { get; set; }
        public string lastChangedDate { get; set; }
        public User LastChangedBy { get; set; }
        public string Parameters { get; set; }
        public OrchestrationPlan OrchestrationPlan { get; set; }
        public Logs Logs { get; set; }
        public Repository Repository { get; set; }
        public bool KeepForever { get; set; }
    }

    public class BuildsList
    {
        public int Count { get; set; }
        public List<Build> Value { get; set; }
    }
}
