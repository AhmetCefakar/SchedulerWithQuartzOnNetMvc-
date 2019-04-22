using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRebrandly.Models
{
    public class CratredLinkModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public string slashtag { get; set; }
        public string destination { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string status { get; set; }
        public string[] tags { get; set; }
        public int clicks { get; set; }
        public bool isPublic { get; set; }
        public string shortUrl { get; set; }
        public string domainId { get; set; }
        public string domainName { get; set; }
        public bool https { get; set; }
        public bool favourite { get; set; }
        public bool integrated { get; set; }

        public object domain { get; set; }
        public object creator { get; set; }

    }
}
