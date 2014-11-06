using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel
{
    [Route("/Assessment/{ParentId}/{Domain}", "GET")]
    [Route("/Assessment/{ParentId}/{Domain}/{NextPage}", "GET")]
    [Route("/Assessment/{ParentId}/{Domain}/{NextPage}", "POST")]
    public class AssessmentRequest : IReturn<AssessmentResponse>
    {
        public int ParentId { get; set; }
        public string Domain { get; set; }
        public int? NextPage { get; set; }

        public int? CurentPage { get; set; }

        public bool? Completed { get; set; }
        public int? Timeline { get; set; }
    }

    public class AssessmentResponse
    {
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public string Domain { get; set; }

        public int? NextPage { get; set; }
        public int CurrentPage { get; set; }
        public int? TotalPages { get; set; }
        public int? PrevPage { get; set; }

        public string DomainSummary { get; set; }
        public string TaskShortText { get; set; }
        public string TaskPromptText { get; set; }
        public string TaskAssessmentText { get; set; }

        public bool Completed { get; set; }
        public int? Timeline { get; set; }
    }

}
