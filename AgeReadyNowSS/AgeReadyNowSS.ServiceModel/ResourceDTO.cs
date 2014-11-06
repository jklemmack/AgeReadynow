using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel
{
    [Route("/resources/{ParentId}/{Domain}/{TaskId}/{StateCode}")]
    [Route("/resources/{ParentId}/{Domain}/{TaskId}")]
    [Route("/resources/{ParentId}/{Domain}")]
    public class ResourceRequest
    {
        public int ParentId { get; set; }
        public string Domain { get; set; }

        public int? TaskId { get; set; }
        public string StateCode { get; set; }

        public int? Page { get; set; }
    }



}
