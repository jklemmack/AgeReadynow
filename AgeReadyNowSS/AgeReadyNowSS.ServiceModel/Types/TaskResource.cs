using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel.Types
{
    public class TaskResource
    {
        [AutoIncrement]
        public int Id { get; set; }

        [References(typeof(Task))]
        public int TaskId { get; set; }

        [References(typeof(Resource))]
        public int ResourceId { get; set; }

        [Reference]
        public Task Task { get; set; }

        [Reference]
        public Resource Resource { get; set; }
    }
}
