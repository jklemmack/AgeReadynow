using AgeReadyNowSS.ServiceModel;
using AgeReadyNowSS.ServiceModel.Types;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceInterface
{
    public class HomeService : Service
    {
        public object Get(HomeRequest request)
        {
            HomeResponse response = new HomeResponse();
            bool isAuthenticated = Request.GetSession().IsAuthenticated;

            if (isAuthenticated)
            {
                
                var userAuth = Db.SingleWhere<UserAuth>("Email", Request.GetSession().Email)
                    ?? Db.SingleWhere<UserAuth>("UserName", Request.GetSession().Email);

                var parents = Db.Select<Parent>(p => p.UserAuthId == userAuth.Id);

                response.Parents = parents;

            }


            return new HttpResult()
            {
                View = (isAuthenticated) ? "HomeAuthenticated" : "Home",
                Response = response
            };
        }
    }
}
