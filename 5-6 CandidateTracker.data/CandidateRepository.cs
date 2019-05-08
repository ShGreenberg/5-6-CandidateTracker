using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace _5_6_CandidateTracker.data
{
    public class CandidateRepository
    {
        private string _connString;
        public CandidateRepository(string connString)
        {
            _connString = connString;
        }

        public void AddCandidate(Candidate candidate)
        {
            using(var ctx = new CandidateContext(_connString))
            {
                ctx.Candidates.Add(candidate);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<Candidate> GetPendingCandidates()
        {
            using(var ctx = new CandidateContext(_connString))
            {
                return ctx.Candidates.Where(c => c.Confirmed == null).ToList();
            }
        }

        public IEnumerable<Candidate> GetConfirmedCandidates()
        {
            using(var ctx = new CandidateContext(_connString))
            {
                return ctx.Candidates.Where(c => c.Confirmed == true).ToList();
            }
        }

        public IEnumerable<Candidate> GetDeclinedCandidates()
        {
            using (var ctx = new CandidateContext(_connString))
            {
                return ctx.Candidates.Where(c => c.Confirmed == false).ToList();
            }
        }

        public Candidate GetCandidate(int id)
        {
            using(var ctx = new CandidateContext(_connString))
            {
                return ctx.Candidates.FirstOrDefault(c => c.Id == id);
            }
        }

        public void ConfirmCandidate(int id, bool confirm)
        {
            using(var ctx = new CandidateContext(_connString))
            {
                ctx.Database.ExecuteSqlCommand("UPDATE Candidates SET Confirmed = @conf WHERE id = @id",
                    new SqlParameter("@conf", confirm), new SqlParameter("@id", id));
            }
        }

        

        
    }
}
