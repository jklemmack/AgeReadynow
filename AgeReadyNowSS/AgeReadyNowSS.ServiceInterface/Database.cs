using AgeReadyNowSS.ServiceModel.Types;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AgeReadyNowSS.ServiceInterface
{
    [Route("/Database/Reset")]
    public class DatabaseResetRequest
    {
    }

    public class DatabaseService : Service
    {
        public object Any(DatabaseResetRequest request)
        {
            OrmLiteAuthRepository userRepo = Request.TryResolve<IUserAuthRepository>() as OrmLiteAuthRepository;

            Db.DropTable<SurveyResponse>();
            Db.DropTable<Parent>();
            Db.DropTable<Resource>();
            Db.DropTable<Task>();
            Db.DropTable<Domain>();
            Db.DropTable<Video>();

            userRepo.DropAndReCreateTables();

            Db.CreateTable<Video>();
            Db.CreateTable<Domain>();
            Db.CreateTable<Task>();
            Db.CreateTable<Resource>();
            Db.CreateTable<Parent>();
            Db.CreateTable<SurveyResponse>();

            userRepo.CreateUserAuth(new UserAuth() { UserName = "jklemmack", Email = "johann.klemmack@gmail.com" }, "password");

            return true;
        }
    }
}
