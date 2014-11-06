using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgeReadyNowSS.ServiceModel;

namespace AgeReadyNowSS.ServiceInterface
{
    public class AboutService : Service
    {
        [DefaultView("About")]
        public object Get(AboutRequest request)
        {
            return new HttpResult()
            {

            };
        }
    }
}
