using ServiceStack;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel.Types
{
    [Route("/Domains")]
    public class Domain
    {
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string SummaryText { get; set; }
        public string DescriptionText { get; set; }
        

        [References(typeof(Task))]
        List<Task> Tasks { get; set; }
    }
}
