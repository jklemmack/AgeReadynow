using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel
{
    [Route("/Parent", "POST, GET")]
    [Route("/Parent/{Id}", "GET, PUT, POST, DELETE")]
    public class ParentRequest : IReturn<ParentResponse>
    {
        public int? Id { get; set; }

        public int? Age { get; set; }
        public string Name { get; set; }

        public string State { get; set; }
        public string StateCode { get; set; }
    }

    public class ParentResponse
    {
        public int Id { get; set; }
        public int? Age { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }

        public int ReadinessScore { get; set; }
    }

    [Route("/Parent/Summary/{Id}")]
    public class ParentSummaryRequest : IReturn<ParentSummaryResponse>
    {
        public int Id { get; set; }
    }

    public class ParentSummaryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float MedicalScore { get; set; }
        public float LegalScore { get; set; }
        public float FamilyScore { get; set; }
        public float SpiritualScore { get; set; }
    }
}
