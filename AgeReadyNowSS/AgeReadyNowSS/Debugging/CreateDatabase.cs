using AgeReadyNowSS.ServiceModel.Types;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AgeReadyNowSS.Debugging
{
    [Route("/Database/Reset")]
    public class CreateDatabaseRequest
    {

    }

    public class CreateDatabaseService  : Service
    {
        public object Any(CreateDatabaseRequest request)
        {
            var dbFactory = this.TryResolve<IDbConnectionFactory>();
            //Drop and re-create all Auth and registration tables
            IUserAuthRepository authRepo = new OrmLiteAuthRepository(dbFactory);
            ((OrmLiteAuthRepository)authRepo).DropAndReCreateTables();
            IDbConnection db = dbFactory.OpenDbConnection();
            
            db.DropAndCreateTable<Parent>();


            UserAuth user = new UserAuth() { UserName = "jklemmack", Email = "johann.klemmack@gmail.com" };
            authRepo.CreateUserAuth(user, "password");

            return new HttpResult()
            {
                 StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}