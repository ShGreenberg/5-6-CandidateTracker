using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5_6_CandidateTracker.web.Models
{
    public class ChangeStatusViewModal
    {
        public int Pending { get; set; }
        public int Confirmed { get; set; }
        public int Declined { get; set; }
    }
}
