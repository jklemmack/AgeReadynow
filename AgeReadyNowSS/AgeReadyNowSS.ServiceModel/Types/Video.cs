using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel.Types
{
    public class Video
    {
        [AutoIncrement]
        public int Id { get; set; }

        public string URL { get; set; }

        public string ShortText { get; set; }

        public string Description { get; set; }

        public string Copyright { get; set; }
    }
}
