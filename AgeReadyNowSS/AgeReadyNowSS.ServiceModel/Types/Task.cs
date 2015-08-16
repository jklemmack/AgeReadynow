using ServiceStack;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel.Types
{
    [Route("/Tasks")]
    public class Task
    {
        [AutoIncrement]
        public int Id { get; set; }

        [References(typeof(Domain))]
        public int DomainId { get; set; }

        public int TaskOrder { get; set; }

        [Reference]
        public Domain Domain { get; set; }

        public string ShortText { get; set; }

        public string PromptText { get; set; }

        public string AssessmentText { get; set; }

        public string PromptTextSelf { get; set; }

        public string AssessmentTextSelf { get; set; }
    }

    public class TaskListResponse
    {
        public int Id { get; set; }

        [References(Domain)]
        public int DomainId { get; set; }

        [Reference]
        public Domain Domain { get; set; }

        //public string DomainName { get; set; }
        public string ShortText { get; set; }
        public string PromptText { get; set; }
        public string AssessmentText { get; set; }
        public string PromptTextSelf { get; set; }
        public string AssessmentTextSelf { get; set; }
        
        public bool Completed { get; set; }
        public int Timeline { get; set; }

        [References(typeof(Parent))]
        public int ParentId { get; set; }

        [Reference]
        public Parent Parent { get; set; }

        public string ParentName { get; set; }
    }
}
