using AgeReadyNowSS.ServiceModel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServiceStack;
using ServiceStack.OrmLite;
using AgeReadyNowSS.ServiceModel;
using ServiceStack.Auth;

namespace AgeReadyNowSS.ServiceInterface
{
    [Authenticate]
    public class ResourceService : Service
    {
        public object Get(ResourceRequest request)
        {
            var userAuth = Db.SingleWhere<UserAuth>("Email", Request.GetSession().Email)
                ?? Db.SingleWhere<UserAuth>("UserName", Request.GetSession().Email);

            Parent parent = Db.Single<Parent>(new { Id = request.ParentId, UserAuthId = userAuth.Id });


            if (!request.Page.HasValue)
                request.Page = 0;

            // Show a list of tasks for the domain
            if (!request.TaskId.HasValue)
            {
                int domainId = AssessmentService.LookupDomain(request.Domain);
                var exp = Db.From<Task>()
                    .LeftJoin<SurveyResponse>((t, sr) => sr.TaskId == t.Id && sr.ParentId == parent.Id)
                    .Where<Task>(t => t.DomainId == domainId)
                    //.OrderBy<SurveyResponse>(sr => sr.Completed)
                    ;

                var tasks = Db.Select<TaskListResponse>(exp);
                tasks.ForEach(t => t.Completed = (t.Id % 3 == 0));
                
                return new HttpResult()
                {
                    Response = tasks,
                    View = "ResourcesByDomain"
                };
            }

            //Get resources for domain & state
            if (request.StateCode.IsNullOrEmpty())
            {
                request.StateCode = parent.StateCode;
            }



            return new HttpResult()
            {

            };
        }
    }
}
