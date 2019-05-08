using System;

namespace _5_6_CandidateTracker.data
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public bool? Confirmed { get; set; }
    }
}
