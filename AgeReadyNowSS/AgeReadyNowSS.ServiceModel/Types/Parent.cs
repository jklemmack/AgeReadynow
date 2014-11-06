
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel.Types
{
    public enum RelationshipEnum
    {
        Family,
        Friend,
        Self,
        Other
    }

    public class Parent
    {
        [AutoIncrement]
        public int Id { get; set; }

        public int? Age { get; set; }

        [Required]
        public string Name { get; set; }

        public string State { get; set; }

        [References(typeof(UserAuth))]
        public int UserAuthId { get; set; }

        [Reference]
        public UserAuth UserAuth { get; set; }

        public string StateCode { get; set; }

        public bool IsSelf { get; set; }

        public RelationshipEnum Relationship { get; set; }
    }

}
