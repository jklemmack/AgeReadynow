using ServiceStack;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AgeReadyNowSS.ServiceModel;
using AgeReadyNowSS.ServiceModel.Types;

namespace AgeReadyNowSS.ServiceInterface
{
    public class AssessmentService : Service
    {
        public object Get(AssessmentRequest request)
        {
            AssessmentResponse response = new AssessmentResponse().PopulateWith(request);

            if (!request.NextPage.HasValue || request.NextPage.Value <= 0)
            {
                response.CurrentPage = 0;
                response.NextPage = 1;
            }
            else
            {
                response.PrevPage = request.NextPage.Value - 1;
                response.CurrentPage = response.PrevPage.Value + 1;
                response.NextPage = response.CurrentPage + 1;
            }

            Parent parent = Db.SingleById<Parent>(request.ParentId);
            response.ParentName = parent.Name;


            int DomainId = LookupDomain(request.Domain);
            var tasks = TasksForDomain(DomainId);
            var task = tasks.FirstOrDefault(t => t.TaskOrder == response.CurrentPage);
            if (task != null)
            {
                response.TaskShortText = task.ShortText;
                response.TaskPromptText = task.PromptText;
                response.TaskAssessmentText = task.AssessmentText;
                response.TotalPages = tasks.Count;
            }

            string view = "AssessmentQuestion";
            if (response.CurrentPage == tasks.Count)
                view = "AssessmentEnd";
            else if (response.CurrentPage == 0)
                view = "AssessmentStart";

            return new HttpResult
            {
                Response = response,
                View = view
            };

        }

        public object Post(AssessmentRequest request)
        {
            return new HttpResult
            {

            };
        }

        internal static int LookupDomain(string name)
        {
            switch (name.ToLowerInvariant())
            {
                case "medical":
                    return 1;
                case "legal":
                    return 2;
                case "family":
                    return 3;
                case "spiritual":
                    return 4;
                default:
                    return 0;
            }
        }

        private List<AgeReadyNowSS.ServiceModel.Types.Task> TasksForDomain(int DomainId)
        {
            return Db.Select<AgeReadyNowSS.ServiceModel.Types.Task>(t => t.DomainId == DomainId);
        }
    }
}
