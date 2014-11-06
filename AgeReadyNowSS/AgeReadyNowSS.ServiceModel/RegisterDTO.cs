using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel
{
    [Route("/register", "GET, POST")]
    public class RegisterRequest : IReturn<RegisterResponse>, IHasResponseStatus
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string EnrollCode { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }

    public class RegisterResponse : IHasResponseStatus
    {
        public ResponseStatus ResponseStatus { get; set; }
    }
}
