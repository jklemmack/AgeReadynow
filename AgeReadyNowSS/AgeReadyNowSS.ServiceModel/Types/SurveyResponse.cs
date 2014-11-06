using ServiceStack.Auth;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel.Types
{
    public class SurveyResponse
    {
        [AutoIncrement]
        public int Id { get; set; }

        [References(typeof(UserAuth))]
        public int UserAuthId { get; set; }

        [References(typeof(Parent))]
        public int ParentId { get; set; }

        [References(typeof(Task))]
        public int TaskId { get; set; }

        [Reference]
        public Task Task { get; set; }

        public bool Completed { get; set; }

        public int Timeline { get; set; }
    }
}
