using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel.Types
{
    public class State
    {
        [PrimaryKey]
        [StringLength(2, 2)]
        public string StateCode { get; set; }

        [StringLength(50)]
        public string StateName { get; set; }

        public int SortOrder { get; set; }
    }
}
