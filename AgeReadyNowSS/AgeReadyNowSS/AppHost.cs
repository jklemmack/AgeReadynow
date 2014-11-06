using AgeReadyNowSS.ServiceInterface;
using AgeReadyNowSS.ServiceModel.Types;
using Funq;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Caching;
using ServiceStack.Data;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using ServiceStack.Razor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

namespace AgeReadyNowSS
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Default constructor.
        /// Base constructor requires a name and assembly to locate web service classes. 
        /// </summary>
        public AppHost()
            : base("AgeReadyNowSS", typeof(AccountService).Assembly)
        {

        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        /// <param name="container"></param>
        public override void Configure(Container container)
        {
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());

            SetConfig(new HostConfig()
            {
                AllowFileExtensions = { "swf", "f4v", "mp4", "m4v", "flv" },
                DefaultRedirectPath = "/Home"
            });

            this.Plugins.Add(new RazorFormat());

            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
              new IAuthProvider[] { 
                    new BasicAuthProvider() ,        //Sign-in with Basic Auth
                    new CredentialsAuthProvider() , //HTML Form post of UserName/Password credentials                    
                }
             ));

            Plugins.Add(new RegistrationFeature());


            ICacheClient cache = new MemoryCacheClient();
            IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(WebConfigurationManager.ConnectionStrings["AgeReady"].ConnectionString, SqlServerDialect.Provider);

            container.Register<ICacheClient>(cache);
            container.Register<IDbConnectionFactory>(dbFactory);

            OrmLiteAuthRepository userRepo = new OrmLiteAuthRepository(dbFactory);
            container.Register<IUserAuthRepository>(userRepo);
        }

        private void DropAndCreateTables(IDbConnectionFactory dbFactory, OrmLiteAuthRepository userRepo)
        {
        }
    }

}