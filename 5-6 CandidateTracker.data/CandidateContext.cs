using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _5_6_CandidateTracker.data
{
    public class CandidateContext: DbContext
    {
        private string _connString;
        public CandidateContext(string connString)
        {
            _connString = connString;
        }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }
    }
}
