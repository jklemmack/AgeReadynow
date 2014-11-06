using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel
{
    [Route("/Tasks/{ParentId}/{DomainId}")]
    public class TaskDTO
    {
        public int ParentId { get; set; }
        public int DomainId { get; set; }
    }

    public class TaskList
    {
        public int DomainId { get; set; }
        public string Domain { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
