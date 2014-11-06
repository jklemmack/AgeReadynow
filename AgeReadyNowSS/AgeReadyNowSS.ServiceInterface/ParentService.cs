using AgeReadyNowSS.ServiceModel;
using AgeReadyNowSS.ServiceModel.Types;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceInterface
{
    [Authenticate]
    public class ParentService : Service
    {

        public object Get(ParentRequest request)
        {
            var userAuth = Db.SingleWhere<UserAuth>("Email", Request.GetSession().Email)
                ?? Db.SingleWhere<UserAuth>("UserName", Request.GetSession().Email);

            Parent parent = null;
            if (!request.Id.HasValue || request.Id == 0)
                parent = new Parent() { UserAuthId = userAuth.Id };
            else
                parent = Db.Single<Parent>(new { Id = request.Id, UserAuthId = userAuth.Id });

            return new HttpResult()
            {
                Response = parent,
                View = "EditParent"
            };
        }

        public object Post(ParentRequest request)
        {
            var userAuth = Db.SingleWhere<UserAuth>("Email", Request.GetSession().Email)
                ?? Db.SingleWhere<UserAuth>("UserName", Request.GetSession().Email);

            Parent parent = new Parent().PopulateWith(request);
            parent.UserAuthId = userAuth.Id;

            Db.Save<Parent>(parent);

            return new HttpResult(parent, HttpStatusCode.RedirectMethod)
            {
                Location = new HomeRequest().ToGetUrl()
            };
        }

        public object Get(ParentSummaryRequest request)
        {
            var userAuth = Db.SingleWhere<UserAuth>("Email", Request.GetSession().Email)
                ?? Db.SingleWhere<UserAuth>("UserName", Request.GetSession().Email);

            Parent parent = Db.Select<Parent>(p => p.UserAuthId == userAuth.Id && p.Id == request.Id)
                .SingleOrDefault();

            if (parent == null)
                return new HttpResult(HttpStatusCode.RedirectMethod)
                {
                    Location = new HomeRequest().ToGetUrl()
                };
            ParentSummaryResponse response = new ParentSummaryResponse()
            {
                FamilyScore = 30,
                LegalScore = 100,
                MedicalScore = 0,
                SpiritualScore = 75
            }.PopulateWith(parent);

            return new HttpResult()
            {
                Response = response,
                View = "ParentSummary"
            };

        }


    }
}
