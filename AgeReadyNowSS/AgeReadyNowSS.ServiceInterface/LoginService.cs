﻿using AgeReadyNowSS.ServiceModel;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceInterface
{
    public class LoginService : Service
    {
        public object Any(LoginRequest request)
        {
            return new HttpResult()
            {
                View = "Login"
            };
        }
    }
}
