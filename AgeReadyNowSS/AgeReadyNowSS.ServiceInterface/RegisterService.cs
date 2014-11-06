using AgeReadyNowSS.ServiceModel;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceInterface
{
    public class RegisterService : Service
    {
        public object Get(RegisterRequest request)
        {
            return new HttpResult()
            {
                Response = request,
                View = "Register"
            };
        }

        public object Post(RegisterRequest request)
        {
            IUserAuthRepository repo = this.TryResolve<IUserAuthRepository>();

            IUserAuth existingAuth = repo.GetUserAuthByUserName(request.Email);
            if (existingAuth != null)
            {
                RegisterRequest response = new RegisterRequest().PopulateWith(request);

                response.ResponseStatus = new ResponseStatus()
                {
                    Errors = new List<ResponseError>(){
                        new ResponseError() { FieldName = "Email", Message = "The email is already in use." }
                    }
                };
                return new HttpResult()
                {
                    Response = response,
                    View = "Register"
                };
            }
            else
            {
                AgeReadyNowSS.ServiceModel.RegisterResponse response = new ServiceModel.RegisterResponse();
                if (request.Password != request.ConfirmPassword)
                    response.ResponseStatus = new ResponseStatus()
                    {
                        Errors = new List<ResponseError>(){
                        new ResponseError() { FieldName = "Password", Message = "Passwords do not match." }
                    }
                    };

                UserAuth auth = new UserAuth()
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Meta = new Dictionary<string, string>()
                    {
                        {"RawPassword", request.Password}
                    }
                };
                repo.CreateUserAuth(auth, request.Password);

                using (var authService = base.ResolveService<AuthenticateService>())
                {
                    var authResponse = authService.Post(
                        new Authenticate
                        {
                            provider = CredentialsAuthProvider.Name,
                            UserName = request.Email,
                            Password = request.Password
                            //Continue = request.Continue
                        });
                }

                return new HttpResult()
                {
                    Response = response,
                    View = "RegisterResponse"
                };
            }

        }
    }
}
