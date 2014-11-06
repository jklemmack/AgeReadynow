using AgeReadyNowSS.ServiceModel.Types;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel
{
    [Route("/Home")]
    [FallbackRoute("/{Path*}")]
    public class HomeRequest
    {
        public string Path { get; set; }
    }


    public class HomeResponse
    {
        public List<Parent> Parents { get; set; }
    }
}
