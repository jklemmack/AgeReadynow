using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel.Types
{
    public class Resource
    {
        public Resource()
        {
            Active = true;
        }

        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public string URL { get; set; }

        [References(typeof(State))]
        public string StateCode { get; set; }

        public Guid LegacyResourceId { get; set; }

    }
}
