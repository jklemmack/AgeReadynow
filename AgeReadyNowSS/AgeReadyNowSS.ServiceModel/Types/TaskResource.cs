﻿using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeReadyNowSS.ServiceModel.Types
{
    public class TaskResource
    {
        [AutoIncrement]
        public int Id { get; set; }

        public int TaskId { get; set; }
        public int ResourceId { get; set; }
    }
}
